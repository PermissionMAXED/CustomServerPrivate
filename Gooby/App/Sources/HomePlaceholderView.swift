import SwiftUI

struct HomePlaceholderView: View {
    var body: some View {
        ZStack {
            LinearGradient(
                colors: [
                    Color(red: 0.98, green: 0.89, blue: 0.74),
                    Color(red: 0.91, green: 0.75, blue: 0.82),
                ],
                startPoint: .topLeading,
                endPoint: .bottomTrailing
            )
            .ignoresSafeArea()

            VStack(spacing: 24) {
                Spacer()

                RabbitMark()
                    .frame(width: 220, height: 220)
                    .accessibilityHidden(true)

                VStack(spacing: 8) {
                    Text(GoobyBrand.name)
                        .font(.system(size: 54, weight: .black, design: .rounded))
                        .foregroundStyle(Color(red: 0.25, green: 0.16, blue: 0.20))

                    Text(GoobyBrand.subtitle)
                        .font(.system(.headline, design: .rounded, weight: .semibold))
                        .multilineTextAlignment(.center)
                        .foregroundStyle(.secondary)
                }

                Spacer()

                Label("Made for quiet, offline moments", systemImage: "leaf.fill")
                    .font(.system(.footnote, design: .rounded, weight: .medium))
                    .foregroundStyle(.secondary)
                    .padding(.horizontal, 18)
                    .padding(.vertical, 10)
                    .background(.ultraThinMaterial, in: Capsule())
                    .padding(.bottom, 20)
            }
            .padding(28)
        }
    }
}

private struct RabbitMark: View {
    var body: some View {
        ZStack {
            Capsule()
                .fill(Color(red: 0.76, green: 0.58, blue: 0.48))
                .frame(width: 62, height: 122)
                .rotationEffect(.degrees(-12))
                .offset(x: -42, y: -72)

            Capsule()
                .fill(Color(red: 0.76, green: 0.58, blue: 0.48))
                .frame(width: 62, height: 122)
                .rotationEffect(.degrees(12))
                .offset(x: 42, y: -72)

            Circle()
                .fill(Color(red: 0.84, green: 0.68, blue: 0.56))
                .overlay {
                    HStack(spacing: 48) {
                        Circle()
                            .fill(Color(red: 0.24, green: 0.16, blue: 0.18))
                            .frame(width: 15, height: 20)
                        Circle()
                            .fill(Color(red: 0.24, green: 0.16, blue: 0.18))
                            .frame(width: 15, height: 20)
                    }
                    .offset(y: -10)
                }
                .overlay {
                    RoundedRectangle(cornerRadius: 8)
                        .fill(Color(red: 0.95, green: 0.62, blue: 0.66))
                        .frame(width: 22, height: 14)
                        .offset(y: 20)
                }
                .shadow(color: .brown.opacity(0.18), radius: 20, y: 14)
        }
    }
}

#Preview {
    HomePlaceholderView()
}
