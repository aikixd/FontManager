﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace BadPanda.FreeType.Interop
{
    internal enum NameId : ushort
    {
        TT_NAME_ID_COPYRIGHT = 0,
        TT_NAME_ID_FONT_FAMILY = 1,
        TT_NAME_ID_FONT_SUBFAMILY = 2,
        TT_NAME_ID_UNIQUE_ID = 3,
        TT_NAME_ID_FULL_NAME = 4,
        TT_NAME_ID_VERSION_STRING = 5,
        TT_NAME_ID_PS_NAME = 6,
        TT_NAME_ID_TRADEMARK = 7,

        /* the following values are from the OpenType spec */
        TT_NAME_ID_MANUFACTURER = 8,
        TT_NAME_ID_DESIGNER = 9,
        TT_NAME_ID_DESCRIPTION = 10,
        TT_NAME_ID_VENDOR_URL = 11,
        TT_NAME_ID_DESIGNER_URL = 12,
        TT_NAME_ID_LICENSE = 13,
        TT_NAME_ID_LICENSE_URL = 14,
        /* number 15 is reserved */
        TT_NAME_ID_TYPOGRAPHIC_FAMILY = 16,
        TT_NAME_ID_TYPOGRAPHIC_SUBFAMILY = 17,
        TT_NAME_ID_MAC_FULL_NAME = 18,

        /* The following code is new as of 2000-01-21 */
        TT_NAME_ID_SAMPLE_TEXT = 19,

        /* This is new in OpenType 1.3 */
        TT_NAME_ID_CID_FINDFONT_NAME = 20,

        /* This is new in OpenType 1.5 */
        TT_NAME_ID_WWS_FAMILY = 21,
        TT_NAME_ID_WWS_SUBFAMILY = 22,

        /* This is new in OpenType 1.7 */
        TT_NAME_ID_LIGHT_BACKGROUND = 23,
        TT_NAME_ID_DARK_BACKGROUND = 24,

        /* This is new in OpenType 1.8 */
        TT_NAME_ID_VARIATIONS_PREFIX = 25
    }

    public enum PlatformId : ushort
    {
        AppleUnicode = 0,
        Mac = 1,
        Iso = 2,
        Microsoft = 3,
        Custom = 4,
        Adobe = 7
    }

    internal static class Identifications
    {
        

        public static Dictionary<PlatformId, EncodingCollection> PlatformIds =>
            new Dictionary<PlatformId, EncodingCollection>
            {
                { PlatformId.AppleUnicode, new EncodingCollection {
                    { 0, "TT_APPLE_ID_DEFAULT | Unicode 1.0" },
                    { 1, "TT_APPLE_ID_UNICODE_1_1 | specify Hangul at U+34xx" },
                    { 2, "TT_APPLE_ID_ISO_10646 | deprecated" },
                    { 3, "TT_APPLE_ID_UNICODE_2_0 | or later" },
                    { 4, "TT_APPLE_ID_UNICODE_32 | 2.0 or later, full repertoire" },
                    { 5, "TT_APPLE_ID_VARIANT_SELECTOR | variation selector data" },
                    { 6, "TT_APPLE_ID_FULL_UNICODE | used with type 13 cmaps" }
                }},
                { PlatformId.Mac, new EncodingCollection(
                    new Dictionary<ushort, string>{
                        { 0, "TT_MAC_LANGID_ENGLISH" },
                        { 1, "TT_MAC_LANGID_FRENCH" },
                        { 2, "TT_MAC_LANGID_GERMAN" },
                        { 3, "TT_MAC_LANGID_ITALIAN" },
                        { 4, "TT_MAC_LANGID_DUTCH" },
                        { 5, "TT_MAC_LANGID_SWEDISH" },
                        { 6, "TT_MAC_LANGID_SPANISH" },
                        { 7, "TT_MAC_LANGID_DANISH" },
                        { 8, "TT_MAC_LANGID_PORTUGUESE" },
                        { 9, "TT_MAC_LANGID_NORWEGIAN" },
                        { 10, "TT_MAC_LANGID_HEBREW" },
                        { 11, "TT_MAC_LANGID_JAPANESE" },
                        { 12, "TT_MAC_LANGID_ARABIC" },
                        { 13, "TT_MAC_LANGID_FINNISH" },
                        { 14, "TT_MAC_LANGID_GREEK" },
                        { 15, "TT_MAC_LANGID_ICELANDIC" },
                        { 16, "TT_MAC_LANGID_MALTESE" },
                        { 17, "TT_MAC_LANGID_TURKISH" },
                        { 18, "TT_MAC_LANGID_CROATIAN" },
                        { 19, "TT_MAC_LANGID_CHINESE_TRADITIONAL" },
                        { 20, "TT_MAC_LANGID_URDU" },
                        { 21, "TT_MAC_LANGID_HINDI" },
                        { 22, "TT_MAC_LANGID_THAI" },
                        { 23, "TT_MAC_LANGID_KOREAN" },
                        { 24, "TT_MAC_LANGID_LITHUANIAN" },
                        { 25, "TT_MAC_LANGID_POLISH" },
                        { 26, "TT_MAC_LANGID_HUNGARIAN" },
                        { 27, "TT_MAC_LANGID_ESTONIAN" },
                        { 28, "TT_MAC_LANGID_LETTISH" },
                        { 29, "TT_MAC_LANGID_SAAMISK" },
                        { 30, "TT_MAC_LANGID_FAEROESE" },
                        { 31, "TT_MAC_LANGID_FARSI" },
                        { 32, "TT_MAC_LANGID_RUSSIAN" },
                        { 33, "TT_MAC_LANGID_CHINESE_SIMPLIFIED" },
                        { 34, "TT_MAC_LANGID_FLEMISH" },
                        { 35, "TT_MAC_LANGID_IRISH" },
                        { 36, "TT_MAC_LANGID_ALBANIAN" },
                        { 37, "TT_MAC_LANGID_ROMANIAN" },
                        { 38, "TT_MAC_LANGID_CZECH" },
                        { 39, "TT_MAC_LANGID_SLOVAK" },
                        { 40, "TT_MAC_LANGID_SLOVENIAN" },
                        { 41, "TT_MAC_LANGID_YIDDISH" },
                        { 42, "TT_MAC_LANGID_SERBIAN" },
                        { 43, "TT_MAC_LANGID_MACEDONIAN" },
                        { 44, "TT_MAC_LANGID_BULGARIAN" },
                        { 45, "TT_MAC_LANGID_UKRAINIAN" },
                        { 46, "TT_MAC_LANGID_BYELORUSSIAN" },
                        { 47, "TT_MAC_LANGID_UZBEK" },
                        { 48, "TT_MAC_LANGID_KAZAKH" },
                        { 49, "TT_MAC_LANGID_AZERBAIJANI" },
                        /*{ 49, "TT_MAC_LANGID_AZERBAIJANI_CYRILLIC_SCRIPT" },*/
                        { 50, "TT_MAC_LANGID_AZERBAIJANI_ARABIC_SCRIPT" },
                        { 51, "TT_MAC_LANGID_ARMENIAN" },
                        { 52, "TT_MAC_LANGID_GEORGIAN" },
                        { 53, "TT_MAC_LANGID_MOLDAVIAN" },
                        { 54, "TT_MAC_LANGID_KIRGHIZ" },
                        { 55, "TT_MAC_LANGID_TAJIKI" },
                        { 56, "TT_MAC_LANGID_TURKMEN" },
                        { 57, "TT_MAC_LANGID_MONGOLIAN" },
                        /*{ 57, "TT_MAC_LANGID_MONGOLIAN_MONGOLIAN_SCRIPT" },*/
                        { 58, "TT_MAC_LANGID_MONGOLIAN_CYRILLIC_SCRIPT" },
                        { 59, "TT_MAC_LANGID_PASHTO" },
                        { 60, "TT_MAC_LANGID_KURDISH" },
                        { 61, "TT_MAC_LANGID_KASHMIRI" },
                        { 62, "TT_MAC_LANGID_SINDHI" },
                        { 63, "TT_MAC_LANGID_TIBETAN" },
                        { 64, "TT_MAC_LANGID_NEPALI" },
                        { 65, "TT_MAC_LANGID_SANSKRIT" },
                        { 66, "TT_MAC_LANGID_MARATHI" },
                        { 67, "TT_MAC_LANGID_BENGALI" },
                        { 68, "TT_MAC_LANGID_ASSAMESE" },
                        { 69, "TT_MAC_LANGID_GUJARATI" },
                        { 70, "TT_MAC_LANGID_PUNJABI" },
                        { 71, "TT_MAC_LANGID_ORIYA" },
                        { 72, "TT_MAC_LANGID_MALAYALAM" },
                        { 73, "TT_MAC_LANGID_KANNADA" },
                        { 74, "TT_MAC_LANGID_TAMIL" },
                        { 75, "TT_MAC_LANGID_TELUGU" },
                        { 76, "TT_MAC_LANGID_SINHALESE" },
                        { 77, "TT_MAC_LANGID_BURMESE" },
                        { 78, "TT_MAC_LANGID_KHMER" },
                        { 79, "TT_MAC_LANGID_LAO" },
                        { 80, "TT_MAC_LANGID_VIETNAMESE" },
                        { 81, "TT_MAC_LANGID_INDONESIAN" },
                        { 82, "TT_MAC_LANGID_TAGALOG" },
                        { 83, "TT_MAC_LANGID_MALAY_ROMAN_SCRIPT" },
                        { 84, "TT_MAC_LANGID_MALAY_ARABIC_SCRIPT" },
                        { 85, "TT_MAC_LANGID_AMHARIC" },
                        { 86, "TT_MAC_LANGID_TIGRINYA" },
                        { 87, "TT_MAC_LANGID_GALLA" },
                        { 88, "TT_MAC_LANGID_SOMALI" },
                        { 89, "TT_MAC_LANGID_SWAHILI" },
                        { 90, "TT_MAC_LANGID_RUANDA" },
                        { 91, "TT_MAC_LANGID_RUNDI" },
                        { 92, "TT_MAC_LANGID_CHEWA" },
                        { 93, "TT_MAC_LANGID_MALAGASY" },
                        { 94, "TT_MAC_LANGID_ESPERANTO" },
                        { 128, "TT_MAC_LANGID_WELSH" },
                        { 129, "TT_MAC_LANGID_BASQUE" },
                        { 130, "TT_MAC_LANGID_CATALAN" },
                        { 131, "TT_MAC_LANGID_LATIN" },
                        { 132, "TT_MAC_LANGID_QUECHUA" },
                        { 133, "TT_MAC_LANGID_GUARANI" },
                        { 134, "TT_MAC_LANGID_AYMARA" },
                        { 135, "TT_MAC_LANGID_TATAR" },
                        { 136, "TT_MAC_LANGID_UIGHUR" },
                        { 137, "TT_MAC_LANGID_DZONGKHA" },
                        { 138, "TT_MAC_LANGID_JAVANESE" },
                        { 139, "TT_MAC_LANGID_SUNDANESE" },
                        { 140, "TT_MAC_LANGID_GALICIAN" },
                        { 141, "TT_MAC_LANGID_AFRIKAANS" },
                        { 142, "TT_MAC_LANGID_BRETON" },
                        { 143, "TT_MAC_LANGID_INUKTITUT" },
                        { 144, "TT_MAC_LANGID_SCOTTISH_GAELIC" },
                        { 145, "TT_MAC_LANGID_MANX_GAELIC" },
                        { 146, "TT_MAC_LANGID_IRISH_GAELIC" },
                        { 147, "TT_MAC_LANGID_TONGAN" },
                        { 148, "TT_MAC_LANGID_GREEK_POLYTONIC" },
                        { 149, "TT_MAC_LANGID_GREELANDIC" },
                        { 150, "TT_MAC_LANGID_AZERBAIJANI_ROMAN_SCRIPT" }
                        })
                    {
                    { 0, "TT_MAC_ID_ROMAN" },
                    { 1, "TT_MAC_ID_JAPANESE" },
                    { 2, "TT_MAC_ID_TRADITIONAL_CHINESE" },
                    { 3, "TT_MAC_ID_KOREAN" },
                    { 4, "TT_MAC_ID_ARABIC" },
                    { 5, "TT_MAC_ID_HEBREW" },
                    { 6, "TT_MAC_ID_GREEK" },
                    { 7, "TT_MAC_ID_RUSSIAN" },
                    { 8, "TT_MAC_ID_RSYMBOL" },
                    { 9, "TT_MAC_ID_DEVANAGARI" },
                    { 10, "TT_MAC_ID_GURMUKHI" },
                    { 11, "TT_MAC_ID_GUJARATI" },
                    { 12, "TT_MAC_ID_ORIYA" },
                    { 13, "TT_MAC_ID_BENGALI" },
                    { 14, "TT_MAC_ID_TAMIL" },
                    { 15, "TT_MAC_ID_TELUGU" },
                    { 16, "TT_MAC_ID_KANNADA" },
                    { 17, "TT_MAC_ID_MALAYALAM" },
                    { 18, "TT_MAC_ID_SINHALESE" },
                    { 19, "TT_MAC_ID_BURMESE" },
                    { 20, "TT_MAC_ID_KHMER" },
                    { 21, "TT_MAC_ID_THAI" },
                    { 22, "TT_MAC_ID_LAOTIAN" },
                    { 23, "TT_MAC_ID_GEORGIAN" },
                    { 24, "TT_MAC_ID_ARMENIAN" },
                    { 25, "TT_MAC_ID_MALDIVIAN" },
                    // TODO: Report a bug, same key as previous value
                    /* { 25, "TT_MAC_ID_SIMPLIFIED_CHINESE" }, */
                    { 26, "TT_MAC_ID_TIBETAN" },
                    { 27, "TT_MAC_ID_MONGOLIAN" },
                    { 28, "TT_MAC_ID_GEEZ" },
                    { 29, "TT_MAC_ID_SLAVIC" },
                    { 30, "TT_MAC_ID_VIETNAMESE" },
                    { 31, "TT_MAC_ID_SINDHI" },
                    { 32, "TT_MAC_ID_UNINTERP" }
                }},
                { PlatformId.Iso, new EncodingCollection{
                    { 0, "TT_ISO_ID_7BIT_ASCII" },
                    { 1, "TT_ISO_ID_10646" },
                    { 2, "TT_ISO_ID_8859_1" }
                }},
                { PlatformId.Microsoft, new EncodingCollection(
                    new Dictionary<ushort, string>
                        {
                        { 0x0401, "TT_MS_LANGID_ARABIC_SAUDI_ARABIA" },
                        { 0x0801, "TT_MS_LANGID_ARABIC_IRAQ" },
                        { 0x0C01, "TT_MS_LANGID_ARABIC_EGYPT" },
                        { 0x1001, "TT_MS_LANGID_ARABIC_LIBYA" },
                        { 0x1401, "TT_MS_LANGID_ARABIC_ALGERIA" },
                        { 0x1801, "TT_MS_LANGID_ARABIC_MOROCCO" },
                        { 0x1C01, "TT_MS_LANGID_ARABIC_TUNISIA" },
                        { 0x2001, "TT_MS_LANGID_ARABIC_OMAN" },
                        { 0x2401, "TT_MS_LANGID_ARABIC_YEMEN" },
                        { 0x2801, "TT_MS_LANGID_ARABIC_SYRIA" },
                        { 0x2C01, "TT_MS_LANGID_ARABIC_JORDAN" },
                        { 0x3001, "TT_MS_LANGID_ARABIC_LEBANON" },
                        { 0x3401, "TT_MS_LANGID_ARABIC_KUWAIT" },
                        { 0x3801, "TT_MS_LANGID_ARABIC_UAE" },
                        { 0x3C01, "TT_MS_LANGID_ARABIC_BAHRAIN" },
                        { 0x4001, "TT_MS_LANGID_ARABIC_QATAR" },
                        { 0x0402, "TT_MS_LANGID_BULGARIAN_BULGARIA" },
                        { 0x0403, "TT_MS_LANGID_CATALAN_CATALAN" },
                        { 0x0404, "TT_MS_LANGID_CHINESE_TAIWAN" },
                        { 0x0804, "TT_MS_LANGID_CHINESE_PRC" },
                        { 0x0C04, "TT_MS_LANGID_CHINESE_HONG_KONG" },
                        { 0x1004, "TT_MS_LANGID_CHINESE_SINGAPORE" },
                        { 0x1404, "TT_MS_LANGID_CHINESE_MACAO" },
                        { 0x0405, "TT_MS_LANGID_CZECH_CZECH_REPUBLIC" },
                        { 0x0406, "TT_MS_LANGID_DANISH_DENMARK" },
                        { 0x0407, "TT_MS_LANGID_GERMAN_GERMANY" },
                        { 0x0807, "TT_MS_LANGID_GERMAN_SWITZERLAND" },
                        { 0x0C07, "TT_MS_LANGID_GERMAN_AUSTRIA" },
                        { 0x1007, "TT_MS_LANGID_GERMAN_LUXEMBOURG" },
                        { 0x1407, "TT_MS_LANGID_GERMAN_LIECHTENSTEIN" },
                        { 0x0408, "TT_MS_LANGID_GREEK_GREECE" },
                        { 0x0409, "TT_MS_LANGID_ENGLISH_UNITED_STATES" },
                        { 0x0809, "TT_MS_LANGID_ENGLISH_UNITED_KINGDOM" },
                        { 0x0C09, "TT_MS_LANGID_ENGLISH_AUSTRALIA" },
                        { 0x1009, "TT_MS_LANGID_ENGLISH_CANADA" },
                        { 0x1409, "TT_MS_LANGID_ENGLISH_NEW_ZEALAND" },
                        { 0x1809, "TT_MS_LANGID_ENGLISH_IRELAND" },
                        { 0x1C09, "TT_MS_LANGID_ENGLISH_SOUTH_AFRICA" },
                        { 0x2009, "TT_MS_LANGID_ENGLISH_JAMAICA" },
                        { 0x2409, "TT_MS_LANGID_ENGLISH_CARIBBEAN" },
                        { 0x2809, "TT_MS_LANGID_ENGLISH_BELIZE" },
                        { 0x2C09, "TT_MS_LANGID_ENGLISH_TRINIDAD" },
                        { 0x3009, "TT_MS_LANGID_ENGLISH_ZIMBABWE" },
                        { 0x3409, "TT_MS_LANGID_ENGLISH_PHILIPPINES" },
                        { 0x4009, "TT_MS_LANGID_ENGLISH_INDIA" },
                        { 0x4409, "TT_MS_LANGID_ENGLISH_MALAYSIA" },
                        { 0x4809, "TT_MS_LANGID_ENGLISH_SINGAPORE" },
                        { 0x040A, "TT_MS_LANGID_SPANISH_SPAIN_TRADITIONAL_SORT" },
                        { 0x080A, "TT_MS_LANGID_SPANISH_MEXICO" },
                        { 0x0C0A, "TT_MS_LANGID_SPANISH_SPAIN_MODERN_SORT" },
                        { 0x100A, "TT_MS_LANGID_SPANISH_GUATEMALA" },
                        { 0x140A, "TT_MS_LANGID_SPANISH_COSTA_RICA" },
                        { 0x180A, "TT_MS_LANGID_SPANISH_PANAMA" },
                        { 0x1C0A, "TT_MS_LANGID_SPANISH_DOMINICAN_REPUBLIC" },
                        { 0x200A, "TT_MS_LANGID_SPANISH_VENEZUELA" },
                        { 0x240A, "TT_MS_LANGID_SPANISH_COLOMBIA" },
                        { 0x280A, "TT_MS_LANGID_SPANISH_PERU" },
                        { 0x2C0A, "TT_MS_LANGID_SPANISH_ARGENTINA" },
                        { 0x300A, "TT_MS_LANGID_SPANISH_ECUADOR" },
                        { 0x340A, "TT_MS_LANGID_SPANISH_CHILE" },
                        { 0x380A, "TT_MS_LANGID_SPANISH_URUGUAY" },
                        { 0x3C0A, "TT_MS_LANGID_SPANISH_PARAGUAY" },
                        { 0x400A, "TT_MS_LANGID_SPANISH_BOLIVIA" },
                        { 0x440A, "TT_MS_LANGID_SPANISH_EL_SALVADOR" },
                        { 0x480A, "TT_MS_LANGID_SPANISH_HONDURAS" },
                        { 0x4C0A, "TT_MS_LANGID_SPANISH_NICARAGUA" },
                        { 0x500A, "TT_MS_LANGID_SPANISH_PUERTO_RICO" },
                        { 0x540A, "TT_MS_LANGID_SPANISH_UNITED_STATES" },
                        { 0x040B, "TT_MS_LANGID_FINNISH_FINLAND" },
                        { 0x040C, "TT_MS_LANGID_FRENCH_FRANCE" },
                        { 0x080C, "TT_MS_LANGID_FRENCH_BELGIUM" },
                        { 0x0C0C, "TT_MS_LANGID_FRENCH_CANADA" },
                        { 0x100C, "TT_MS_LANGID_FRENCH_SWITZERLAND" },
                        { 0x140C, "TT_MS_LANGID_FRENCH_LUXEMBOURG" },
                        { 0x180C, "TT_MS_LANGID_FRENCH_MONACO" },
                        { 0x040D, "TT_MS_LANGID_HEBREW_ISRAEL" },
                        { 0x040E, "TT_MS_LANGID_HUNGARIAN_HUNGARY" },
                        { 0x040F, "TT_MS_LANGID_ICELANDIC_ICELAND" },
                        { 0x0410, "TT_MS_LANGID_ITALIAN_ITALY" },
                        { 0x0810, "TT_MS_LANGID_ITALIAN_SWITZERLAND" },
                        { 0x0411, "TT_MS_LANGID_JAPANESE_JAPAN" },
                        { 0x0412, "TT_MS_LANGID_KOREAN_KOREA" },
                        { 0x0413, "TT_MS_LANGID_DUTCH_NETHERLANDS" },
                        { 0x0813, "TT_MS_LANGID_DUTCH_BELGIUM" },
                        { 0x0414, "TT_MS_LANGID_NORWEGIAN_NORWAY_BOKMAL" },
                        { 0x0814, "TT_MS_LANGID_NORWEGIAN_NORWAY_NYNORSK" },
                        { 0x0415, "TT_MS_LANGID_POLISH_POLAND" },
                        { 0x0416, "TT_MS_LANGID_PORTUGUESE_BRAZIL" },
                        { 0x0816, "TT_MS_LANGID_PORTUGUESE_PORTUGAL" },
                        { 0x0417, "TT_MS_LANGID_ROMANSH_SWITZERLAND" },
                        { 0x0418, "TT_MS_LANGID_ROMANIAN_ROMANIA" },
                        { 0x0419, "TT_MS_LANGID_RUSSIAN_RUSSIA" },
                        { 0x041A, "TT_MS_LANGID_CROATIAN_CROATIA" },
                        { 0x081A, "TT_MS_LANGID_SERBIAN_SERBIA_LATIN" },
                        { 0x0C1A, "TT_MS_LANGID_SERBIAN_SERBIA_CYRILLIC" },
                        { 0x101A, "TT_MS_LANGID_CROATIAN_BOSNIA_HERZEGOVINA" },
                        { 0x141A, "TT_MS_LANGID_BOSNIAN_BOSNIA_HERZEGOVINA" },
                        { 0x181A, "TT_MS_LANGID_SERBIAN_BOSNIA_HERZ_LATIN" },
                        { 0x1C1A, "TT_MS_LANGID_SERBIAN_BOSNIA_HERZ_CYRILLIC" },
                        { 0x201A, "TT_MS_LANGID_BOSNIAN_BOSNIA_HERZ_CYRILLIC" },
                        { 0x041B, "TT_MS_LANGID_SLOVAK_SLOVAKIA" },
                        { 0x041C, "TT_MS_LANGID_ALBANIAN_ALBANIA" },
                        { 0x041D, "TT_MS_LANGID_SWEDISH_SWEDEN" },
                        { 0x081D, "TT_MS_LANGID_SWEDISH_FINLAND" },
                        { 0x041E, "TT_MS_LANGID_THAI_THAILAND" },
                        { 0x041F, "TT_MS_LANGID_TURKISH_TURKEY" },
                        { 0x0420, "TT_MS_LANGID_URDU_PAKISTAN" },
                        { 0x0421, "TT_MS_LANGID_INDONESIAN_INDONESIA" },
                        { 0x0422, "TT_MS_LANGID_UKRAINIAN_UKRAINE" },
                        { 0x0423, "TT_MS_LANGID_BELARUSIAN_BELARUS" },
                        { 0x0424, "TT_MS_LANGID_SLOVENIAN_SLOVENIA" },
                        { 0x0425, "TT_MS_LANGID_ESTONIAN_ESTONIA" },
                        { 0x0426, "TT_MS_LANGID_LATVIAN_LATVIA" },
                        { 0x0427, "TT_MS_LANGID_LITHUANIAN_LITHUANIA" },
                        { 0x0428, "TT_MS_LANGID_TAJIK_TAJIKISTAN" },
                        { 0x042A, "TT_MS_LANGID_VIETNAMESE_VIET_NAM" },
                        { 0x042B, "TT_MS_LANGID_ARMENIAN_ARMENIA" },
                        { 0x042C, "TT_MS_LANGID_AZERI_AZERBAIJAN_LATIN" },
                        { 0x082C, "TT_MS_LANGID_AZERI_AZERBAIJAN_CYRILLIC" },
                        { 0x042D, "TT_MS_LANGID_BASQUE_BASQUE" },
                        { 0x042E, "TT_MS_LANGID_UPPER_SORBIAN_GERMANY" },
                        { 0x082E, "TT_MS_LANGID_LOWER_SORBIAN_GERMANY" },
                        { 0x042F, "TT_MS_LANGID_MACEDONIAN_MACEDONIA" },
                        { 0x0432, "TT_MS_LANGID_SETSWANA_SOUTH_AFRICA" },
                        { 0x0434, "TT_MS_LANGID_ISIXHOSA_SOUTH_AFRICA" },
                        { 0x0435, "TT_MS_LANGID_ISIZULU_SOUTH_AFRICA" },
                        { 0x0436, "TT_MS_LANGID_AFRIKAANS_SOUTH_AFRICA" },
                        { 0x0437, "TT_MS_LANGID_GEORGIAN_GEORGIA" },
                        { 0x0438, "TT_MS_LANGID_FAEROESE_FAEROE_ISLANDS" },
                        { 0x0439, "TT_MS_LANGID_HINDI_INDIA" },
                        { 0x043A, "TT_MS_LANGID_MALTESE_MALTA" },
                        { 0x043B, "TT_MS_LANGID_SAMI_NORTHERN_NORWAY" },
                        { 0x083B, "TT_MS_LANGID_SAMI_NORTHERN_SWEDEN" },
                        { 0x0C3B, "TT_MS_LANGID_SAMI_NORTHERN_FINLAND" },
                        { 0x103B, "TT_MS_LANGID_SAMI_LULE_NORWAY" },
                        { 0x143B, "TT_MS_LANGID_SAMI_LULE_SWEDEN" },
                        { 0x183B, "TT_MS_LANGID_SAMI_SOUTHERN_NORWAY" },
                        { 0x1C3B, "TT_MS_LANGID_SAMI_SOUTHERN_SWEDEN" },
                        { 0x203B, "TT_MS_LANGID_SAMI_SKOLT_FINLAND" },
                        { 0x243B, "TT_MS_LANGID_SAMI_INARI_FINLAND" },
                        { 0x083C, "TT_MS_LANGID_IRISH_IRELAND" },
                        { 0x043E, "TT_MS_LANGID_MALAY_MALAYSIA" },
                        { 0x083E, "TT_MS_LANGID_MALAY_BRUNEI_DARUSSALAM" },
                        { 0x043F, "TT_MS_LANGID_KAZAKH_KAZAKHSTAN" },
                        { 0x0440, "TT_MS_LANGID_KYRGYZ_KYRGYZSTAN" },
                        { 0x0441, "TT_MS_LANGID_KISWAHILI_KENYA" },
                        { 0x0442, "TT_MS_LANGID_TURKMEN_TURKMENISTAN" },
                        { 0x0443, "TT_MS_LANGID_UZBEK_UZBEKISTAN_LATIN" },
                        { 0x0843, "TT_MS_LANGID_UZBEK_UZBEKISTAN_CYRILLIC" },
                        { 0x0444, "TT_MS_LANGID_TATAR_RUSSIA" },
                        { 0x0445, "TT_MS_LANGID_BENGALI_INDIA" },
                        { 0x0845, "TT_MS_LANGID_BENGALI_BANGLADESH" },
                        { 0x0446, "TT_MS_LANGID_PUNJABI_INDIA" },
                        { 0x0447, "TT_MS_LANGID_GUJARATI_INDIA" },
                        { 0x0448, "TT_MS_LANGID_ODIA_INDIA" },
                        { 0x0449, "TT_MS_LANGID_TAMIL_INDIA" },
                        { 0x044A, "TT_MS_LANGID_TELUGU_INDIA" },
                        { 0x044B, "TT_MS_LANGID_KANNADA_INDIA" },
                        { 0x044C, "TT_MS_LANGID_MALAYALAM_INDIA" },
                        { 0x044D, "TT_MS_LANGID_ASSAMESE_INDIA" },
                        { 0x044E, "TT_MS_LANGID_MARATHI_INDIA" },
                        { 0x044F, "TT_MS_LANGID_SANSKRIT_INDIA" },
                        { 0x0450, "TT_MS_LANGID_MONGOLIAN_MONGOLIA" },
                        { 0x0850, "TT_MS_LANGID_MONGOLIAN_PRC" },
                        { 0x0451, "TT_MS_LANGID_TIBETAN_PRC" },
                        { 0x0452, "TT_MS_LANGID_WELSH_UNITED_KINGDOM" },
                        { 0x0453, "TT_MS_LANGID_KHMER_CAMBODIA" },
                        { 0x0454, "TT_MS_LANGID_LAO_LAOS" },
                        { 0x0456, "TT_MS_LANGID_GALICIAN_GALICIAN" },
                        { 0x0457, "TT_MS_LANGID_KONKANI_INDIA" },
                        { 0x045A, "TT_MS_LANGID_SYRIAC_SYRIA" },
                        { 0x045B, "TT_MS_LANGID_SINHALA_SRI_LANKA" },
                        { 0x045D, "TT_MS_LANGID_INUKTITUT_CANADA" },
                        { 0x085D, "TT_MS_LANGID_INUKTITUT_CANADA_LATIN" },
                        { 0x045E, "TT_MS_LANGID_AMHARIC_ETHIOPIA" },
                        { 0x085F, "TT_MS_LANGID_TAMAZIGHT_ALGERIA" },
                        { 0x0461, "TT_MS_LANGID_NEPALI_NEPAL" },
                        { 0x0462, "TT_MS_LANGID_FRISIAN_NETHERLANDS" },
                        { 0x0463, "TT_MS_LANGID_PASHTO_AFGHANISTAN" },
                        { 0x0464, "TT_MS_LANGID_FILIPINO_PHILIPPINES" },
                        { 0x0465, "TT_MS_LANGID_DHIVEHI_MALDIVES" },
                        { 0x0468, "TT_MS_LANGID_HAUSA_NIGERIA" },
                        { 0x046A, "TT_MS_LANGID_YORUBA_NIGERIA" },
                        { 0x046B, "TT_MS_LANGID_QUECHUA_BOLIVIA" },
                        { 0x086B, "TT_MS_LANGID_QUECHUA_ECUADOR" },
                        { 0x0C6B, "TT_MS_LANGID_QUECHUA_PERU" },
                        { 0x046C, "TT_MS_LANGID_SESOTHO_SA_LEBOA_SOUTH_AFRICA" },
                        { 0x046D, "TT_MS_LANGID_BASHKIR_RUSSIA" },
                        { 0x046E, "TT_MS_LANGID_LUXEMBOURGISH_LUXEMBOURG" },
                        { 0x046F, "TT_MS_LANGID_GREENLANDIC_GREENLAND" },
                        { 0x0470, "TT_MS_LANGID_IGBO_NIGERIA" },
                        { 0x0478, "TT_MS_LANGID_YI_PRC" },
                        { 0x047A, "TT_MS_LANGID_MAPUDUNGUN_CHILE" },
                        { 0x047C, "TT_MS_LANGID_MOHAWK_MOHAWK" },
                        { 0x047E, "TT_MS_LANGID_BRETON_FRANCE" },
                        { 0x0480, "TT_MS_LANGID_UIGHUR_PRC" },
                        { 0x0481, "TT_MS_LANGID_MAORI_NEW_ZEALAND" },
                        { 0x0482, "TT_MS_LANGID_OCCITAN_FRANCE" },
                        { 0x0483, "TT_MS_LANGID_CORSICAN_FRANCE" },
                        { 0x0484, "TT_MS_LANGID_ALSATIAN_FRANCE" },
                        { 0x0485, "TT_MS_LANGID_YAKUT_RUSSIA" },
                        { 0x0486, "TT_MS_LANGID_KICHE_GUATEMALA" },
                        { 0x0487, "TT_MS_LANGID_KINYARWANDA_RWANDA" },
                        { 0x0488, "TT_MS_LANGID_WOLOF_SENEGAL" },
                        { 0x048C, "TT_MS_LANGID_DARI_AFGHANISTAN" }
                        })
                    {
                    { 0, "TT_MS_ID_SYMBOL_CS" },
                    { 1, "TT_MS_ID_UNICODE_CS" },
                    { 2, "TT_MS_ID_SJIS" },
                    { 3, "TT_MS_ID_PRC" },
                    { 4, "TT_MS_ID_BIG_5" },
                    { 5, "TT_MS_ID_WANSUNG" },
                    { 6, "TT_MS_ID_JOHAB" },
                    { 10, "TT_MS_ID_UCS_4" }
                }},
                { PlatformId.Custom, new EncodingCollection{
                    /* Custom */ 
                }},
                { PlatformId.Adobe, new EncodingCollection{
                    { 0, "TT_ADOBE_ID_STANDARD" },
                    { 1, "TT_ADOBE_ID_EXPERT" },
                    { 2, "TT_ADOBE_ID_CUSTOM" },
                    { 3, "TT_ADOBE_ID_LATIN_1" }
                }}
            };

        public static Dictionary<ushort, string> NameIds =>
             new Dictionary<ushort, string>
             {
                { 0, "TT_NAME_ID_COPYRIGHT" },
                { 1, "TT_NAME_ID_FONT_FAMILY" },
                { 2, "TT_NAME_ID_FONT_SUBFAMILY" },
                { 3, "TT_NAME_ID_UNIQUE_ID" },
                { 4, "TT_NAME_ID_FULL_NAME" },
                { 5, "TT_NAME_ID_VERSION_STRING" },
                { 6, "TT_NAME_ID_PS_NAME" },
                { 7, "TT_NAME_ID_TRADEMARK" },

                  /* the following values are from the OpenType spec */
                { 8, "TT_NAME_ID_MANUFACTURER" },
                { 9, "TT_NAME_ID_DESIGNER" },
                { 10, "TT_NAME_ID_DESCRIPTION" },
                { 11, "TT_NAME_ID_VENDOR_URL" },
                { 12, "TT_NAME_ID_DESIGNER_URL" },
                { 13, "TT_NAME_ID_LICENSE" },
                { 14, "TT_NAME_ID_LICENSE_URL" },
                  /* number 15 is reserved */
                { 16, "TT_NAME_ID_TYPOGRAPHIC_FAMILY" },
                { 17, "TT_NAME_ID_TYPOGRAPHIC_SUBFAMILY" },
                { 18, "TT_NAME_ID_MAC_FULL_NAME" },

                  /* The following code is new as of 2000-01-21 */
                { 19, "TT_NAME_ID_SAMPLE_TEXT" },

                  /* This is new in OpenType 1.3 */
                { 20, "TT_NAME_ID_CID_FINDFONT_NAME" },

                  /* This is new in OpenType 1.5 */
                { 21, "TT_NAME_ID_WWS_FAMILY" },
                { 22, "TT_NAME_ID_WWS_SUBFAMILY" },

                  /* This is new in OpenType 1.7 */
                { 23, "TT_NAME_ID_LIGHT_BACKGROUND" },
                { 24, "TT_NAME_ID_DARK_BACKGROUND" },

                  /* This is new in OpenType 1.8 */
                { 25, "TT_NAME_ID_VARIATIONS_PREFIX" }
             };


        internal class EncodingCollection : Dictionary<ushort, string>
        {
            public Dictionary<ushort, string> Languages { get; }

            public EncodingCollection(): base()
            {
                this.Languages = new Dictionary<ushort, string>();
            }

            public EncodingCollection(Dictionary<ushort, string> langs) : base()
            {
                this.Languages = langs;
            }
        }
    }
}