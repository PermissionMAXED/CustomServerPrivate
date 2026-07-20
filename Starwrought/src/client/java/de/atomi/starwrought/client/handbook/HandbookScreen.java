package de.atomi.starwrought.client.handbook;

import de.atomi.starwrought.client.fx.Easings;
import de.atomi.starwrought.client.fx.PrismPalette;
import java.util.ArrayList;
import java.util.List;
import java.util.Locale;
import java.util.Random;
import net.minecraft.client.gui.Click;
import net.minecraft.client.gui.DrawContext;
import net.minecraft.client.gui.screen.Screen;
import net.minecraft.client.gui.widget.TextFieldWidget;
import net.minecraft.client.sound.PositionedSoundInstance;
import net.minecraft.sound.SoundEvents;
import net.minecraft.text.OrderedText;
import net.minecraft.text.Text;

public final class HandbookScreen extends Screen {
	private static final int SIDEBAR_WIDTH = 132;
	private static final int TAB_HEIGHT = 20;

	private final HandbookState state;
	private final List<Mote> motes = new ArrayList<>();
	private HandbookState.Category category = HandbookState.Category.ALL;
	private HandbookState.Entry selected;
	private TextFieldWidget search;
	private String query = "";
	private float pageTurn = 1.0F;
	private int listScroll;
	private int panelX;
	private int panelY;
	private int panelWidth;
	private int panelHeight;

	public HandbookScreen(HandbookState state) {
		super(Text.translatable("handbook.starwrought.title"));
		this.state = state;
		this.selected = state.entries().stream().findFirst().orElse(null);
	}

	@Override
	protected void init() {
		panelWidth = Math.min(520, width - 24);
		panelHeight = Math.min(304, height - 24);
		panelX = (width - panelWidth) / 2;
		panelY = (height - panelHeight) / 2;

		search = new TextFieldWidget(
				textRenderer,
				panelX + 10,
				panelY + 56,
				Math.min(SIDEBAR_WIDTH - 20, panelWidth / 3),
				18,
				Text.translatable("handbook.starwrought.search")
		);
		search.setPlaceholder(Text.translatable("handbook.starwrought.search"));
		search.setMaxLength(64);
		search.setChangedListener(value -> {
			query = value.strip().toLowerCase(Locale.ROOT);
			listScroll = 0;
			List<HandbookState.Entry> visible = visibleEntries();
			if (!visible.contains(selected)) {
				selected = visible.stream().findFirst().orElse(null);
				pageTurn = 0.0F;
			}
		});
		addDrawableChild(search);

		motes.clear();
		Random random = new Random(0x51A7B00CL);
		for (int i = 0; i < 34; i++) {
			motes.add(new Mote(
					panelX + random.nextFloat() * panelWidth,
					panelY + random.nextFloat() * panelHeight,
					0.12F + random.nextFloat() * 0.34F,
					random.nextFloat() * 6.28F
			));
		}
	}

	@Override
	public void render(DrawContext context, int mouseX, int mouseY, float deltaTicks) {
		renderBackground(context, mouseX, mouseY, deltaTicks);
		pageTurn = Math.min(1.0F, pageTurn + deltaTicks * 0.095F);

		context.fill(panelX - 3, panelY - 3, panelX + panelWidth + 3, panelY + panelHeight + 3, 0xE0080514);
		context.fill(panelX, panelY, panelX + panelWidth, panelY + panelHeight, 0xF5120B2D);
		context.fillGradient(panelX, panelY, panelX + panelWidth, panelY + 26, 0xFF2A1B5E, 0xDD120B2D);
		context.fill(panelX, panelY + 25, panelX + panelWidth, panelY + 27, PrismPalette.CYAN);
		context.fill(panelX + SIDEBAR_WIDTH, panelY + 50, panelX + SIDEBAR_WIDTH + 1, panelY + panelHeight - 10, 0x884DE3FF);

		context.drawTextWithShadow(textRenderer, title, panelX + 10, panelY + 9, PrismPalette.WHITE_GOLD);
		context.drawTextWithShadow(
				textRenderer,
				Text.translatable("handbook.starwrought.subtitle"),
				panelX + panelWidth - textRenderer.getWidth(Text.translatable("handbook.starwrought.subtitle")) - 10,
				panelY + 9,
				0xFF8DEFFF
		);

		renderTabs(context, mouseX, mouseY);
		renderEntryList(context, mouseX, mouseY);
		renderPage(context);
		renderMotes(context, deltaTicks);
		super.render(context, mouseX, mouseY, deltaTicks);
	}

	private void renderTabs(DrawContext context, int mouseX, int mouseY) {
		int tabY = panelY + 31;
		int tabWidth = Math.max(46, (panelWidth - 20) / HandbookState.Category.values().length);
		int x = panelX + 10;
		for (HandbookState.Category candidate : HandbookState.Category.values()) {
			boolean selectedTab = candidate == category;
			boolean hovered = mouseX >= x && mouseX < x + tabWidth - 2
					&& mouseY >= tabY && mouseY < tabY + TAB_HEIGHT;
			int background = selectedTab ? 0xDD2A1B5E : hovered ? 0xAA352873 : 0x88120B2D;
			context.fill(x, tabY, x + tabWidth - 2, tabY + TAB_HEIGHT, background);
			if (selectedTab) {
				context.fill(x, tabY + TAB_HEIGHT - 2, x + tabWidth - 2, tabY + TAB_HEIGHT, PrismPalette.CYAN);
			}
			context.drawCenteredTextWithShadow(
					textRenderer,
					candidate.label(),
					x + (tabWidth - 2) / 2,
					tabY + 6,
					selectedTab ? PrismPalette.WHITE_GOLD : 0xFFD3CCEC
			);
			x += tabWidth;
		}
	}

	private void renderEntryList(DrawContext context, int mouseX, int mouseY) {
		int listX = panelX + 10;
		int listY = panelY + 80;
		int listWidth = Math.min(SIDEBAR_WIDTH - 20, panelWidth / 3);
		int rowHeight = 22;
		List<HandbookState.Entry> visible = visibleEntries();

		context.enableScissor(listX, listY, listX + listWidth, panelY + panelHeight - 10);
		for (int i = listScroll; i < visible.size(); i++) {
			HandbookState.Entry entry = visible.get(i);
			int y = listY + (i - listScroll) * rowHeight;
			if (y >= panelY + panelHeight - 10) {
				break;
			}
			boolean hovered = mouseX >= listX && mouseX < listX + listWidth
					&& mouseY >= y && mouseY < y + rowHeight - 2;
			int background = entry == selected ? 0xDD2A1B5E : hovered ? 0x99352873 : 0x55120B2D;
			context.fill(listX, y, listX + listWidth, y + rowHeight - 2, background);
			context.fill(listX, y, listX + 2, y + rowHeight - 2,
					entry.unlocked() ? PrismPalette.CYAN : 0xFF746B8F);
			String marker = entry.unlocked() ? "◆ " : "◇ ";
			context.drawTextWithShadow(
					textRenderer,
					Text.literal(marker).append(entry.title()),
					listX + 6,
					y + 6,
					entry.unlocked() ? 0xFFF4F0FF : 0xFF8D87A2
			);
		}
		context.disableScissor();
	}

	private void renderPage(DrawContext context) {
		int pageX = panelX + SIDEBAR_WIDTH + 12;
		int pageY = panelY + 58;
		int fullWidth = panelWidth - SIDEBAR_WIDTH - 24;
		int pageHeight = panelHeight - 70;
		float reveal = Easings.outCubic(pageTurn);
		int visibleWidth = Math.max(1, (int) (fullWidth * reveal));

		context.enableScissor(pageX, pageY, pageX + visibleWidth, pageY + pageHeight);
		context.fill(pageX, pageY, pageX + fullWidth, pageY + pageHeight, 0xF11B123A);
		context.fillGradient(pageX, pageY, pageX + fullWidth, pageY + 34, 0xCC2A1B5E, 0x44120B2D);
		context.fill(pageX + 10, pageY + 8, pageX + 13, pageY + 29, PrismPalette.CYAN);
		context.fill(pageX + 16, pageY + 8, pageX + 18, pageY + 22, PrismPalette.WHITE_GOLD);

		if (selected == null) {
			context.drawCenteredTextWithShadow(
					textRenderer,
					Text.translatable("handbook.starwrought.no_results"),
					pageX + fullWidth / 2,
					pageY + pageHeight / 2,
					0xFF8D87A2
			);
		} else {
			context.drawTextWithShadow(textRenderer, selected.title(), pageX + 25, pageY + 12, PrismPalette.WHITE_GOLD);
			context.fill(pageX + 12, pageY + 38, pageX + fullWidth - 12, pageY + 39, 0x664DE3FF);
			List<OrderedText> lines = textRenderer.wrapLines(selected.body(), fullWidth - 32);
			int y = pageY + 50;
			for (OrderedText line : lines) {
				if (y > pageY + pageHeight - 16) {
					break;
				}
				context.drawTextWithShadow(textRenderer, line, pageX + 16, y, 0xFFE5E0F5);
				y += 12;
			}
			if (!selected.unlocked()) {
				context.drawCenteredTextWithShadow(
						textRenderer,
						Text.translatable("handbook.starwrought.locked"),
						pageX + fullWidth / 2,
						pageY + pageHeight - 22,
						0xFFFFE9A8
				);
			}
		}
		context.disableScissor();

		int foldAlpha = Math.min(255, (int) ((1.0F - reveal) * 230.0F));
		context.fill(pageX + visibleWidth - 2, pageY, pageX + visibleWidth + 2, pageY + pageHeight,
				(foldAlpha << 24) | (PrismPalette.WHITE_GOLD & 0x00FFFFFF));
	}

	private void renderMotes(DrawContext context, float deltaTicks) {
		for (Mote mote : motes) {
			mote.y -= mote.speed * Math.max(0.1F, deltaTicks);
			mote.phase += 0.035F * Math.max(0.1F, deltaTicks);
			mote.x += Math.sin(mote.phase) * 0.08F;
			if (mote.y < panelY + 28) {
				mote.y = panelY + panelHeight - 5;
			}
			int color = PrismPalette.withAlpha(
					Math.sin(mote.phase * 0.7F) > 0.0 ? PrismPalette.CYAN : PrismPalette.WHITE_GOLD,
					0.22F
			);
			int x = (int) mote.x;
			int y = (int) mote.y;
			context.fill(x - 1, y, x + 2, y + 1, color);
			context.fill(x, y - 1, x + 1, y + 2, color);
		}
	}

	@Override
	public boolean mouseClicked(Click click, boolean doubled) {
		double mouseX = click.x();
		double mouseY = click.y();
		int tabY = panelY + 31;
		int tabWidth = Math.max(46, (panelWidth - 20) / HandbookState.Category.values().length);
		int x = panelX + 10;
		for (HandbookState.Category candidate : HandbookState.Category.values()) {
			if (inside(mouseX, mouseY, x, tabY, tabWidth - 2, TAB_HEIGHT)) {
				category = candidate;
				listScroll = 0;
				List<HandbookState.Entry> visible = visibleEntries();
				if (!visible.contains(selected)) {
					select(visible.stream().findFirst().orElse(null));
				}
				return true;
			}
			x += tabWidth;
		}

		int listX = panelX + 10;
		int listY = panelY + 80;
		int listWidth = Math.min(SIDEBAR_WIDTH - 20, panelWidth / 3);
		List<HandbookState.Entry> visible = visibleEntries();
		for (int i = listScroll; i < visible.size(); i++) {
			int rowY = listY + (i - listScroll) * 22;
			if (rowY >= panelY + panelHeight - 10) {
				break;
			}
			if (inside(mouseX, mouseY, listX, rowY, listWidth, 20)) {
				select(visible.get(i));
				return true;
			}
		}
		return super.mouseClicked(click, doubled);
	}

	@Override
	public boolean mouseScrolled(double mouseX, double mouseY, double horizontalAmount, double verticalAmount) {
		int listX = panelX + 10;
		int listY = panelY + 80;
		int listWidth = Math.min(SIDEBAR_WIDTH - 20, panelWidth / 3);
		int listHeight = panelHeight - 90;
		if (inside(mouseX, mouseY, listX, listY, listWidth, listHeight)) {
			int visibleRows = Math.max(1, listHeight / 22);
			int maximum = Math.max(0, visibleEntries().size() - visibleRows);
			listScroll = Math.max(0, Math.min(maximum, listScroll - (int) Math.signum(verticalAmount)));
			return true;
		}
		return super.mouseScrolled(mouseX, mouseY, horizontalAmount, verticalAmount);
	}

	@Override
	public boolean shouldPause() {
		return false;
	}

	private void select(HandbookState.Entry entry) {
		if (selected == entry) {
			return;
		}
		selected = entry;
		pageTurn = 0.0F;
		if (client != null) {
			client.getSoundManager().play(
					PositionedSoundInstance.master(SoundEvents.ITEM_BOOK_PAGE_TURN, 0.72F, 1.08F)
			);
		}
	}

	private List<HandbookState.Entry> visibleEntries() {
		return state.entries().stream()
				.filter(entry -> category == HandbookState.Category.ALL || entry.category() == category)
				.filter(entry -> query.isBlank()
						|| entry.title().getString().toLowerCase(Locale.ROOT).contains(query))
				.toList();
	}

	private static boolean inside(double x, double y, int left, int top, int width, int height) {
		return x >= left && x < left + width && y >= top && y < top + height;
	}

	private static final class Mote {
		private float x;
		private float y;
		private final float speed;
		private float phase;

		private Mote(float x, float y, float speed, float phase) {
			this.x = x;
			this.y = y;
			this.speed = speed;
			this.phase = phase;
		}
	}
}
