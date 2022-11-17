using System;

namespace Services.Audio
{
    public class AudioGroupMapper
    {
        public Type GetAudioGroupType(AudioGroupType type)
        {
            return type switch
            {
                AudioGroupType.Sfx => typeof(SfxAudioGroup),
                AudioGroupType.Background => typeof(BackgroundAudioGroup),
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
            };
        }
    }
}