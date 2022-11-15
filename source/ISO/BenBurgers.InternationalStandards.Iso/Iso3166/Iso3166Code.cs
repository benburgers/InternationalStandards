/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.Iso3166.Attributes;

namespace BenBurgers.InternationalStandards.Iso.Iso3166;

/// <summary>
/// An <a href="https://www.iso.org/iso-3166-country-codes.html">ISO 3166</a> Country Code.
/// </summary>
/// <remarks>
/// <para>
/// The <a href="https://www.iso.org/iso-3166-country-codes.html">ISO 3166 Maintenance Agency</a> is the sole authority of ISO 3166 codes.
/// Only they can designate ISO 3166 codes. This work is a derivation and enhancement and anything other than ISO 3166 is the responsibility of the respective copyright holders.
/// </para>
/// <para>
/// If you notice any mistake in this work, please create a Pull Request or notify the repository owner or a contributor as soon as possible.
/// </para>
/// <para>
/// Extension methods from <see cref="Iso3166CodeExtensions" /> enable conversion from and to <see cref="Iso3166Code" />.<br />
/// To convert from an Alpha code in a <see cref="string" />, use the extension method <see cref="Iso3166CodeExtensions.ToIso3166(string)" />.
/// </para>
/// </remarks>
public enum Iso3166Code
{
    /// <summary>
    /// Afghanistan.
    /// </summary>
    /// <remarks>
    ///     <list type="table">
    ///         <item><term>Numeric</term><description>004</description></item>
    ///         <item><term>Alpha-2</term><description>AF</description></item>
    ///         <item><term>Alpha-3</term><description>AFG</description></item>
    ///     </list>
    /// </remarks>
    [Iso3166("AF", "AFG")]
    Afghanistan = 004,

    /// <summary>
    /// Albania.
    /// </summary>
    /// <remarks>
    ///     <list type="table">
    ///         <item><term>Numeric</term><description>008</description></item>
    ///         <item><term>Alpha-2</term><description>AL</description></item>
    ///         <item><term>Alpha-3</term><description>ALB</description></item>
    ///     </list>
    /// </remarks>
    [Iso3166("AL", "ALB")]
    Albania = 008,

    /// <summary>
    /// Algeria.
    /// </summary>
    /// <remarks>
    ///     <list type="table">
    ///         <item><term>Numeric</term><description>012</description></item>
    ///         <item><term>Alpha-2</term><description>DZ</description></item>
    ///         <item><term>Alpha-3</term><description>DZA</description></item>
    ///     </list>
    /// </remarks>
    [Iso3166("DZ", "DZA")]
    Algeria = 012,

    /// <summary>
    /// American Samoa.
    /// </summary>
    /// <remarks>
    ///     <list type="table">
    ///         <item><term>Numeric</term><description>016</description></item>
    ///         <item><term>Alpha-2</term><description>AS</description></item>
    ///         <item><term>Alpha-3</term><description>ASM</description></item>
    ///     </list>
    /// </remarks>
    [Iso3166("AS", "ASM")]
    AmericanSamoa = 016,

    /// <summary>
    /// Andorra.
    /// </summary>
    /// <remarks>
    ///     <list type="table">
    ///         <item><term>Numeric</term><description>020</description></item>
    ///         <item><term>Alpha-2</term><description>AD</description></item>
    ///         <item><term>Alpha-3</term><description>AND</description></item>
    ///     </list>
    /// </remarks>
    [Iso3166("AD", "AND")]
    Andorra = 020,

    /// <summary>
    /// Angola.
    /// </summary>
    /// <remarks>
    ///     <list type="table">
    ///         <item><term>Numeric</term><description>024</description></item>
    ///         <item><term>Alpha-2</term><description>AO</description></item>
    ///         <item><term>Alpha-3</term><description>AGO</description></item>
    ///     </list>
    /// </remarks>
    [Iso3166("AO", "AGO")]
    Angola = 024,

    /// <summary>
    /// Anguilla.
    /// </summary>
    /// <remarks>
    ///     <list type="table">
    ///         <item><term>Numeric</term><description>660</description></item>
    ///         <item><term>Alpha-2</term><description>AI</description></item>
    ///         <item><term>Alpha-3</term><description>AIA</description></item>
    ///     </list>
    /// </remarks>
    [Iso3166("AI", "AIA")]
    Anguilla = 660,

    /// <summary>
    /// Antarctica.
    /// </summary>
    /// <remarks>
    ///     <list type="table">
    ///         <item><term>Numeric</term><description>010</description></item>
    ///         <item><term>Alpha-2</term><description>AQ</description></item>
    ///         <item><term>Alpha-3</term><description>ATA</description></item>
    ///     </list>
    /// </remarks>
    [Iso3166("AQ", "ATA")]
    Antarctica = 010,

    /// <summary>
    /// Antigua and Barbuda.
    /// </summary>
    /// <remarks>
    ///     <list type="table">
    ///         <item><term>Numeric</term><description>028</description></item>
    ///         <item><term>Alpha-2</term><description>AG</description></item>
    ///         <item><term>Alpha-3</term><description>ATG</description></item>
    ///     </list>
    /// </remarks>
    [Iso3166("AG", "ATG")]
    AntiguaAndBarbuda = 028,

    /// <summary>
    /// Argentina.
    /// </summary>
    /// <remarks>
    ///     <list type="table">
    ///         <item><term>Numeric</term><description>032</description></item>
    ///         <item><term>Alpha-2</term><description>AR</description></item>
    ///         <item><term>Alpha-3</term><description>ARG</description></item>
    ///     </list>
    /// </remarks>
    [Iso3166("AR", "ARG")]
    Argentina = 032,

    /// <summary>
    /// Armenia.
    /// </summary>
    /// <remarks>
    ///     <list type="table">
    ///         <item><term>Numeric</term><description>051</description></item>
    ///         <item><term>Alpha-2</term><description>AM</description></item>
    ///         <item><term>Alpha-3</term><description>ARM</description></item>
    ///     </list>
    /// </remarks>
    [Iso3166("AM", "ARM")]
    Armenia = 051,

    /// <summary>
    /// Aruba.
    /// </summary>
    /// <remarks>
    ///     <list type="table">
    ///         <item><term>Numeric</term><description>533</description></item>
    ///         <item><term>Alpha-2</term><description>AW</description></item>
    ///         <item><term>Alpha-3</term><description>ABW</description></item>
    ///     </list>
    /// </remarks>
    [Iso3166("AW", "ABW")]
    Aruba = 533,

    /// <summary>
    /// Australia.
    /// </summary>
    /// <remarks>
    ///     <list type="table">
    ///         <item><term>Numeric</term><description>036</description></item>
    ///         <item><term>Alpha-2</term><description>AU</description></item>
    ///         <item><term>Alpha-3</term><description>AUS</description></item>
    ///     </list>
    /// </remarks>
    [Iso3166("AU", "AUS")]
    Australia = 036,

    /// <summary>
    /// Austria.
    /// </summary>
    /// <remarks>
    ///     <list type="table">
    ///         <item><term>Numeric</term><description>040</description></item>
    ///         <item><term>Alpha-2</term><description>AT</description></item>
    ///         <item><term>Alpha-3</term><description>AUT</description></item>
    ///     </list>
    /// </remarks>
    [Iso3166("AT", "AUT")]
    Austria = 040,

    /// <summary>
    /// Azerbaijan.
    /// </summary>
    /// <remarks>
    ///     <list type="table">
    ///         <item><term>Numeric</term><description>031</description></item>
    ///         <item><term>Alpha-2</term><description>AZ</description></item>
    ///         <item><term>Alpha-3</term><description>AZE</description></item>
    ///     </list>
    /// </remarks>
    [Iso3166("AZ", "AZE")]
    Azerbaijan = 031,

    /// <summary>
    /// Bahamas (the).
    /// </summary>
    /// <remarks>
    ///     <list type="table">
    ///         <item><term>Numeric</term><description>044</description></item>
    ///         <item><term>Alpha-2</term><description>BS</description></item>
    ///         <item><term>Alpha-3</term><description>BHS</description></item>
    ///     </list>
    /// </remarks>
    [Iso3166("BS", "BHS")]
    Bahamas = 044,

    /// <summary>
    /// Bahrain.
    /// </summary>
    /// <remarks>
    ///     <list type="table">
    ///         <item><term>Numeric</term><description>048</description></item>
    ///         <item><term>Alpha-2</term><description>BH</description></item>
    ///         <item><term>Alpha-3</term><description>BHR</description></item>
    ///     </list>
    /// </remarks>
    [Iso3166("BH", "BHR")]
    Bahrain = 048,

    /// <summary>
    /// Bangladesh.
    /// </summary>
    /// <remarks>
    ///     <list type="table">
    ///         <item><term>Numeric</term><description>050</description></item>
    ///         <item><term>Alpha-2</term><description>BD</description></item>
    ///         <item><term>Alpha-3</term><description>BGD</description></item>
    ///     </list>
    /// </remarks>
    [Iso3166("BD", "BGD")]
    Bangladesh = 050,

    /// <summary>
    /// Barbados.
    /// </summary>
    /// <remarks>
    ///     <list type="table">
    ///         <item><term>Numeric</term><description>052</description></item>
    ///         <item><term>Alpha-2</term><description>BB</description></item>
    ///         <item><term>Alpha-3</term><description>BRB</description></item>
    ///     </list>
    /// </remarks>
    [Iso3166("BB", "BRB")]
    Barbados = 052,

    /// <summary>
    /// Belarus.
    /// </summary>
    /// <remarks>
    ///     <list type="table">
    ///         <item><term>Numeric</term><description>112</description></item>
    ///         <item><term>Alpha-2</term><description>BY</description></item>
    ///         <item><term>Alpha-3</term><description>BLR</description></item>
    ///     </list>
    /// </remarks>
    [Iso3166("BY", "BLR")]
    Belarus = 112,

    /// <summary>
    /// Belgium.
    /// </summary>
    /// <remarks>
    ///     <list type="table">
    ///         <item><term>Numeric</term><description>056</description></item>
    ///         <item><term>Alpha-2</term><description>BE</description></item>
    ///         <item><term>Alpha-3</term><description>BEL</description></item>
    ///     </list>
    /// </remarks>
    [Iso3166("BE", "BEL")]
    Belgium = 056,

    /// <summary>
    /// Belize.
    /// </summary>
    /// <remarks>
    ///     <list type="table">
    ///         <item><term>Numeric</term><description>084</description></item>
    ///         <item><term>Alpha-2</term><description>BZ</description></item>
    ///         <item><term>Alpha-3</term><description>BLZ</description></item>
    ///     </list>
    /// </remarks>
    [Iso3166("BZ", "BLZ")]
    Belize = 084,

    /// <summary>
    /// Benin.
    /// </summary>
    /// <remarks>
    ///     <list type="table">
    ///         <item><term>Numeric</term><description>204</description></item>
    ///         <item><term>Alpha-2</term><description>BJ</description></item>
    ///         <item><term>Alpha-3</term><description>BEN</description></item>
    ///     </list>
    /// </remarks>
    [Iso3166("BJ", "BEN")]
    Benin = 204,

    /// <summary>
    /// Bermuda.
    /// </summary>
    /// <remarks>
    ///     <list type="table">
    ///         <item><term>Numeric</term><description>060</description></item>
    ///         <item><term>Alpha-2</term><description>BM</description></item>
    ///         <item><term>Alpha-3</term><description>BMU</description></item>
    ///     </list>
    /// </remarks>
    [Iso3166("BM", "BMU")]
    Bermuda = 060,

    /// <summary>
    /// Åland Islands.
    /// </summary>
    /// <remarks>
    ///     <list type="table">
    ///         <item><term>Numeric</term><description>248</description></item>
    ///         <item><term>Alpha-2</term><description>AX</description></item>
    ///         <item><term>Alpha-3</term><description>ALA</description></item>
    ///     </list>
    /// </remarks>
    [Iso3166("AX", "ALA")]
    ÅlandIslands = 248,

    /// <summary>
    /// Bhutan.
    /// </summary>
    /// <remarks>
    ///     <list type="table">
    ///         <item><term>Numeric</term><description>064</description></item>
    ///         <item><term>Alpha-2</term><description>BT</description></item>
    ///         <item><term>Alpha-3</term><description>BTN</description></item>
    ///     </list>
    /// </remarks>
    [Iso3166("BT", "BTN")]
    Bhutan = 064,

    /// <summary>
    /// Bolivia (Plurinational State of).
    /// </summary>
    /// <remarks>
    ///     <list type="table">
    ///         <item><term>Numeric</term><description>068</description></item>
    ///         <item><term>Alpha-2</term><description>BO</description></item>
    ///         <item><term>Alpha-3</term><description>BOL</description></item>
    ///     </list>
    /// </remarks>
    [Iso3166("BO", "BOL")]
    Bolivia = 068,

    /// <summary>
    /// Bonaire, Sint Eustatius and Saba.
    /// </summary>
    /// <remarks>
    ///     <list type="table">
    ///         <item><term>Numeric</term><description>535</description></item>
    ///         <item><term>Alpha-2</term><description>BQ</description></item>
    ///         <item><term>Alpha-3</term><description>BES</description></item>
    ///     </list>
    /// </remarks>
    [Iso3166("BQ", "BES")]
    BonaireSintEustatiusAndSaba = 535,

    /// <summary>
    /// Bosnia and Herzegovina.
    /// </summary>
    /// <remarks>
    ///     <list type="table">
    ///         <item><term>Numeric</term><description>070</description></item>
    ///         <item><term>Alpha-2</term><description>BA</description></item>
    ///         <item><term>Alpha-3</term><description>BIH</description></item>
    ///     </list>
    /// </remarks>
    [Iso3166("BA", "BIH")]
    BosniaAndHerzegovina = 070,

    /// <summary>
    /// Botswana.
    /// </summary>
    /// <remarks>
    ///     <list type="table">
    ///         <item><term>Numeric</term><description>072</description></item>
    ///         <item><term>Alpha-2</term><description>BW</description></item>
    ///         <item><term>Alpha-3</term><description>BWA</description></item>
    ///     </list>
    /// </remarks>
    [Iso3166("BW", "BWA")]
    Botswana = 072,

    /// <summary>
    /// Bouvet Island.
    /// </summary>
    /// <remarks>
    ///     <list type="table">
    ///         <item><term>Numeric</term><description>074</description></item>
    ///         <item><term>Alpha-2</term><description>BV</description></item>
    ///         <item><term>Alpha-3</term><description>BVT</description></item>
    ///     </list>
    /// </remarks>
    [Iso3166("BV", "BVT")]
    BouvetIsland = 074,

    /// <summary>
    /// Brazil.
    /// </summary>
    /// <remarks>
    ///     <list type="table">
    ///         <item><term>Numeric</term><description>076</description></item>
    ///         <item><term>Alpha-2</term><description>BR</description></item>
    ///         <item><term>Alpha-3</term><description>BRA</description></item>
    ///     </list>
    /// </remarks>
    [Iso3166("BR", "BRA")]
    Brazil = 076,

    /// <summary>
    /// British Indian Ocean Territory (the).
    /// </summary>
    /// <remarks>
    ///     <list type="table">
    ///         <item><term>Numeric</term><description>086</description></item>
    ///         <item><term>Alpha-2</term><description>IO</description></item>
    ///         <item><term>Alpha-3</term><description>IOT</description></item>
    ///     </list>
    /// </remarks>
    [Iso3166("IO", "IOT")]
    BritishIndianOceanTerritory = 086,

    /// <summary>
    /// Brunei Darussalam.
    /// </summary>
    /// <remarks>
    ///     <list type="table">
    ///         <item><term>Numeric</term><description>096</description></item>
    ///         <item><term>Alpha-2</term><description>BN</description></item>
    ///         <item><term>Alpha-3</term><description>BRN</description></item>
    ///     </list>
    /// </remarks>
    [Iso3166("BN", "BRN")]
    BruneiDarussalam = 096,

    /// <summary>
    /// Bulgaria.
    /// </summary>
    /// <remarks>
    ///     <list type="table">
    ///         <item><term>Numeric</term><description>100</description></item>
    ///         <item><term>Alpha-2</term><description>BG</description></item>
    ///         <item><term>Alpha-3</term><description>BGR</description></item>
    ///     </list>
    /// </remarks>
    [Iso3166("BG", "BGR")]
    Bulgaria = 100,

    /// <summary>
    /// Burkina Faso.
    /// </summary>
    /// <remarks>
    ///     <list type="table">
    ///         <item><term>Numeric</term><description>854</description></item>
    ///         <item><term>Alpha-2</term><description>BF</description></item>
    ///         <item><term>Alpha-3</term><description>BFA</description></item>
    ///     </list>
    /// </remarks>
    [Iso3166("BF", "BFA")]
    BurkinaFaso = 854,

    /// <summary>
    /// Burundi.
    /// </summary>
    /// <remarks>
    ///     <list type="table">
    ///         <item><term>Numeric</term><description>108</description></item>
    ///         <item><term>Alpha-2</term><description>BI</description></item>
    ///         <item><term>Alpha-3</term><description>BDI</description></item>
    ///     </list>
    /// </remarks>
    [Iso3166("BI", "BDI")]
    Burundi = 108,

    /// <summary>
    /// Cabo Verde.
    /// </summary>
    /// <remarks>
    ///     <list type="table">
    ///         <item><term>Numeric</term><description>132</description></item>
    ///         <item><term>Alpha-2</term><description>CV</description></item>
    ///         <item><term>Alpha-3</term><description>CPV</description></item>
    ///     </list>
    /// </remarks>
    [Iso3166("CV", "CPV")]
    CaboVerde = 132,

    /// <summary>
    /// Cambodia.
    /// </summary>
    /// <remarks>
    ///     <list type="table">
    ///         <item><term>Numeric</term><description>116</description></item>
    ///         <item><term>Alpha-2</term><description>KH</description></item>
    ///         <item><term>Alpha-3</term><description>KHM</description></item>
    ///     </list>
    /// </remarks>
    [Iso3166("KH", "KHM")]
    Cambodia = 116,

    /// <summary>
    /// Cameroon.
    /// </summary>
    /// <remarks>
    ///     <list type="table">
    ///         <item><term>Numeric</term><description>120</description></item>
    ///         <item><term>Alpha-2</term><description>CM</description></item>
    ///         <item><term>Alpha-3</term><description>CMR</description></item>
    ///     </list>
    /// </remarks>
    [Iso3166("CM", "CMR")]
    Cameroon = 120,

    /// <summary>
    /// Canada.
    /// </summary>
    /// <remarks>
    ///     <list type="table">
    ///         <item><term>Numeric</term><description>124</description></item>
    ///         <item><term>Alpha-2</term><description>CA</description></item>
    ///         <item><term>Alpha-3</term><description>CAN</description></item>
    ///     </list>
    /// </remarks>
    [Iso3166("CA", "CAN")]
    Canada = 124,

    /// <summary>
    /// Cayman Islands (the).
    /// </summary>
    /// <remarks>
    ///     <list type="table">
    ///         <item><term>Numeric</term><description>136</description></item>
    ///         <item><term>Alpha-2</term><description>KY</description></item>
    ///         <item><term>Alpha-3</term><description>CYM</description></item>
    ///     </list>
    /// </remarks>
    [Iso3166("KY", "CYM")]
    CaymanIslands = 136,

    /// <summary>
    /// Central African Republic (the).
    /// </summary>
    /// <remarks>
    ///     <list type="table">
    ///         <item><term>Numeric</term><description>140</description></item>
    ///         <item><term>Alpha-2</term><description>CF</description></item>
    ///         <item><term>Alpha-3</term><description>CAF</description></item>
    ///     </list>
    /// </remarks>
    [Iso3166("CF", "CAF")]
    CentralAfricanRepublic = 140,

    /// <summary>
    /// Chad.
    /// </summary>
    /// <remarks>
    ///     <list type="table">
    ///         <item><term>Numeric</term><description>148</description></item>
    ///         <item><term>Alpha-2</term><description>TD</description></item>
    ///         <item><term>Alpha-3</term><description>TCD</description></item>
    ///     </list>
    /// </remarks>
    [Iso3166("TD", "TCD")]
    Chad = 148,

    /// <summary>
    /// Chile.
    /// </summary>
    /// <remarks>
    ///     <list type="table">
    ///         <item><term>Numeric</term><description>152</description></item>
    ///         <item><term>Alpha-2</term><description>CL</description></item>
    ///         <item><term>Alpha-3</term><description>CHL</description></item>
    ///     </list>
    /// </remarks>
    [Iso3166("CL", "CHL")]
    Chile = 152,

    /// <summary>
    /// China.
    /// </summary>
    /// <remarks>
    ///     <list type="table">
    ///         <item><term>Numeric</term><description>156</description></item>
    ///         <item><term>Alpha-2</term><description>CN</description></item>
    ///         <item><term>Alpha-3</term><description>CHN</description></item>
    ///     </list>
    /// </remarks>
    [Iso3166("CN", "CHN")]
    China = 156,

    /// <summary>
    /// Christmas Island.
    /// </summary>
    /// <remarks>
    ///     <list type="table">
    ///         <item><term>Numeric</term><description>162</description></item>
    ///         <item><term>Alpha-2</term><description>CX</description></item>
    ///         <item><term>Alpha-3</term><description>CXR</description></item>
    ///     </list>
    /// </remarks>
    [Iso3166("CX", "CXR")]
    ChristmasIsland = 162,

    /// <summary>
    /// Cocos (Keeling) Islands (the).
    /// </summary>
    /// <remarks>
    ///     <list type="table">
    ///         <item><term>Numeric</term><description>166</description></item>
    ///         <item><term>Alpha-2</term><description>CC</description></item>
    ///         <item><term>Alpha-3</term><description>CCK</description></item>
    ///     </list>
    /// </remarks>
    [Iso3166("CC", "CCK")]
    CocosIslands = 166,

    /// <summary>
    /// Colombia.
    /// </summary>
    /// <remarks>
    ///     <list type="table">
    ///         <item><term>Numeric</term><description>170</description></item>
    ///         <item><term>Alpha-2</term><description>CO</description></item>
    ///         <item><term>Alpha-3</term><description>COL</description></item>
    ///     </list>
    /// </remarks>
    [Iso3166("CO", "COL")]
    Colombia = 170,

    /// <summary>
    /// Comoros (the).
    /// </summary>
    /// <remarks>
    ///     <list type="table">
    ///         <item><term>Numeric</term><description>174</description></item>
    ///         <item><term>Alpha-2</term><description>KM</description></item>
    ///         <item><term>Alpha-3</term><description>COM</description></item>
    ///     </list>
    /// </remarks>
    [Iso3166("KM", "COM")]
    Comoros = 174,

    /// <summary>
    /// Congo (the Democratic Republic of the).
    /// </summary>
    /// <remarks>
    ///     <list type="table">
    ///         <item><term>Numeric</term><description>180</description></item>
    ///         <item><term>Alpha-2</term><description>CD</description></item>
    ///         <item><term>Alpha-3</term><description>COD</description></item>
    ///     </list>
    /// </remarks>
    [Iso3166("CD", "COD")]
    CongoDemocraticRepublic = 180,

    /// <summary>
    /// Congo (the).
    /// </summary>
    /// <remarks>
    ///     <list type="table">
    ///         <item><term>Numeric</term><description>178</description></item>
    ///         <item><term>Alpha-2</term><description>CG</description></item>
    ///         <item><term>Alpha-3</term><description>COG</description></item>
    ///     </list>
    /// </remarks>
    [Iso3166("CG", "COG")]
    Congo = 178,

    /// <summary>
    /// Cook Islands (the).
    /// </summary>
    /// <remarks>
    ///     <list type="table">
    ///         <item><term>Numeric</term><description>184</description></item>
    ///         <item><term>Alpha-2</term><description>CK</description></item>
    ///         <item><term>Alpha-3</term><description>COK</description></item>
    ///     </list>
    /// </remarks>
    [Iso3166("CK", "COK")]
    CookIslands = 184,

    /// <summary>
    /// Costa Rica.
    /// </summary>
    /// <remarks>
    ///     <list type="table">
    ///         <item><term>Numeric</term><description>188</description></item>
    ///         <item><term>Alpha-2</term><description>CR</description></item>
    ///         <item><term>Alpha-3</term><description>CRI</description></item>
    ///     </list>
    /// </remarks>
    [Iso3166("CR", "CRI")]
    CostaRica = 188,

    /// <summary>
    /// Croatia.
    /// </summary>
    /// <remarks>
    ///     <list type="table">
    ///         <item><term>Numeric</term><description>191</description></item>
    ///         <item><term>Alpha-2</term><description>HR</description></item>
    ///         <item><term>Alpha-3</term><description>HRV</description></item>
    ///     </list>
    /// </remarks>
    [Iso3166("HR", "HRV")]
    Croatia = 191,

    /// <summary>
    /// Cuba.
    /// </summary>
    /// <remarks>
    ///     <list type="table">
    ///         <item><term>Numeric</term><description>192</description></item>
    ///         <item><term>Alpha-2</term><description>CU</description></item>
    ///         <item><term>Alpha-3</term><description>CUB</description></item>
    ///     </list>
    /// </remarks>
    [Iso3166("CU", "CUB")]
    Cuba = 192,

    /// <summary>
    /// Curaçao.
    /// </summary>
    /// <remarks>
    ///     <list type="table">
    ///         <item><term>Numeric</term><description>531</description></item>
    ///         <item><term>Alpha-2</term><description>CW</description></item>
    ///         <item><term>Alpha-3</term><description>CUW</description></item>
    ///     </list>
    /// </remarks>
    [Iso3166("CW", "CUW")]
    Curaçao = 531,

    /// <summary>
    /// Cyprus.
    /// </summary>
    /// <remarks>
    ///     <list type="table">
    ///         <item><term>Numeric</term><description>196</description></item>
    ///         <item><term>Alpha-2</term><description>CY</description></item>
    ///         <item><term>Alpha-3</term><description>CYP</description></item>
    ///     </list>
    /// </remarks>
    [Iso3166("CY", "CYP")]
    Cyprus = 196,

    /// <summary>
    /// Czechia.
    /// </summary>
    /// <remarks>
    ///     <list type="table">
    ///         <item><term>Numeric</term><description>203</description></item>
    ///         <item><term>Alpha-2</term><description>CZ</description></item>
    ///         <item><term>Alpha-3</term><description>CZE</description></item>
    ///     </list>
    /// </remarks>
    [Iso3166("CZ", "CZE")]
    Czechia = 203,

    /// <summary>
    /// Côte d'Ivoire.
    /// </summary>
    /// <remarks>
    ///     <list type="table">
    ///         <item><term>Numeric</term><description>384</description></item>
    ///         <item><term>Alpha-2</term><description>CI</description></item>
    ///         <item><term>Alpha-3</term><description>CIV</description></item>
    ///     </list>
    /// </remarks>
    [Iso3166("CI", "CIV")]
    CôteDIvoire = 384,

    /// <summary>
    /// Denmark.
    /// </summary>
    /// <remarks>
    ///     <list type="table">
    ///         <item><term>Numeric</term><description>208</description></item>
    ///         <item><term>Alpha-2</term><description>DK</description></item>
    ///         <item><term>Alpha-3</term><description>DNK</description></item>
    ///     </list>
    /// </remarks>
    [Iso3166("DK", "DNK")]
    Denmark = 208,

    /// <summary>
    /// Djibouti.
    /// </summary>
    /// <remarks>
    ///     <list type="table">
    ///         <item><term>Numeric</term><description>262</description></item>
    ///         <item><term>Alpha-2</term><description>DJ</description></item>
    ///         <item><term>Alpha-3</term><description>DJI</description></item>
    ///     </list>
    /// </remarks>
    [Iso3166("DJ", "DJI")]
    Djibouti = 262,

    /// <summary>
    /// Dominica.
    /// </summary>
    /// <remarks>
    ///     <list type="table">
    ///         <item><term>Numeric</term><description>212</description></item>
    ///         <item><term>Alpha-2</term><description>DM</description></item>
    ///         <item><term>Alpha-3</term><description>DMA</description></item>
    ///     </list>
    /// </remarks>
    [Iso3166("DM", "DMA")]
    Dominica = 212,

    /// <summary>
    /// Dominican Republic (the).
    /// </summary>
    /// <remarks>
    ///     <list type="table">
    ///         <item><term>Numeric</term><description>214</description></item>
    ///         <item><term>Alpha-2</term><description>DO</description></item>
    ///         <item><term>Alpha-3</term><description>DOM</description></item>
    ///     </list>
    /// </remarks>
    [Iso3166("DO", "DOM")]
    DominicanRepublic = 214,

    /// <summary>
    /// Ecuador.
    /// </summary>
    /// <remarks>
    ///     <list type="table">
    ///         <item><term>Numeric</term><description>218</description></item>
    ///         <item><term>Alpha-2</term><description>EC</description></item>
    ///         <item><term>Alpha-3</term><description>ECU</description></item>
    ///     </list>
    /// </remarks>
    [Iso3166("EC", "ECU")]
    Ecuador = 218,

    /// <summary>
    /// Egypt.
    /// </summary>
    /// <remarks>
    ///     <list type="table">
    ///         <item><term>Numeric</term><description>818</description></item>
    ///         <item><term>Alpha-2</term><description>EG</description></item>
    ///         <item><term>Alpha-3</term><description>EGY</description></item>
    ///     </list>
    /// </remarks>
    [Iso3166("EG", "EGY")]
    Egypt = 818,

    /// <summary>
    /// El Salvador.
    /// </summary>
    /// <remarks>
    ///     <list type="table">
    ///         <item><term>Numeric</term><description>222</description></item>
    ///         <item><term>Alpha-2</term><description>SV</description></item>
    ///         <item><term>Alpha-3</term><description>SLV</description></item>
    ///     </list>
    /// </remarks>
    [Iso3166("SV", "SLV")]
    ElSalvador = 222,

    /// <summary>
    /// Equatorial Guinea.
    /// </summary>
    /// <remarks>
    ///     <list type="table">
    ///         <item><term>Numeric</term><description>226</description></item>
    ///         <item><term>Alpha-2</term><description>GQ</description></item>
    ///         <item><term>Alpha-3</term><description>GNQ</description></item>
    ///     </list>
    /// </remarks>
    [Iso3166("GQ", "GNQ")]
    EquatorialGuinea = 226,

    /// <summary>
    /// Eritrea.
    /// </summary>
    /// <remarks>
    ///     <list type="table">
    ///         <item><term>Numeric</term><description>232</description></item>
    ///         <item><term>Alpha-2</term><description>ER</description></item>
    ///         <item><term>Alpha-3</term><description>ERI</description></item>
    ///     </list>
    /// </remarks>
    [Iso3166("ER", "ERI")]
    Eritrea = 232,

    /// <summary>
    /// Estonia.
    /// </summary>
    /// <remarks>
    ///     <list type="table">
    ///         <item><term>Numeric</term><description>233</description></item>
    ///         <item><term>Alpha-2</term><description>EE</description></item>
    ///         <item><term>Alpha-3</term><description>EST</description></item>
    ///     </list>
    /// </remarks>
    [Iso3166("EE", "EST")]
    Estonia = 233,

    /// <summary>
    /// Eswatini.
    /// </summary>
    /// <remarks>
    ///     <list type="table">
    ///         <item><term>Numeric</term><description>748</description></item>
    ///         <item><term>Alpha-2</term><description>SZ</description></item>
    ///         <item><term>Alpha-3</term><description>SWZ</description></item>
    ///     </list>
    /// </remarks>
    [Iso3166("SZ", "SWZ")]
    Eswatini = 748,

    /// <summary>
    /// Ethiopia.
    /// </summary>
    /// <remarks>
    ///     <list type="table">
    ///         <item><term>Numeric</term><description>231</description></item>
    ///         <item><term>Alpha-2</term><description>ET</description></item>
    ///         <item><term>Alpha-3</term><description>ETH</description></item>
    ///     </list>
    /// </remarks>
    [Iso3166("ET", "ETH")]
    Ethiopia = 231,

    /// <summary>
    /// Falkland Islands (the) [Malvinas].
    /// </summary>
    /// <remarks>
    ///     <list type="table">
    ///         <item><term>Numeric</term><description>238</description></item>
    ///         <item><term>Alpha-2</term><description>FK</description></item>
    ///         <item><term>Alpha-3</term><description>FLK</description></item>
    ///     </list>
    /// </remarks>
    [Iso3166("FK", "FLK")]
    FalklandIslandsMalvinas = 238,

    /// <summary>
    /// Faroe Islands (the).
    /// </summary>
    /// <remarks>
    ///     <list type="table">
    ///         <item><term>Numeric</term><description>234</description></item>
    ///         <item><term>Alpha-2</term><description>FO</description></item>
    ///         <item><term>Alpha-3</term><description>FRO</description></item>
    ///     </list>
    /// </remarks>
    [Iso3166("FO", "FRO")]
    FaroeIslands = 234,

    /// <summary>
    /// Fiji.
    /// </summary>
    /// <remarks>
    ///     <list type="table">
    ///         <item><term>Numeric</term><description>242</description></item>
    ///         <item><term>Alpha-2</term><description>FJ</description></item>
    ///         <item><term>Alpha-3</term><description>FJI</description></item>
    ///     </list>
    /// </remarks>
    [Iso3166("FJ", "FJI")]
    Fiji = 242,

    /// <summary>
    /// Finland.
    /// </summary>
    /// <remarks>
    ///     <list type="table">
    ///         <item><term>Numeric</term><description>246</description></item>
    ///         <item><term>Alpha-2</term><description>FI</description></item>
    ///         <item><term>Alpha-3</term><description>FIN</description></item>
    ///     </list>
    /// </remarks>
    [Iso3166("FI", "FIN")]
    Finland = 246,

    /// <summary>
    /// France.
    /// </summary>
    /// <remarks>
    ///     <list type="table">
    ///         <item><term>Numeric</term><description>250</description></item>
    ///         <item><term>Alpha-2</term><description>FR</description></item>
    ///         <item><term>Alpha-3</term><description>FRA</description></item>
    ///     </list>
    /// </remarks>
    [Iso3166("FR", "FRA")]
    France = 250,

    /// <summary>
    /// French Guiana.
    /// </summary>
    /// <remarks>
    ///     <list type="table">
    ///         <item><term>Numeric</term><description>254</description></item>
    ///         <item><term>Alpha-2</term><description>GF</description></item>
    ///         <item><term>Alpha-3</term><description>GUF</description></item>
    ///     </list>
    /// </remarks>
    [Iso3166("GF", "GUF")]
    FrenchGuiana = 254,

    /// <summary>
    /// French Polynesia.
    /// </summary>
    /// <remarks>
    ///     <list type="table">
    ///         <item><term>Numeric</term><description>258</description></item>
    ///         <item><term>Alpha-2</term><description>PF</description></item>
    ///         <item><term>Alpha-3</term><description>PYF</description></item>
    ///     </list>
    /// </remarks>
    [Iso3166("PF", "PYF")]
    FrenchPolynesia = 258,

    /// <summary>
    /// French Southern Territories (the).
    /// </summary>
    /// <remarks>
    ///     <list type="table">
    ///         <item><term>Numeric</term><description>260</description></item>
    ///         <item><term>Alpha-2</term><description>TF</description></item>
    ///         <item><term>Alpha-3</term><description>ATF</description></item>
    ///     </list>
    /// </remarks>
    [Iso3166("TF", "ATF")]
    FrenchSouthernTerritories = 260,

    /// <summary>
    /// Gabon.
    /// </summary>
    /// <remarks>
    ///     <list type="table">
    ///         <item><term>Numeric</term><description>266</description></item>
    ///         <item><term>Alpha-2</term><description>GA</description></item>
    ///         <item><term>Alpha-3</term><description>GAB</description></item>
    ///     </list>
    /// </remarks>
    [Iso3166("GA", "GAB")]
    Gabon = 266,

    /// <summary>
    /// Gambia (the).
    /// </summary>
    /// <remarks>
    ///     <list type="table">
    ///         <item><term>Numeric</term><description>270</description></item>
    ///         <item><term>Alpha-2</term><description>GM</description></item>
    ///         <item><term>Alpha-3</term><description>GMB</description></item>
    ///     </list>
    /// </remarks>
    [Iso3166("GM", "GMB")]
    Gambia = 270,

    /// <summary>
    /// Georgia.
    /// </summary>
    /// <remarks>
    ///     <list type="table">
    ///         <item><term>Numeric</term><description>268</description></item>
    ///         <item><term>Alpha-2</term><description>GE</description></item>
    ///         <item><term>Alpha-3</term><description>GEO</description></item>
    ///     </list>
    /// </remarks>
    [Iso3166("GE", "GEO")]
    Georgia = 268,

    /// <summary>
    /// Germany.
    /// </summary>
    /// <remarks>
    ///     <list type="table">
    ///         <item><term>Numeric</term><description>276</description></item>
    ///         <item><term>Alpha-2</term><description>DE</description></item>
    ///         <item><term>Alpha-3</term><description>DEU</description></item>
    ///     </list>
    /// </remarks>
    [Iso3166("DE", "DEU")]
    Germany = 276,

    /// <summary>
    /// Ghana.
    /// </summary>
    /// <remarks>
    ///     <list type="table">
    ///         <item><term>Numeric</term><description>288</description></item>
    ///         <item><term>Alpha-2</term><description>GH</description></item>
    ///         <item><term>Alpha-3</term><description>GHA</description></item>
    ///     </list>
    /// </remarks>
    [Iso3166("GH", "GHA")]
    Ghana = 288,

    /// <summary>
    /// Gibraltar.
    /// </summary>
    /// <remarks>
    ///     <list type="table">
    ///         <item><term>Numeric</term><description>292</description></item>
    ///         <item><term>Alpha-2</term><description>GI</description></item>
    ///         <item><term>Alpha-3</term><description>GIB</description></item>
    ///     </list>
    /// </remarks>
    [Iso3166("GI", "GIB")]
    Gibraltar = 292,

    /// <summary>
    /// Greece.
    /// </summary>
    /// <remarks>
    ///     <list type="table">
    ///         <item><term>Numeric</term><description>300</description></item>
    ///         <item><term>Alpha-2</term><description>GR</description></item>
    ///         <item><term>Alpha-3</term><description>GRC</description></item>
    ///     </list>
    /// </remarks>
    [Iso3166("GR", "GRC")]
    Greece = 300,

    /// <summary>
    /// Greenland.
    /// </summary>
    /// <remarks>
    /// 304, GL, GRL
    /// </remarks>
    [Iso3166("GL", "GRL")]
    Greenland = 304,

    /// <summary>
    /// Grenada.
    /// </summary>
    /// <remarks>
    /// 308, GD, GRD
    /// </remarks>
    [Iso3166("GD", "GRD")]
    Grenada = 308,

    /// <summary>
    /// Guadeloupe.
    /// </summary>
    /// <remarks>
    /// 312, GP, GLP
    /// </remarks>
    [Iso3166("GP", "GLP")]
    Guadeloupe = 312,

    /// <summary>
    /// Guam.
    /// </summary>
    /// <remarks>
    /// 316, GU, GUM
    /// </remarks>
    [Iso3166("GU", "GUM")]
    Guam = 316,

    /// <summary>
    /// Guatemala.
    /// </summary>
    /// <remarks>
    /// 320, GT, GTM
    /// </remarks>
    [Iso3166("GT", "GTM")]
    Guatemala = 320,

    /// <summary>
    /// Guernsey.
    /// </summary>
    /// <remarks>
    /// 831, GG, GGY
    /// </remarks>
    [Iso3166("GG", "GGY")]
    Guernsey = 831,

    /// <summary>
    /// Guinea.
    /// </summary>
    /// <remarks>
    /// 324, GN, GIN
    /// </remarks>
    [Iso3166("GN", "GIN")]
    Guinea = 324,

    /// <summary>
    /// Guinea-Bissau.
    /// </summary>
    /// <remarks>
    /// 624, GW, GNB
    /// </remarks>
    [Iso3166("GW", "GNB")]
    GuineaBissau = 624,

    /// <summary>
    /// Guyana.
    /// </summary>
    /// <remarks>
    /// 328, GY, GUY
    /// </remarks>
    [Iso3166("GY", "GUY")]
    Guyana = 328,

    /// <summary>
    /// Haiti.
    /// </summary>
    /// <remarks>
    /// 332, HT, HTI
    /// </remarks>
    [Iso3166("HT", "HTI")]
    Haiti = 332,

    /// <summary>
    /// Heard Island and McDonald Islands.
    /// </summary>
    /// <remarks>
    /// 334, HM, HMD
    /// </remarks>
    [Iso3166("HM", "HMD")]
    HeardIslandAndMcDonaldIslands = 334,

    /// <summary>
    /// Holy See (the).
    /// </summary>
    /// <remarks>
    /// 336, VA, VAT
    /// </remarks>
    [Iso3166("VA", "VAT")]
    HolySee = 336,

    /// <summary>
    /// Honduras.
    /// </summary>
    /// <remarks>
    /// 340, HN, HND
    /// </remarks>
    [Iso3166("HN", "HND")]
    Honduras = 340,

    /// <summary>
    /// Hong Kong.
    /// </summary>
    /// <remarks>
    /// 344, HK, HKG
    /// </remarks>
    [Iso3166("HK", "HKG")]
    HongKong = 344,

    /// <summary>
    /// Hungary.
    /// </summary>
    /// <remarks>
    /// 348, HU, HUN
    /// </remarks>
    [Iso3166("HU", "HUN")]
    Hungary = 348,

    /// <summary>
    /// Iceland.
    /// </summary>
    /// <remarks>
    /// 352, IS, ISL
    /// </remarks>
    [Iso3166("IS", "ISL")]
    Iceland = 352,

    /// <summary>
    /// India.
    /// </summary>
    /// <remarks>
    /// 356, IN, IND
    /// </remarks>
    [Iso3166("IN", "IND")]
    India = 356,
    
    /// <summary>
    /// Indonesia.
    /// </summary>
    /// <remarks>
    /// 360, ID, IDN
    /// </remarks>
    [Iso3166("ID", "IDN")]
    Indonesia = 360,

    /// <summary>
    /// Iran (Islamic Republic of).
    /// </summary>
    /// <remarks>
    /// 364, IR, IRN
    /// </remarks>
    [Iso3166("IR", "IRN")]
    Iran = 364,

    /// <summary>
    /// Iraq.
    /// </summary>
    /// <remarks>
    /// 368, IQ, IRQ
    /// </remarks>
    [Iso3166("IQ", "IRQ")]
    Iraq = 368,

    /// <summary>
    /// Ireland.
    /// </summary>
    /// <remarks>
    /// 372, IE, IRL
    /// </remarks>
    [Iso3166("IE", "IRL")]
    Ireland = 372,

    /// <summary>
    /// Isle of Man.
    /// </summary>
    /// <remarks>
    /// 833, IM, IMN
    /// </remarks>
    [Iso3166("IM", "IMN")]
    IsleOfMan = 833,

    /// <summary>
    /// Israel.
    /// </summary>
    /// <remarks>
    /// 376, IL, ISR
    /// </remarks>
    [Iso3166("IL", "ISR")]
    Israel = 376,

    /// <summary>
    /// Italy.
    /// </summary>
    /// <remarks>
    /// 380, IT, ITA
    /// </remarks>
    [Iso3166("IT", "ITA")]
    Italy = 380,

    /// <summary>
    /// Jamaica.
    /// </summary>
    /// <remarks>
    /// 388, JM, JAM
    /// </remarks>
    [Iso3166("JM", "JAM")]
    Jamaica = 388,

    /// <summary>
    /// Japan.
    /// </summary>
    /// <remarks>
    /// 392, JP, JPN
    /// </remarks>
    [Iso3166("JP", "JPN")]
    Japan = 392,

    /// <summary>
    /// Jersey.
    /// </summary>
    /// <remarks>
    /// 832, JE, JEY
    /// </remarks>
    [Iso3166("JE", "JEY")]
    Jersey = 832,

    /// <summary>
    /// Jordan.
    /// </summary>
    /// <remarks>
    /// 400, JO, JOR
    /// </remarks>
    [Iso3166("JO", "JOR")]
    Jordan = 400,

    /// <summary>
    /// Kazakhstan.
    /// </summary>
    /// <remarks>
    /// 398, KZ, KAZ
    /// </remarks>
    [Iso3166("KZ", "KAZ")]
    Kazakhstan = 398,

    /// <summary>
    /// Kenya.
    /// </summary>
    /// <remarks>
    /// 404, KE, KEN
    /// </remarks>
    [Iso3166("KE", "KEN")]
    Kenya = 404,

    /// <summary>
    /// Kiribati.
    /// </summary>
    /// <remarks>
    /// 296, KI, KIR
    /// </remarks>
    [Iso3166("KI", "KIR")]
    Kiribati = 296,

    /// <summary>
    /// Korea (the Democratic People's Republic of).
    /// </summary>
    /// <remarks>
    /// 408, KP, PRK
    /// </remarks>
    [Iso3166("KP", "PRK")]
    KoreaDemocraticPeoplesRepublic = 408,

    /// <summary>
    /// Korea (the Republic of).
    /// </summary>
    /// <remarks>
    /// 410, KR, KOR
    /// </remarks>
    [Iso3166("KR", "KOR")]
    KoreaRepublic = 410,

    /// <summary>
    /// Kuwait.
    /// </summary>
    /// <remarks>
    /// 414, KW, KWT
    /// </remarks>
    [Iso3166("KW", "KWT")]
    Kuwait = 414,

    /// <summary>
    /// Kyrgyzstan.
    /// </summary>
    /// <remarks>
    /// 417, KG, KGZ
    /// </remarks>
    [Iso3166("KG", "KGZ")]
    Kyrgyzstan = 417,

    /// <summary>
    /// Lao People's Democratic Republic (the).
    /// </summary>
    /// <remarks>
    /// 418, LA, LAO
    /// </remarks>
    [Iso3166("LA", "LAO")]
    LaoPeoplesDemocraticRepublic = 418,

    /// <summary>
    /// Latvia.
    /// </summary>
    /// <remarks>
    /// 428, LV, LVA
    /// </remarks>
    [Iso3166("LV", "LVA")]
    Latvia = 428,

    /// <summary>
    /// Lebanon.
    /// </summary>
    /// <remarks>
    /// 422, LB, LBN
    /// </remarks>
    [Iso3166("LB", "LBN")]
    Lebanon = 422,

    /// <summary>
    /// Lesotho.
    /// </summary>
    /// <remarks>
    /// 426, LS, LSO
    /// </remarks>
    [Iso3166("LS", "LSO")]
    Lesotho = 426,

    /// <summary>
    /// Liberia.
    /// </summary>
    /// <remarks>
    /// 430, LR, LBR
    /// </remarks>
    [Iso3166("LR", "LBR")]
    Liberia = 430,

    /// <summary>
    /// Libya.
    /// </summary>
    /// <remarks>
    /// 434, LY, LBY
    /// </remarks>
    [Iso3166("LY", "LBY")]
    Libya = 434,

    /// <summary>
    /// Liechtenstein.
    /// </summary>
    /// <remarks>
    /// 438, LI, LIE
    /// </remarks>
    [Iso3166("LI", "LIE")]
    Liechtenstein = 438,

    /// <summary>
    /// Lithuania.
    /// </summary>
    /// <remarks>
    /// 440, LT, LTU
    /// </remarks>
    [Iso3166("LT", "LTU")]
    Lithuania = 440,

    /// <summary>
    /// Luxembourg.
    /// </summary>
    /// <remarks>
    /// 442, LU, LUX
    /// </remarks>
    [Iso3166("LU", "LUX")]
    Luxembourg = 442,

    /// <summary>
    /// Macao.
    /// </summary>
    /// <remarks>
    /// 446, MO, MAC
    /// </remarks>
    [Iso3166("MO", "MAC")]
    Macao = 446,

    /// <summary>
    /// Madagascar.
    /// </summary>
    /// <remarks>
    /// 450, MG, MDG
    /// </remarks>
    [Iso3166("MG", "MDG")]
    Madagascar = 450,

    /// <summary>
    /// Malawi.
    /// </summary>
    /// <remarks>
    /// 454, MW, MWI
    /// </remarks>
    [Iso3166("MW", "MWI")]
    Malawi = 454,

    /// <summary>
    /// Malaysia.
    /// </summary>
    /// <remarks>
    /// 458, MY, MYS
    /// </remarks>
    [Iso3166("MY", "MYS")]
    Malaysia = 458,

    /// <summary>
    /// Maldives.
    /// </summary>
    /// <remarks>
    /// 462, MV, MDV
    /// </remarks>
    [Iso3166("MV", "MDV")]
    Maldives = 462,

    /// <summary>
    /// Mali.
    /// </summary>
    /// <remarks>
    /// 466, ML, MLI
    /// </remarks>
    [Iso3166("ML", "MLI")]
    Mali = 466,

    /// <summary>
    /// Malta.
    /// </summary>
    /// <remarks>
    /// 470, MT, MLT
    /// </remarks>
    [Iso3166("MT", "MLT")]
    Malta = 470,

    /// <summary>
    /// Marshall Islands (the).
    /// </summary>
    /// <remarks>
    /// 584, MH, MHL
    /// </remarks>
    [Iso3166("MH", "MHL")]
    MarshallIslands = 584,

    /// <summary>
    /// Martinique.
    /// </summary>
    /// <remarks>
    /// 474, MQ, MTQ
    /// </remarks>
    [Iso3166("MQ", "MTQ")]
    Martinique = 474,

    /// <summary>
    /// Mauritania.
    /// </summary>
    /// <remarks>
    /// 478, MR, MRT
    /// </remarks>
    [Iso3166("MR", "MRT")]
    Mauritania = 478,

    /// <summary>
    /// Mauritius.
    /// </summary>
    /// <remarks>
    /// 480, MU, MUS
    /// </remarks>
    [Iso3166("MU", "MUS")]
    Mauritius = 480,

    /// <summary>
    /// Mayotte.
    /// </summary>
    /// <remarks>
    /// 175, YT, MYT
    /// </remarks>
    [Iso3166("YT", "MYT")]
    Mayotte = 175,

    /// <summary>
    /// Mexico.
    /// </summary>
    /// <remarks>
    /// 484, MX, MEX
    /// </remarks>
    [Iso3166("MX", "MEX")]
    Mexico = 484,

    /// <summary>
    /// Micronesia (Federated States of).
    /// </summary>
    /// <remarks>
    /// 583, FM, FSM
    /// </remarks>
    [Iso3166("FM", "FSM")]
    Micronesia = 583,

    /// <summary>
    /// Moldova (the Republic of).
    /// </summary>
    /// <remarks>
    /// 498, MD, MDA
    /// </remarks>
    [Iso3166("MD", "MDA")]
    Moldova = 498,

    /// <summary>
    /// Monaco.
    /// </summary>
    /// <remarks>
    /// 492, MC, MCO
    /// </remarks>
    [Iso3166("MC", "MCO")]
    Monaco = 492,

    /// <summary>
    /// Mongolia.
    /// </summary>
    /// <remarks>
    /// 496, MN, MNG
    /// </remarks>
    [Iso3166("MN", "MNG")]
    Mongolia = 496,

    /// <summary>
    /// Montenegro.
    /// </summary>
    /// <remarks>
    /// 499, ME, MNE
    /// </remarks>
    [Iso3166("ME", "MNE")]
    Montenegro = 499,

    /// <summary>
    /// Montserrat.
    /// </summary>
    /// <remarks>
    /// 500, MS, MSR
    /// </remarks>
    [Iso3166("MS", "MSR")]
    Montserrat = 500,

    /// <summary>
    /// Morocco.
    /// </summary>
    /// <remarks>
    /// 504, MA, MAR
    /// </remarks>
    [Iso3166("MA", "MAR")]
    Morocco = 504,

    /// <summary>
    /// Mozambique.
    /// </summary>
    /// <remarks>
    /// 508, MZ, MOZ
    /// </remarks>
    [Iso3166("MZ", "MOZ")]
    Mozambique = 508,

    /// <summary>
    /// Myanmar.
    /// </summary>
    /// <remarks>
    /// 104, MM, MMR
    /// </remarks>
    [Iso3166("MM", "MMR")]
    Myanmar = 104,

    /// <summary>
    /// Namibia.
    /// </summary>
    /// <remarks>
    /// 516, NA, NAM
    /// </remarks>
    [Iso3166("NA", "NAM")]
    Namibia = 516,

    /// <summary>
    /// Nauru.
    /// </summary>
    /// <remarks>
    /// 520, NR, NRU
    /// </remarks>
    [Iso3166("NR", "NRU")]
    Nauru = 520,

    /// <summary>
    /// Nepal.
    /// </summary>
    /// <remarks>
    /// 524, NP, NPL
    /// </remarks>
    [Iso3166("NP", "NPL")]
    Nepal = 524,

    /// <summary>
    /// Netherlands (the).
    /// </summary>
    /// <remarks>
    /// 528, NL, NLD
    /// </remarks>
    [Iso3166("NL", "NLD")]
    Netherlands = 528,

    /// <summary>
    /// New Caledonia.
    /// </summary>
    /// <remarks>
    /// 540, NC, NCL
    /// </remarks>
    [Iso3166("NC", "NCL")]
    NewCaledonia = 540,

    /// <summary>
    /// New Zealand.
    /// </summary>
    /// <remarks>
    /// 554, NZ, NZL
    /// </remarks>
    [Iso3166("NZ", "NZL")]
    NewZealand = 554,

    /// <summary>
    /// Nicaragua.
    /// </summary>
    /// <remarks>
    /// 558, NI, NIC
    /// </remarks>
    [Iso3166("NI", "NIC")]
    Nicaragua = 558,

    /// <summary>
    /// Niger (the).
    /// </summary>
    /// <remarks>
    /// 562, NE, NER
    /// </remarks>
    [Iso3166("NE", "NER")]
    Niger = 562,

    /// <summary>
    /// Nigeria.
    /// </summary>
    /// <remarks>
    /// 566, NG, NGA
    /// </remarks>
    [Iso3166("NG", "NGA")]
    Nigeria = 566,

    /// <summary>
    /// Niue.
    /// </summary>
    /// <remarks>
    /// 570, NU, NIU
    /// </remarks>
    [Iso3166("NU", "NIU")]
    Niue = 570,

    /// <summary>
    /// Norfolk Island.
    /// </summary>
    /// <remarks>
    /// 574, NF, NFK
    /// </remarks>
    [Iso3166("NF", "NFK")]
    NorfolkIsland = 574,

    /// <summary>
    /// North Macedonia.
    /// </summary>
    /// <remarks>
    /// 807, MK, MKD
    /// </remarks>
    [Iso3166("MK", "MKD")]
    NorthMacedonia = 807,

    /// <summary>
    /// Northern Mariana Islands (the).
    /// </summary>
    /// <remarks>
    /// 580, MP, MNP
    /// </remarks>
    [Iso3166("MP", "MNP")]
    NorthernMarianaIslands = 580,

    /// <summary>
    /// Norway.
    /// </summary>
    /// <remarks>
    /// 578, NO, NOR
    /// </remarks>
    [Iso3166("NO", "NOR")]
    Norway = 578,

    /// <summary>
    /// Oman.
    /// </summary>
    /// <remarks>
    /// 512, OM, OMN
    /// </remarks>
    [Iso3166("OM", "OMN")]
    Oman = 512,

    /// <summary>
    /// Pakistan.
    /// </summary>
    /// <remarks>
    /// 586, PK, PAK
    /// </remarks>
    [Iso3166("PK", "PAK")]
    Pakistan = 586,

    /// <summary>
    /// Palau.
    /// </summary>
    /// <remarks>
    /// 585, PW, PLW
    /// </remarks>
    [Iso3166("PW", "PLW")]
    Palau = 585,

    /// <summary>
    /// Palestine, State of.
    /// </summary>
    /// <remarks>
    /// 275, PS, PSE
    /// </remarks>
    [Iso3166("PS", "PSE")]
    Palestine = 275,

    /// <summary>
    /// Panama.
    /// </summary>
    /// <remarks>
    /// 591, PA, PAN
    /// </remarks>
    [Iso3166("PA", "PAN")]
    Panama = 591,

    /// <summary>
    /// Papua New Guinea.
    /// </summary>
    /// <remarks>
    /// 598, PG, PNG
    /// </remarks>
    [Iso3166("PG", "PNG")]
    PapuaNewGuinea = 598,

    /// <summary>
    /// Paraguay.
    /// </summary>
    /// <remarks>
    /// 600, PY, PRY
    /// </remarks>
    [Iso3166("PY", "PRY")]
    Paraguay = 600,

    /// <summary>
    /// Peru.
    /// </summary>
    /// <remarks>
    /// 604, PE, PER
    /// </remarks>
    [Iso3166("PE", "PER")]
    Peru = 604,

    /// <summary>
    /// Philippines (the).
    /// </summary>
    /// <remarks>
    /// 608, PH, PHL
    /// </remarks>
    [Iso3166("PH", "PHL")]
    Philippines = 608,

    /// <summary>
    /// Pitcairn Islands (the).
    /// </summary>
    /// <remarks>
    /// 612, PN, PCN
    /// </remarks>
    [Iso3166("PN", "PCN")]
    PitcairnIslands = 612,

    /// <summary>
    /// Poland.
    /// </summary>
    /// <remarks>
    /// 616, PL, POL
    /// </remarks>
    [Iso3166("PL", "POL")]
    Poland = 616,

    /// <summary>
    /// Portugal.
    /// </summary>
    /// <remarks>
    /// 620, PT, PRT
    /// </remarks>
    [Iso3166("PT", "PRT")]
    Portugal = 620,

    /// <summary>
    /// Puerto Rico.
    /// </summary>
    /// <remarks>
    /// 630, PR, PRI
    /// </remarks>
    [Iso3166("PR", "PRI")]
    PuertoRico = 630,

    /// <summary>
    /// Qatar.
    /// </summary>
    /// <remarks>
    /// 634, QA, QAT
    /// </remarks>
    [Iso3166("QA", "QAT")]
    Qatar = 634,

    /// <summary>
    /// Romania.
    /// </summary>
    /// <remarks>
    /// 642, RO, ROU
    /// </remarks>
    [Iso3166("RO", "ROU")]
    Romania = 642,

    /// <summary>
    /// Russian Federation (the).
    /// </summary>
    /// <remarks>
    /// 643, RU, RUS
    /// </remarks>
    [Iso3166("RU", "RUS")]
    RussianFederation = 643,

    /// <summary>
    /// Rwanda.
    /// </summary>
    /// <remarks>
    /// 646, RW, RWA
    /// </remarks>
    [Iso3166("RW", "RWA")]
    Rwanda = 646,

    /// <summary>
    /// Réunion.
    /// </summary>
    /// <remarks>
    /// 638, RE, REU
    /// </remarks>
    [Iso3166("RE", "REU")]
    Réunion = 638,

    /// <summary>
    /// Saint Barthélemy.
    /// </summary>
    /// <remarks>
    /// 652, BL, BLM
    /// </remarks>
    [Iso3166("BL", "BLM")]
    SaintBarthélemy = 652,

    /// <summary>
    /// Saint Helena, Ascension and Tristan da Cunha.
    /// </summary>
    /// <remarks>
    /// 654, SH, SHN
    /// </remarks>
    [Iso3166("SH", "SHN")]
    SaintHelenaAscensionAndTristanDaCunha = 654,

    /// <summary>
    /// Saint Kitts and Nevis.
    /// </summary>
    /// <remarks>
    /// 659, KN, KNA
    /// </remarks>
    [Iso3166("KN", "KNA")]
    SaintKittsAndNevis = 659,

    /// <summary>
    /// Saint Lucia.
    /// </summary>
    /// <remarks>
    /// 662, LC, LCA
    /// </remarks>
    [Iso3166("LC", "LCA")]
    SaintLucia = 662,

    /// <summary>
    /// Saint Martin (French part).
    /// </summary>
    /// <remarks>
    /// 663, MF, MAF
    /// </remarks>
    [Iso3166("MF", "MAF")]
    SaintMartin = 663,

    /// <summary>
    /// Saint Pierre and Miquelon.
    /// </summary>
    /// <remarks>
    /// 666, PM, SPM
    /// </remarks>
    [Iso3166("PM", "SPM")]
    SaintPierreAndMiquelon = 666,

    /// <summary>
    /// Saint Vincent and the Grenadines.
    /// </summary>
    /// <remarks>
    /// 670, VC, VCT
    /// </remarks>
    [Iso3166("VC", "VCT")]
    SaintVincentAndGrenadines = 670,

    /// <summary>
    /// Samoa.
    /// </summary>
    /// <remarks>
    /// 882, WS, WSM
    /// </remarks>
    [Iso3166("WS", "WSM")]
    Samoa = 882,

    /// <summary>
    /// San Marino.
    /// </summary>
    /// <remarks>
    /// 674, SM, SMR
    /// </remarks>
    [Iso3166("SM", "SMR")]
    SanMarino = 674,

    /// <summary>
    /// Sao Tome and Principe.
    /// </summary>
    /// <remarks>
    /// 678, ST, STP
    /// </remarks>
    [Iso3166("ST", "STP")]
    SaoTomeAndPrincipe = 678,

    /// <summary>
    /// Saudi Arabia.
    /// </summary>
    /// <remarks>
    /// 682, SA, SAU
    /// </remarks>
    [Iso3166("SA", "SAU")]
    SaudiArabia = 682,

    /// <summary>
    /// Senegal.
    /// </summary>
    /// <remarks>
    /// 686, SN, SEN
    /// </remarks>
    [Iso3166("SN", "SEN")]
    Senegal = 686,

    /// <summary>
    /// Serbia.
    /// </summary>
    /// <remarks>
    /// 688, RS, SRB
    /// </remarks>
    [Iso3166("RS", "SRB")]
    Serbia = 688,

    /// <summary>
    /// Seychelles.
    /// </summary>
    /// <remarks>
    /// 690, SC, SYC
    /// </remarks>
    [Iso3166("SC", "SYC")]
    Seychelles = 690,

    /// <summary>
    /// Sierra Leone.
    /// </summary>
    /// <remarks>
    /// 694, SL, SLE
    /// </remarks>
    [Iso3166("SL", "SLE")]
    SierraLeone = 694,

    /// <summary>
    /// Singapore.
    /// </summary>
    /// <remarks>
    /// 702, SG, SGP
    /// </remarks>
    [Iso3166("SG", "SGP")]
    Singapore = 702,

    /// <summary>
    /// Sint Maarten (Dutch part).
    /// </summary>
    /// <remarks>
    /// 534, SX, SXM
    /// </remarks>
    [Iso3166("SX", "SXM")]
    SintMaarten = 534,

    /// <summary>
    /// Slovakia.
    /// </summary>
    /// <remarks>
    /// 703, SK, SVK
    /// </remarks>
    [Iso3166("SK", "SVK")]
    Slovakia = 703,

    /// <summary>
    /// Slovenia.
    /// </summary>
    /// <remarks>
    /// 705, SI, SVN
    /// </remarks>
    [Iso3166("SI", "SVN")]
    Slovenia = 705,

    /// <summary>
    /// Solomon Islands.
    /// </summary>
    /// <remarks>
    /// 090, SB, SLB
    /// </remarks>
    [Iso3166("SB", "SLB")]
    SolomonIslands = 090,

    /// <summary>
    /// Somalia.
    /// </summary>
    /// <remarks>
    /// 706, SO, SOM
    /// </remarks>
    [Iso3166("SO", "SOM")]
    Somalia = 706,

    /// <summary>
    /// South Africa.
    /// </summary>
    /// <remarks>
    /// 710, ZA, ZAF
    /// </remarks>
    [Iso3166("ZA", "ZAF")]
    SouthAfrica = 710,

    /// <summary>
    /// South Georgia and the South Sandwich Islands.
    /// </summary>
    /// <remarks>
    /// 239, GS, SGS
    /// </remarks>
    [Iso3166("GS", "SGS")]
    SouthGeorgiaAndSouthSandwichIslands = 239,

    /// <summary>
    /// South Sudan.
    /// </summary>
    /// <remarks>
    /// 728, SS, SSD
    /// </remarks>
    [Iso3166("SS", "SSD")]
    SouthSudan = 728,

    /// <summary>
    /// Spain.
    /// </summary>
    /// <remarks>
    /// 724, ES, ESP
    /// </remarks>
    [Iso3166("ES", "ESP")]
    Spain = 724,

    /// <summary>
    /// Sri Lanka.
    /// </summary>
    /// <remarks>
    /// 144, LK, LKA
    /// </remarks>
    [Iso3166("LK", "LKA")]
    SriLanka = 144,

    /// <summary>
    /// Sudan (the).
    /// </summary>
    /// <remarks>
    /// 729, SD, SDN
    /// </remarks>
    [Iso3166("SD", "SDN")]
    Sudan = 729,

    /// <summary>
    /// Suriname.
    /// </summary>
    /// <remarks>
    /// 740, SR, SUR
    /// </remarks>
    [Iso3166("SR", "SUR")]
    Suriname = 740,

    /// <summary>
    /// Svalbard and Jan Mayen.
    /// </summary>
    /// <remarks>
    /// 744, SJ, SJM
    /// </remarks>
    [Iso3166("SJ", "SJM")]
    SvalbardAndJanMayen = 744,

    /// <summary>
    /// Sweden.
    /// </summary>
    /// <remarks>
    /// 752, SE, SWE
    /// </remarks>
    [Iso3166("SE", "SWE")]
    Sweden = 752,

    /// <summary>
    /// Switzerland.
    /// </summary>
    /// <remarks>
    /// 756, CH, CHE
    /// </remarks>
    [Iso3166("CH", "CHE")]
    Switzerland = 756,

    /// <summary>
    /// Syrian Arab Republic (the).
    /// </summary>
    /// <remarks>
    /// 760, SY, SYR
    /// </remarks>
    [Iso3166("SY", "SYR")]
    SyrianArabRepublic = 760,

    /// <summary>
    /// Taiwan.
    /// </summary>
    /// <remarks>
    /// 158, TW, TWN
    /// </remarks>
    [Iso3166("TW", "TWN")]
    Taiwan = 158,

    /// <summary>
    /// Tajikistan.
    /// </summary>
    /// <remarks>
    /// 762, TJ, TJK
    /// </remarks>
    [Iso3166("TJ", "TJK")]
    Tajikistan = 762,

    /// <summary>
    /// Tanzania, the United Republic of.
    /// </summary>
    /// <remarks>
    /// 834, TZ, TZA
    /// </remarks>
    [Iso3166("TZ", "TZA")]
    Tanzania = 834,

    /// <summary>
    /// Thailand.
    /// </summary>
    /// <remarks>
    /// 764, TH, THA
    /// </remarks>
    [Iso3166("TH", "THA")]
    Thailand = 764,

    /// <summary>
    /// Timor-Leste.
    /// </summary>
    /// <remarks>
    /// 626, TL, TLS
    /// </remarks>
    [Iso3166("TL", "TLS")]
    TimorLeste = 626,

    /// <summary>
    /// Togo.
    /// </summary>
    /// <remarks>
    /// 768, TG, TGO
    /// </remarks>
    [Iso3166("TG", "TGO")]
    Togo = 768,

    /// <summary>
    /// Tokelau.
    /// </summary>
    /// <remarks>
    /// 772, TK, TKL
    /// </remarks>
    [Iso3166("TK", "TKL")]
    Tokelau = 772,

    /// <summary>
    /// Tonga.
    /// </summary>
    /// <remarks>
    /// 776, TO, TON
    /// </remarks>
    [Iso3166("TO", "TON")]
    Tonga = 776,

    /// <summary>
    /// Trinidad and Tobago.
    /// </summary>
    /// <remarks>
    /// 780, TT, TTO
    /// </remarks>
    [Iso3166("TT", "TTO")]
    TrinidadAndTobago = 780,

    /// <summary>
    /// Tunisia.
    /// </summary>
    /// <remarks>
    /// 788, TN, TUN
    /// </remarks>
    [Iso3166("TN", "TUN")]
    Tunisia = 788,

    /// <summary>
    /// Turkmenistan.
    /// </summary>
    /// <remarks>
    /// 795, TM, TKM
    /// </remarks>
    [Iso3166("TM", "TKM")]
    Turkmenistan = 795,

    /// <summary>
    /// Turks and Caicos Islands (the).
    /// </summary>
    /// <remarks>
    /// 796, TC, TCA
    /// </remarks>
    [Iso3166("TC", "TCA")]
    TurksAndCaicosIslands = 796,

    /// <summary>
    /// Tuvalu.
    /// </summary>
    /// <remarks>
    /// 798, TV, TUV
    /// </remarks>
    [Iso3166("TV", "TUV")]
    Tuvalu = 798,

    /// <summary>
    /// Türkiye.
    /// </summary>
    /// <remarks>
    /// 792, TR, TUR
    /// </remarks>
    [Iso3166("TR", "TUR")]
    Türkiye = 792,

    /// <summary>
    /// Uganda.
    /// </summary>
    /// <remarks>
    /// 800, UG, UGA
    /// </remarks>
    [Iso3166("UG", "UGA")]
    Uganda = 800,

    /// <summary>
    /// Ukraine.
    /// </summary>
    /// <remarks>
    /// 804, UA, UKR
    /// </remarks>
    [Iso3166("UA", "UKR")]
    Ukraine = 804,

    /// <summary>
    /// United Arab Emirates (the).
    /// </summary>
    /// <remarks>
    /// 784, AE, ARE
    /// </remarks>
    [Iso3166("AE", "ARE")]
    UnitedArabEmirates = 784,

    /// <summary>
    /// United Kingdom of Great Britain and Northern Ireland (the).
    /// </summary>
    /// <remarks>
    /// 826, GB, GBR
    /// </remarks>
    [Iso3166("GB", "GBR")]
    UnitedKingdom = 826,

    /// <summary>
    /// United States Minor Outlying Islands (the).
    /// </summary>
    /// <remarks>
    /// 581, UM, UMI
    /// </remarks>
    [Iso3166("UM", "UMI")]
    UnitedStatesMinorOutlyingIslands = 581,

    /// <summary>
    /// United States of America (the).
    /// </summary>
    /// <remarks>
    /// 840, US, USA
    /// </remarks>
    [Iso3166("US", "USA")]
    UnitedStatesOfAmerica = 840,

    /// <summary>
    /// Uruguay.
    /// </summary>
    /// <remarks>
    /// 858, UY, URY
    /// </remarks>
    [Iso3166("UY", "URY")]
    Uruguay = 858,

    /// <summary>
    /// Uzbekistan.
    /// </summary>
    /// <remarks>
    /// 860, UZ, UZB
    /// </remarks>
    [Iso3166("UZ", "UZB")]
    Uzbekistan = 860,

    /// <summary>
    /// Vanuatu.
    /// </summary>
    /// <remarks>
    /// 548, VU, VUT
    /// </remarks>
    [Iso3166("VU", "VUT")]
    Vanuatu = 548,

    /// <summary>
    /// Venezuela (Bolivarian Republic of).
    /// </summary>
    /// <remarks>
    /// 862, VE, VEN
    /// </remarks>
    [Iso3166("VE", "VEN")]
    Venezuela = 862,

    /// <summary>
    /// Viet Nam.
    /// </summary>
    /// <remarks>
    /// 704, VN, VNM
    /// </remarks>
    [Iso3166("VN", "VNM")]
    VietNam = 704,

    /// <summary>
    /// Virgin Islands (British).
    /// </summary>
    [Iso3166("VG", "VGB")]
    VirginIslandsBritish = 092,

    /// <summary>
    /// Virgin Islands (United States).
    /// </summary>
    [Iso3166("VI", "VIR")]
    VirginIslandsUnitedStates = 850,

    /// <summary>
    /// Wallis and Futuna.
    /// </summary>
    /// <remarks>
    /// 876, WF, WLF
    /// </remarks>
    [Iso3166("WF", "WLF")]
    WallisAndFutuna = 876,

    /// <summary>
    /// Western Sahara.
    /// </summary>
    /// <remarks>
    /// 732, EH, ESH
    /// </remarks>
    [Iso3166("EH", "ESH")]
    WesternSahara = 732,

    /// <summary>
    /// Yemen.
    /// </summary>
    /// <remarks>
    /// 887, YE, YEM
    /// </remarks>
    [Iso3166("YE", "YEM")]
    Yemen = 887,

    /// <summary>
    /// Zambia.
    /// </summary>
    /// <remarks>
    /// 894, ZM, ZMB
    /// </remarks>
    [Iso3166("ZM", "ZMB")]
    Zambia = 894,

    /// <summary>
    /// Zimbabwe.
    /// </summary>
    /// <remarks>
    /// 716, ZW, ZWE
    /// </remarks>
    [Iso3166("ZW", "ZWE")]
    Zimbabwe = 716
}
