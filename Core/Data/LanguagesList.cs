using System.Collections.Generic;
using Core.Models.Languages;

namespace Core.Data
{
    public static class LanguagesList
    {
        public static readonly Language Ar = new Language
        {
            BaseCharacter = 'أ',
            Characters = new List<char>("ابتثجحخدذرزسشصضطظعغفقكلمنهوي"),
            AlikeChars = new List<AlikeChar>
            {
                new AlikeChar
                {
                    Master = 'ا',
                    Slaves = { 'أ', 'إ', 'آ', 'ء' }
                },
                new AlikeChar
                {
                    Master = 'ه',
                    Slaves = { 'ة' }
                },
                new AlikeChar
                {
                    Master = 'و',
                    Slaves = { 'ؤ' }
                },
                new AlikeChar
                {
                    Master = 'ي',
                    Slaves = { 'ى', 'ئ' }
                }
            }
        };
    }
}
