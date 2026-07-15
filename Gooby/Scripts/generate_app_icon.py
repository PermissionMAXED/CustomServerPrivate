#!/usr/bin/env python3
"""Generate Gooby's original 1024px rabbit icon using only Python's stdlib."""

from __future__ import annotations

import argparse
import math
import struct
import zlib
from pathlib import Path

SIZE = 1024


def blend(pixel_bytes: bytearray, x: int, y: int, color: tuple[int, int, int], alpha: float) -> None:
    if alpha <= 0:
        return
    offset = (y * SIZE + x) * 3
    inverse = 1.0 - min(alpha, 1.0)
    for channel in range(3):
        pixel_bytes[offset + channel] = round(
            pixel_bytes[offset + channel] * inverse + color[channel] * (1.0 - inverse)
        )


def ellipse(
    pixels: bytearray,
    center_x: float,
    center_y: float,
    radius_x: float,
    radius_y: float,
    color: tuple[int, int, int],
) -> None:
    left = max(0, int(center_x - radius_x - 2))
    right = min(SIZE, int(center_x + radius_x + 3))
    top = max(0, int(center_y - radius_y - 2))
    bottom = min(SIZE, int(center_y + radius_y + 3))
    edge_scale = min(radius_x, radius_y)

    for y in range(top, bottom):
        normalized_y = (y + 0.5 - center_y) / radius_y
        for x in range(left, right):
            normalized_x = (x + 0.5 - center_x) / radius_x
            distance = math.sqrt(normalized_x * normalized_x + normalized_y * normalized_y)
            coverage = max(0.0, min(1.0, (1.0 - distance) * edge_scale + 0.5))
            blend(pixels, x, y, color, coverage)


def make_pixels() -> bytearray:
    pixels = bytearray(SIZE * SIZE * 3)
    for y in range(SIZE):
        vertical = y / (SIZE - 1)
        for x in range(SIZE):
            horizontal = x / (SIZE - 1)
            glow = max(0.0, 1.0 - math.hypot(horizontal - 0.28, vertical - 0.18))
            offset = (y * SIZE + x) * 3
            pixels[offset] = round(236 + 13 * glow - 10 * vertical)
            pixels[offset + 1] = round(190 + 24 * glow - 10 * vertical)
            pixels[offset + 2] = round(178 + 27 * glow + 13 * horizontal)

    shadow = (142, 91, 91)
    fur_dark = (174, 124, 105)
    fur = (215, 171, 139)
    fur_light = (237, 204, 172)
    inner_ear = (232, 145, 151)
    ink = (68, 43, 48)
    blush = (239, 135, 140)

    ellipse(pixels, 512, 865, 335, 74, shadow)
    ellipse(pixels, 360, 270, 108, 248, fur_dark)
    ellipse(pixels, 664, 270, 108, 248, fur_dark)
    ellipse(pixels, 360, 274, 67, 192, inner_ear)
    ellipse(pixels, 664, 274, 67, 192, inner_ear)
    ellipse(pixels, 512, 690, 330, 295, fur_dark)
    ellipse(pixels, 512, 665, 314, 286, fur)
    ellipse(pixels, 512, 470, 292, 252, fur)
    ellipse(pixels, 512, 528, 215, 165, fur_light)
    ellipse(pixels, 315, 686, 92, 135, fur_light)
    ellipse(pixels, 709, 686, 92, 135, fur_light)
    ellipse(pixels, 414, 452, 27, 38, ink)
    ellipse(pixels, 610, 452, 27, 38, ink)
    ellipse(pixels, 405, 443, 8, 11, (255, 255, 244))
    ellipse(pixels, 601, 443, 8, 11, (255, 255, 244))
    ellipse(pixels, 354, 539, 47, 24, blush)
    ellipse(pixels, 670, 539, 47, 24, blush)
    ellipse(pixels, 512, 520, 28, 21, (218, 104, 116))
    ellipse(pixels, 487, 555, 26, 18, ink)
    ellipse(pixels, 537, 555, 26, 18, ink)
    ellipse(pixels, 512, 547, 43, 18, fur_light)
    ellipse(pixels, 414, 817, 112, 70, fur_light)
    ellipse(pixels, 610, 817, 112, 70, fur_light)
    return pixels


def png_chunk(kind: bytes, payload: bytes) -> bytes:
    checksum = zlib.crc32(kind)
    checksum = zlib.crc32(payload, checksum)
    return struct.pack(">I", len(payload)) + kind + payload + struct.pack(">I", checksum)


def encode_png(pixels: bytearray) -> bytes:
    rows = bytearray()
    row_length = SIZE * 3
    for y in range(SIZE):
        rows.append(0)
        start = y * row_length
        rows.extend(pixels[start : start + row_length])

    header = struct.pack(">IIBBBBB", SIZE, SIZE, 8, 2, 0, 0, 0)
    return (
        b"\x89PNG\r\n\x1a\n"
        + png_chunk(b"IHDR", header)
        + png_chunk(b"IDAT", zlib.compress(bytes(rows), level=9))
        + png_chunk(b"IEND", b"")
    )


def main() -> None:
    default_output = (
        Path(__file__).resolve().parents[1]
        / "App"
        / "Resources"
        / "Assets.xcassets"
        / "AppIcon.appiconset"
        / "AppIcon.png"
    )
    parser = argparse.ArgumentParser()
    parser.add_argument("--output", type=Path, default=default_output)
    arguments = parser.parse_args()
    arguments.output.parent.mkdir(parents=True, exist_ok=True)
    arguments.output.write_bytes(encode_png(make_pixels()))
    print(f"Generated {arguments.output} ({SIZE}x{SIZE}, RGB)")


if __name__ == "__main__":
    main()
