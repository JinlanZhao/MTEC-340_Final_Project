# Liminal Resonance — Final Project Proposal

## Project Name
**Liminal Resonance**

## Project Description and Implementation

**Liminal Resonance** is an interactive virtual audiovisual installation built in Unity that explores the concept of sonic liminality through spatial presence and movement. Participants navigate a dark, minimal room containing two distinct sonic membranes—semi-transparent boundaries that represent different voice parts of an incomplete choir. Through proximity-based and crossing-based interactions, participants gradually reveal and harmonize these vocal layers, transforming the space from silence into a resonant choral environment.

The project positions itself as a contemplative installation rather than a goal-driven game. The participant's journey is one of discovery: understanding that their movement and sustained attention shape the sonic-spatial fabric of the room itself. Each membrane embodies a different vocal register (soprano and alto), and only through engaging with both can the participant experience the emergence of a complete harmonic texture.

### Technical Implementation:
- Unity 2022 LTS with Universal Render Pipeline (URP) for performance optimization
- Native Unity Audio Mixer with exposed parameters for real-time control
- Shader Graph-based translucent materials with emissive properties
- First-person character controller with Cinemachine for smooth camera handling
- Trigger-based collision detection with distance calculation for proximity interactions
- Particle systems controlled via scripting for visual feedback
- 3D spatial audio with custom distance attenuation curves per membrane type

The scope deliberately limits to two membranes to ensure technical feasibility within the timeline while maintaining artistic integrity. This allows deeper refinement of each interaction type and more polished audiovisual synchronization.

---

## Good Outcome Deliverable (WILL achieve)

Core features guaranteed for completion:

- **Playable Unity build** exported with functional executable
- **Start menu UI** with project title, basic instructions, start button, and quit function
- **First-person navigation** with WASD movement and mouse look (using Unity's starter assets or custom controller)
- **Abstract enclosed room environment** with dark ambient lighting (dimensions: 15x15x6 meters)
- **Two interactive sonic membranes** positioned strategically in the space:
  - **Membrane A (Soprano):** Proximity-based interaction with continuous distance-to-volume mapping
  - **Membrane B (Alto):** Crossing-based interaction triggering one-shot vocal gesture
- **Basic audio system** with at least 4 sound layers (room tone, 2 membrane layers, 1 crossing sound)
- **Audio Mixer integration** with volume and basic filtering control
- **Translucent membrane materials** using Shader Graph with adjustable opacity
- **Trigger colliders** functioning correctly for interaction detection
- **Functional quit** via ESC key or menu button

---

## Better Outcome Deliverable (THINK will accomplish)

Enhanced features with reasonable confidence:

- **Sound Possibilities** More interactive objects that can trigger sounds for the player to explore the space. 
- **Polished membrane visuals** including:
  - Emissive glow intensity tied to interaction state
  - Animated noise texture for organic membrane surface movement
  - Color differentiation per membrane (warm/cool tones for soprano/alto)
- **Particle system integration** emitting from membranes during active interaction
- **Advanced audio implementation:**
  - 3D spatial audio with Doppler effect on crossing
  - Custom distance attenuation curves per membrane
  - Reverb wet/dry mix responding to participant position
  - Low-pass filter opening as proximity increases
- **Environmental lighting reactions** with point lights intensifying near active membranes
- **Smooth Audio Mixer snapshot transitions** (2-3 second crossfades between states)
- **Refined room acoustics** using Unity's reverb zones
- **Instruction overlay** appearing briefly on start (fade out after 5 seconds)
- **Performance optimization** maintaining 60fps on target hardware (mid-range laptop)

---

## Best Outcome Deliverable (HOPE to accomplish)

Stretch goals if time permits:

- **Third membrane (Tenor)** with dwell-based interaction:
  - Visual pulsing cue indicating "stay here"
  - Timer-based layer reveal (5-second threshold)
  - Hidden harmonic layer completing the three-part choir
- **Dynamic room ambience** that evolves as membranes are activated (silence → sparse → full)
- **Subtle trail effect** following participant movement to enhance spatial awareness
- **Harmonic resonance system** where activating both membranes simultaneously creates additional overtone layer
- **Custom Shader Graph effects:**
  - Fresnel-based edge highlighting
  - Vertex displacement animation for membrane surface
- **Audio visualization** with real-time frequency analysis driving particle emission rate
- **Fade-to-black transition** on quit for graceful exit
- **Simple analytics** tracking which membrane participants interact with first/most

---

## Next Steps and Required Skills

### Immediate next steps (Week 1):

1. **Build technical proof-of-concept scene** with single cube and Audio Mixer parameter control
2. **Create sound palette:**
   - Record or synthesize 15-20 seconds of sustained vocal tones per register
   - Process through spectral filtering to create textural layers
   - Design short crossing gesture (1-2 second vocal burst)
3. **Study Unity documentation:**
   - Audio Mixer exposed parameters and snapshot scripting
   - Trigger collision vs. continuous distance checks (Physics.OverlapSphere)
   - Shader Graph transparent/emissive workflows

### Skills to acquire:

- **Unity C# scripting** for interaction state machines (if/else logic, coroutines for timers)
- **Audio Mixer architecture** understanding snapshot transitions and parameter exposure
- **Shader Graph fundamentals** focusing on transparency, emission, and texture animation nodes
- **Particle System scripting** to control emission rate/color from code
- **3D audio setup** including spatial blend, rolloff curves, and reverb zone configuration
- **Performance profiling** using Unity Profiler to identify bottlenecks

### Research topics:

- Trigger event patterns in Unity (OnTriggerEnter/Stay/Exit)
- Distance calculation methods (Vector3.Distance vs. magnitude comparison for performance)
- Audio Mixer SetFloat() API for real-time parameter control
- Shader property exposure to scripts (_EmissionColor, _Alpha control)
- Particle System Play/Stop from script and emission module parameter adjustment

### Success metrics for testing phase:

- External tester identifies both interaction types within 3 minutes
- Sound layers are distinctly audible at 2+ meters distance
- No frame drops below 60fps during simultaneous membrane activation
- Participants describe the experience as "contemplative" or "immersive" rather than "confusing"

---

# Game Design Document

## Core Concept
A first-person spatial audio installation where participant movement completes an incomplete choir by activating vocal membranes scattered in a dark room.

## Player Experience
The participant enters silence and discovers that their presence matters—proximity awakens voices, crossing triggers gestures. The installation teaches its own language through immediate audiovisual feedback without explicit instruction.

## Interaction Vocabulary

### 1. Proximity (Membrane A - Soprano)
- **Distance 5m+:** Silent, dim glow
- **Distance 2-5m:** Volume increases, brightness rises
- **Distance <2m:** Full volume, strong emissive light, particle emission
- Continuous response allows expressive "playing" of the membrane

### 2. Crossing (Membrane B - Alto)
- **Approach:** Base layer hums quietly
- **Pass through threshold:** Sharp one-shot vocal gesture triggers
- **Doppler shift** on fast crossing creates sense of spatial depth
- Resets after 3 seconds cooldown

## Spatial Design
- **Room dimensions:** 15x15x6 meters (intimate but not claustrophobic)
- **Membranes placed** 8 meters apart diagonally (forces traversal)
- **Entrance** at corner, naturally leads to Membrane A first
- **Dark ambient** base with localized lighting from membranes

## Audio Architecture
- **Room Tone:** Low-frequency pad (40Hz fundamental) always present
- **Membrane A Layer:** Sustained soprano vowel (A/E/I progression), 200-800Hz
- **Membrane B Layer:** Sustained alto vowel (O/U character), 150-400Hz  
- **Crossing Gesture:** Staccato alto burst (0.8sec duration)
- **Reverb:** Large hall preset, wet mix 20-60% depending on membrane activation

## Visual Language
- **Membranes:** 3x4 meter vertical planes, 30% base opacity
- **Color coding:** Warm amber (soprano) vs. cool cyan (alto)
- **Emissive intensity:** 0.2-2.0 range based on interaction
- **Particles:** Slow-rising wisps (lifetime 4sec) matching membrane color
- **Environment:** Matte black walls to eliminate visual distraction

## Technical Constraints
- Target 60fps on laptop with integrated graphics (Intel Iris Xe / AMD Vega equivalent)
- Maximum 3 active audio sources simultaneously
- Shader complexity limited to avoid mobile baking issues if later ported
- No post-processing stack to maintain performance budget

## Win Condition
None. The installation is complete when the participant feels satisfied with their exploration. Duration of interaction is participant-determined (expected 2-8 minutes).

## Design Philosophy
The project follows "augmentation without interruption"—interactions feel like natural extensions of movement rather than button-press mechanics. The choir metaphor grounds the abstraction: each membrane is a voice waiting to be heard, and the participant becomes the conductor through their spatial choreography.

---

## Development Timeline

### Week 1: Proof-of-Concept
- Single membrane with functional audio-visual feedback loop
- Basic FPS controller integration
- Audio Mixer parameter control validation

### Week 2: Core Implementation
- Second membrane implementation
- Room environment construction
- Interaction polish and parameter tuning

### Week 3: Audiovisual Refinement
- Sound design completion
- Shader effects and particle systems
- Lighting integration

### Week 4: Testing and Documentation
- External playtesting
- Bug fixes and performance optimization
- Final build export and documentation
