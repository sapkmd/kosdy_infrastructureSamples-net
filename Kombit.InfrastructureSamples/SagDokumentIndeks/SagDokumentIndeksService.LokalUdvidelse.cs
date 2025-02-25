//------------------------------------------------------------------------------
// <auto-generated>
//     Denne kode blev oprettet ved hj�lp af et v�rkt�j.
//     Runtime-version:4.0.30319.42000
//
//     �ndringer af denne fil kan resultere i ukorrekt funktion, og �ndringerne mistes, hvis
//     koden oprettes igen.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by xsd, Version=4.8.3928.0.
// 
namespace Kombit.InfrastructureSamples.SagDokumentIndeksService {
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="urn:oio:sts:sagdok:sagindeks:1.2.4.0")]
    [System.Xml.Serialization.XmlRootAttribute("SagIndeksEgenskaber", Namespace="urn:oio:sts:sagdok:sagindeks:1.2.4.0", IsNullable=false)]
    public partial class EgenskaberTypeSag : LokalUdvidelseType {
        
        private string sagsstatusField;
        
        private string sagskategoriField;
        
        private FoelsomhedTypeX foelsomhedField;
        
        private bool foelsomhedFieldSpecified;
        
        private string lokationField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string Sagsstatus {
            get {
                return this.sagsstatusField;
            }
            set {
                this.sagsstatusField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string Sagskategori {
            get {
                return this.sagskategoriField;
            }
            set {
                this.sagskategoriField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public FoelsomhedTypeX Foelsomhed {
            get {
                return this.foelsomhedField;
            }
            set {
                this.foelsomhedField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool FoelsomhedSpecified {
            get {
                return this.foelsomhedFieldSpecified;
            }
            set {
                this.foelsomhedFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string Lokation {
            get {
                return this.lokationField;
            }
            set {
                this.lokationField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="urn:oio:sts:sagdok:sagindeks:1.2.4.0")]
    public enum FoelsomhedTypeX {
        
        /// <remarks/>
        IKKE_FORTROLIGE_DATA,
        
        /// <remarks/>
        FORTROLIGE_PERSONOPLYSNINGER,
        
        /// <remarks/>
        FOELSOMME_PERSONOPLYSNINGER,
        
        /// <remarks/>
        VIP_SAGER,
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(EgenskaberTypeSag))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="urn:oio:sts:generelledefinitioner:1.2.4.0")]
    public partial class LokalUdvidelseType {
        
        private VirkningTypeX virkningField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public VirkningTypeX Virkning {
            get {
                return this.virkningField;
            }
            set {
                this.virkningField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="urn:oio:sagdok:3.0.0")]
    public partial class VirkningTypeX {
        
        private TidspunktTypeX fraTidspunktField;
        
        private TidspunktTypeX tilTidspunktField;
        
        private UnikIdTypeX aktoerRefField;
        
        private AktoerTypeKodeTypeX aktoerTypeKodeField;
        
        private bool aktoerTypeKodeFieldSpecified;
        
        private string noteTekstField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public TidspunktTypeX FraTidspunkt {
            get {
                return this.fraTidspunktField;
            }
            set {
                this.fraTidspunktField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public TidspunktTypeX TilTidspunkt {
            get {
                return this.tilTidspunktField;
            }
            set {
                this.tilTidspunktField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public UnikIdTypeX AktoerRef {
            get {
                return this.aktoerRefField;
            }
            set {
                this.aktoerRefField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public AktoerTypeKodeTypeX AktoerTypeKode {
            get {
                return this.aktoerTypeKodeField;
            }
            set {
                this.aktoerTypeKodeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool AktoerTypeKodeSpecified {
            get {
                return this.aktoerTypeKodeFieldSpecified;
            }
            set {
                this.aktoerTypeKodeFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string NoteTekst {
            get {
                return this.noteTekstField;
            }
            set {
                this.noteTekstField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="urn:oio:sagdok:3.0.0")]
    public partial class TidspunktTypeX {
        
        private object itemField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("GraenseIndikator", typeof(bool), Order=0)]
        [System.Xml.Serialization.XmlElementAttribute("TidsstempelDatoTid", typeof(System.DateTime), Order=0)]
        public object Item {
            get {
                return this.itemField;
            }
            set {
                this.itemField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="urn:oio:sts:sagdok:sagindeks:1.2.4.0")]
    public partial class SoegeordType {
        
        private string soegeordIdentifikatorField;
        
        private string beskrivelseTekstField;
        
        private string soegeordKategoriTekstField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string SoegeordIdentifikator {
            get {
                return this.soegeordIdentifikatorField;
            }
            set {
                this.soegeordIdentifikatorField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace="urn:oio:sagdok:3.0.0", Order=1)]
        public string BeskrivelseTekst {
            get {
                return this.beskrivelseTekstField;
            }
            set {
                this.beskrivelseTekstField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string SoegeordKategoriTekst {
            get {
                return this.soegeordKategoriTekstField;
            }
            set {
                this.soegeordKategoriTekstField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="urn:oio:sagdok:3.0.0")]
    public partial class UnikIdTypeX {
        
        private string itemField;
        
        private ItemChoiceTypeX itemElementNameField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("URNIdentifikator", typeof(string), Order=0)]
        [System.Xml.Serialization.XmlElementAttribute("UUIDIdentifikator", typeof(string), Order=0)]
        [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemElementName")]
        public string Item {
            get {
                return this.itemField;
            }
            set {
                this.itemField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public ItemChoiceTypeX ItemElementName {
            get {
                return this.itemElementNameField;
            }
            set {
                this.itemElementNameField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="urn:oio:sagdok:3.0.0", IncludeInSchema=false)]
    public enum ItemChoiceTypeX {
        
        /// <remarks/>
        URNIdentifikator,
        
        /// <remarks/>
        UUIDIdentifikator,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="urn:oio:sagdok:3.0.0")]
    public enum AktoerTypeKodeTypeX {
        
        /// <remarks/>
        Organisation,
        
        /// <remarks/>
        OrganisationEnhed,
        
        /// <remarks/>
        OrganisationFunktion,
        
        /// <remarks/>
        Bruger,
        
        /// <remarks/>
        ItSystem,
        
        /// <remarks/>
        Interessefaellesskab,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="urn:oio:sts:sagdok:sagindeks:1.2.4.0")]
    [System.Xml.Serialization.XmlRootAttribute("SagsaktoerLokalUdvidelse", Namespace="urn:oio:sts:sagdok:sagindeks:1.2.4.0", IsNullable=false)]
    public partial class SagsaktoerLokalUdvidelseType {
        
        private string brugervendtNoegleField;
        
        private string fuldtNavnField;
        
        private string cVRNummerField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string BrugervendtNoegle {
            get {
                return this.brugervendtNoegleField;
            }
            set {
                this.brugervendtNoegleField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string FuldtNavn {
            get {
                return this.fuldtNavnField;
            }
            set {
                this.fuldtNavnField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("CVR-Nummer", Order=2)]
        public string CVRNummer {
            get {
                return this.cVRNummerField;
            }
            set {
                this.cVRNummerField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="urn:oio:sts:sagdok:sagindeks:1.2.4.0")]
    [System.Xml.Serialization.XmlRootAttribute("SagsklasseLokalUdvidelse", Namespace="urn:oio:sts:sagdok:sagindeks:1.2.4.0", IsNullable=false)]
    public partial class SagsklasseLokalUdvidelseType {
        
        private string facettitelField;
        
        private string klassetitelField;
        
        private string brugervendtNoegleField;
        
        private SoegeordType[] soegeordField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string Facettitel {
            get {
                return this.facettitelField;
            }
            set {
                this.facettitelField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string Klassetitel {
            get {
                return this.klassetitelField;
            }
            set {
                this.klassetitelField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string BrugervendtNoegle {
            get {
                return this.brugervendtNoegleField;
            }
            set {
                this.brugervendtNoegleField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Soegeord", Order=3)]
        public SoegeordType[] Soegeord {
            get {
                return this.soegeordField;
            }
            set {
                this.soegeordField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="urn:oio:sts:sagdok:sagindeks:1.2.4.0")]
    [System.Xml.Serialization.XmlRootAttribute("SagspartLokalUdvidelse", Namespace="urn:oio:sts:sagdok:sagindeks:1.2.4.0", IsNullable=false)]
    public partial class SagspartLokalUdvidelseType {
        
        private string brugervendtNoegleField;
        
        private string fuldtNavnField;
        
        private string cPRnrField;
        
        private string cVRnrField;
        
        private string sEnrField;
        
        private string pnrField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string BrugervendtNoegle {
            get {
                return this.brugervendtNoegleField;
            }
            set {
                this.brugervendtNoegleField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string FuldtNavn {
            get {
                return this.fuldtNavnField;
            }
            set {
                this.fuldtNavnField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("CPR-nr", Order=2)]
        public string CPRnr {
            get {
                return this.cPRnrField;
            }
            set {
                this.cPRnrField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("CVR-nr", Order=3)]
        public string CVRnr {
            get {
                return this.cVRnrField;
            }
            set {
                this.cVRnrField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SE-nr", Order=4)]
        public string SEnr {
            get {
                return this.sEnrField;
            }
            set {
                this.sEnrField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("P-nr", Order=5)]
        public string Pnr {
            get {
                return this.pnrField;
            }
            set {
                this.pnrField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="urn:oio:sts:sagdok:sagindeks:1.2.4.0")]
    [System.Xml.Serialization.XmlRootAttribute("SagsgenstandeLokalUdvidelse", Namespace="urn:oio:sts:sagdok:sagindeks:1.2.4.0", IsNullable=false)]
    public partial class SagsgenstandeLokalUdvidelseType {
        
        private string tekstfeltField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string Tekstfelt {
            get {
                return this.tekstfeltField;
            }
            set {
                this.tekstfeltField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="urn:oio:sts:sagdok:dokumentindeks:1.2.4.0")]
    [System.Xml.Serialization.XmlRootAttribute("DokumentaktoerLokalUdvidelse", Namespace="urn:oio:sts:sagdok:dokumentindeks:1.2.4.0", IsNullable=false)]
    public partial class DokumentaktoerLokalUdvidelseType {
        
        private string brugervendtNoegleField;
        
        private string fuldtNavnField;
        
        private string cVRNrField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string BrugervendtNoegle {
            get {
                return this.brugervendtNoegleField;
            }
            set {
                this.brugervendtNoegleField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string FuldtNavn {
            get {
                return this.fuldtNavnField;
            }
            set {
                this.fuldtNavnField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("CVR-Nr", Order=2)]
        public string CVRNr {
            get {
                return this.cVRNrField;
            }
            set {
                this.cVRNrField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="urn:oio:sts:sagdok:dokumentindeks:1.2.4.0")]
    [System.Xml.Serialization.XmlRootAttribute("DokumentpartLokalUdvidelse", Namespace="urn:oio:sts:sagdok:dokumentindeks:1.2.4.0", IsNullable=false)]
    public partial class DokumentpartLokalUdvidelseType {
        
        private string brugervendtNoegleField;
        
        private string fuldtNavnField;
        
        private string cPRnrField;
        
        private string cVRnrField;
        
        private string sEnrField;
        
        private string pnrField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string BrugervendtNoegle {
            get {
                return this.brugervendtNoegleField;
            }
            set {
                this.brugervendtNoegleField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string FuldtNavn {
            get {
                return this.fuldtNavnField;
            }
            set {
                this.fuldtNavnField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("CPR-nr", Order=2)]
        public string CPRnr {
            get {
                return this.cPRnrField;
            }
            set {
                this.cPRnrField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("CVR-nr", Order=3)]
        public string CVRnr {
            get {
                return this.cVRnrField;
            }
            set {
                this.cVRnrField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SE-nr", Order=4)]
        public string SEnr {
            get {
                return this.sEnrField;
            }
            set {
                this.sEnrField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("P-nr", Order=5)]
        public string Pnr {
            get {
                return this.pnrField;
            }
            set {
                this.pnrField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="urn:oio:sts:sagdok:dokumentindeks:1.2.4.0")]
    [System.Xml.Serialization.XmlRootAttribute("DokumentklasseLokalUdvidelse", Namespace="urn:oio:sts:sagdok:dokumentindeks:1.2.4.0", IsNullable=false)]
    public partial class DokumentklasseLokalUdvidelseType {
        
        private string klassetitelField;
        
        private string brugervendtNoegleField;
        
        private SoegeordType1[] soegeordField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string Klassetitel {
            get {
                return this.klassetitelField;
            }
            set {
                this.klassetitelField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string BrugervendtNoegle {
            get {
                return this.brugervendtNoegleField;
            }
            set {
                this.brugervendtNoegleField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Soegeord", Order=2)]
        public SoegeordType1[] Soegeord {
            get {
                return this.soegeordField;
            }
            set {
                this.soegeordField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(TypeName="SoegeordType", Namespace="urn:oio:sts:sagdok:dokumentindeks:1.2.4.0")]
    public partial class SoegeordType1 {
        
        private string soegeordIdentifikatorField;
        
        private string beskrivelseField;
        
        private string soegeordKategoriField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string SoegeordIdentifikator {
            get {
                return this.soegeordIdentifikatorField;
            }
            set {
                this.soegeordIdentifikatorField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string Beskrivelse {
            get {
                return this.beskrivelseField;
            }
            set {
                this.beskrivelseField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string SoegeordKategori {
            get {
                return this.soegeordKategoriField;
            }
            set {
                this.soegeordKategoriField = value;
            }
        }
    }
}
