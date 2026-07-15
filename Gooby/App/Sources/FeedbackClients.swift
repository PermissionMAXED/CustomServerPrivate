@preconcurrency import AVFoundation
import Foundation
import UIKit

@MainActor
final class ProceduralAudioClient: AudioFeedbackClient {
    private let engine = AVAudioEngine()
    private let player = AVAudioPlayerNode()
    private let sampleRate = 44_100.0
    private var isEnabled = true
    private var isConfigured = false

    func setAmbientEnabled(_ enabled: Bool) {
        isEnabled = enabled
        guard enabled else {
            player.stop()
            return
        }
        configureIfNeeded()
    }

    func play(_ cue: FeedbackCue) {
        guard isEnabled else { return }
        configureIfNeeded()
        guard isConfigured, let buffer = makeBuffer(for: cue) else { return }
        player.stop()
        player.scheduleBuffer(buffer, at: nil, options: .interrupts)
        player.play()
    }

    private func configureIfNeeded() {
        guard !isConfigured else { return }
        do {
            let session = AVAudioSession.sharedInstance()
            try session.setCategory(.ambient, mode: .default, options: [.mixWithOthers])
            let format = AVAudioFormat(
                standardFormatWithSampleRate: sampleRate,
                channels: 1
            )
            guard let format else { return }
            engine.attach(player)
            engine.connect(player, to: engine.mainMixerNode, format: format)
            try engine.start()
            isConfigured = true
        } catch {
            isEnabled = false
        }
    }

    private func makeBuffer(for cue: FeedbackCue) -> AVAudioPCMBuffer? {
        let notes: [(Double, Double, Float)]
        switch cue {
        case .feed: notes = [(523, 0.08, 0.16), (659, 0.11, 0.13)]
        case .wash: notes = [(784, 0.05, 0.09), (988, 0.08, 0.08)]
        case .pet: notes = [(440, 0.10, 0.13), (554, 0.12, 0.12)]
        case .play: notes = [(659, 0.07, 0.13), (880, 0.10, 0.12)]
        case .sleep: notes = [(392, 0.10, 0.10), (294, 0.18, 0.09)]
        case .wake: notes = [(392, 0.08, 0.11), (523, 0.12, 0.12)]
        case .room: notes = [(466, 0.08, 0.08)]
        case .reward: notes = [(523, 0.07, 0.12), (659, 0.07, 0.12), (784, 0.12, 0.12)]
        }

        let duration = notes.reduce(0) { $0 + $1.1 }
        let capacity = AVAudioFrameCount(duration * sampleRate)
        guard let format = AVAudioFormat(
            standardFormatWithSampleRate: sampleRate,
            channels: 1
        ),
            let buffer = AVAudioPCMBuffer(pcmFormat: format, frameCapacity: capacity),
            let channel = buffer.floatChannelData?[0]
        else {
            return nil
        }

        buffer.frameLength = capacity
        var frame = 0
        for (frequency, noteDuration, volume) in notes {
            let noteFrames = Int(noteDuration * sampleRate)
            for offset in 0 ..< noteFrames where frame + offset < Int(capacity) {
                let time = Double(offset) / sampleRate
                let envelope = sin(.pi * Double(offset) / Double(max(noteFrames, 1)))
                channel[frame + offset] = Float(sin(2 * .pi * frequency * time) * envelope) * volume
            }
            frame += noteFrames
        }
        return buffer
    }
}

@MainActor
final class SystemHapticClient: HapticFeedbackClient {
    private var isEnabled = true

    func setEnabled(_ enabled: Bool) {
        isEnabled = enabled
    }

    func impact(_ cue: FeedbackCue) {
        guard isEnabled, UIDevice.current.userInterfaceIdiom == .phone else { return }
        switch cue {
        case .reward:
            UINotificationFeedbackGenerator().notificationOccurred(.success)
        case .wash, .play:
            UIImpactFeedbackGenerator(style: .medium).impactOccurred()
        default:
            UIImpactFeedbackGenerator(style: .soft).impactOccurred()
        }
    }
}
