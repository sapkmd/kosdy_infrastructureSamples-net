﻿using Kombit.InfrastructureSamples.Klassifikation;
using Kombit.InfrastructureSamples.SagDokumentIndeksService;
using Kombit.InfrastructureSamples.Token;
using System;
using System.IdentityModel.Tokens;
using System.Net.Security;
using System.ServiceModel;

namespace Kombit.InfrastructureSamples.SagDokumentIndeks
{
    /// <summary>
    /// Class for handling requests to SagDokumentIndeksService
    /// </summary>
    internal class SagDokumentIndeks {

        private SecurityToken token;
        private SagDokumentIndeksPortType port;

        /// <summary> 
        /// Imports a case to the SagDokumentIndeks.
        /// Uses input variables defined in ConfigVariables. 
        /// </summary>
        /// <param name="sagUuid">The UUID of the imported case</param>
        /// <returns>Prints status code and status text to the console</returns>
        internal void Importer(string sagUuid) {
             
            //Class instances 
            var virksomhed = new Virksomhed.Virksomhed();
            var organisation = new Organisation.Organisation();
            var klassifikation = new Klasse();

            // Preparing the import 
             
            // The case must be related to an Organisation object in Fælleskommunalt Organisationssystem.
          
                // We want to find the Organisation object based on the CVR-number of the test municipality.
                // First we need to find the Virksomhed object in Fælleskommunalt Organisationssystem which holds the CVR
                var virksomhedUuid = virksomhed.GetVirksomhedUuid(ConfigVariables.MYNDIGHEDS_CVR);            
          
                // Next we need to find the Organisation object related to the Virksomhed object. 
                // The UUID of the Organisation object will be used when we relate the case to the municipality organisation.
                var org = organisation.GetOrganisationUuidName(virksomhedUuid);
                var organisationUuid = org.Key;
                var organisationNavn = org.Value;  

            // The case must be related to a Klasse object in Fælleskommunalt Klassifikationssystem which represents a KLE Emne
            // We want to find the Klasse object based on the name (brugervendt nøgle) of the KLE Emne.
          
                var emne = klassifikation.GetKlasseUuidName(ConfigVariables.KLE_KLASSE);
                var emneUuid = emne.Key;
                var emneKlasseTitel = emne.Value;

            // The case must be related to a Klasse object in Fælleskommunalt Klassifikationssystem which represents a KLE Handlingsfacet
            // We want to find the Klasse object based on the name (brugervendt nøgle) of the KLE Handlingsfacet.
         
                var handlingsfacet = klassifikation.GetKlasseUuidName(ConfigVariables.KLE_HANDLINGSFACET); 
                var facetUuid = handlingsfacet.Key;
                var facetKlasseTitel = handlingsfacet.Value;

            // Write the variables to the console 
            Console.WriteLine("\nPreparations before importing the case...\n"); 
            Console.WriteLine("Myndighed CVR: {0}\n *Virksomhed UUID: {1}\n *Organisation UUID: {2}\n *Organisation Navn: {3}\n", ConfigVariables.MYNDIGHEDS_CVR, virksomhedUuid, organisationUuid, organisationNavn);
            Console.WriteLine("KLE emne: {0}\n *Klasse UUID: {1}\n *Klassetitel: {2}\n", ConfigVariables.KLE_KLASSE, emneUuid, emneKlasseTitel);
            Console.WriteLine("KLE handlingsfacet: {0}\n *Klasse UUID: {1}\n *Klassetitel: {2}\n", ConfigVariables.KLE_HANDLINGSFACET, facetUuid, facetKlasseTitel);

            // Now we are ready to import the case

            importerRequest request = new importerRequest()
            {
                ImporterRequest1 = new ImporterRequestType()
                {
                    ImporterSagDokumentIndeksInput = new SagDokObjektType[] {
                        new SagType() {
                            UUIDIdentifikator = sagUuid,
                            Registrering = new RegistreringType2[] {
                                new RegistreringType2() {
                                    Tidspunkt = ConfigVariables.SAG_TIDSPUNKT,
                                    TidspunktSpecified = true,
                                    LivscyklusKode = LivscyklusKodeType.Importeret, // Constant
                                    LivscyklusKodeSpecified = true,
                                    BrugerRef = new UnikIdType() {
                                        Item = ConfigVariables.AKTOER_REF, 
                                        ItemElementName = ItemChoiceType.UUIDIdentifikator
                                    },
                                    AttributListe = new AttributListeType1() {
                                        Egenskaber = new EgenskaberType1[] {
                                            new EgenskaberType1() {
                                                BrugervendtNoegle = ConfigVariables.SAGS_NUMMER,
                                                Sagsnummer = ConfigVariables.SAGS_NUMMER,
                                                Titel = ConfigVariables.SAGS_TITEL,
                                                Virkning = CreateVirkningNowToEternity()
                                            }
                                        },
                                        LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                            Udvidelse = new EgenskaberTypeSag[] {
                                                new EgenskaberTypeSag() {
                                                    
                                                    Foelsomhed = FoelsomhedTypeX.IKKE_FORTROLIGE_DATA, // Can be changed depending on the sensitivity of the data
                                                    FoelsomhedSpecified = true,
                                                    Virkning = new VirkningTypeX() {
                                                        AktoerRef = new UnikIdTypeX() {
                                                            Item = ConfigVariables.AKTOER_REF,
                                                            ItemElementName = ItemChoiceTypeX.UUIDIdentifikator
                                                        },
                                                        AktoerTypeKode = AktoerTypeKodeTypeX.Bruger,
                                                        AktoerTypeKodeSpecified = true,
                                                        FraTidspunkt = new TidspunktTypeX() {
                                                            Item = DateTime.Now
                                                        },
                                                        TilTidspunkt = new TidspunktTypeX() {
                                                            Item = true
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    },
                                    TilstandListe = new TilstandListeType1() {
                                        Fremdrift = new FremdriftType1[] {
                                            // List here all the states in the case. The possible states can be seen in the enum FremdriftStatusKodeType1
                                            new FremdriftType1() {
                                                FremdriftStatusKode = FremdriftStatusKodeType1.Opstaaet,
                                                FremdriftStatusKodeSpecified = true,
                                                Virkning = new VirkningType() {
                                                    AktoerRef = new UnikIdType() {
                                                        Item = ConfigVariables.AKTOER_REF,
                                                        ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                    },
                                                    AktoerTypeKode = AktoerTypeKodeType.Bruger,
                                                    AktoerTypeKodeSpecified = true,
                                                    FraTidspunkt = new TidspunktType() {
                                                        Item = ConfigVariables.SAG_OPRETTET // The state created (opstaaet) starts at this time
                                                    },
                                                    TilTidspunkt = new TidspunktType() {
                                                        Item = ConfigVariables.SAG_LUKKET // The state created (opstaaet) ends at this time, because it is no longer valid
                                                    }
                                                }
                                            },
                                            new FremdriftType1() {
                                                FremdriftStatusKode = FremdriftStatusKodeType1.Afsluttet,
                                                FremdriftStatusKodeSpecified = true,
                                                Virkning = new VirkningType() {
                                                    AktoerRef = new UnikIdType() {
                                                        Item = ConfigVariables.AKTOER_REF,
                                                        ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                    },
                                                    AktoerTypeKode = AktoerTypeKodeType.Bruger,
                                                    AktoerTypeKodeSpecified = true,
                                                    FraTidspunkt = new TidspunktType() {
                                                        Item = ConfigVariables.SAG_LUKKET // The state finished (afsluttet) starts at this time
                                                    },
                                                    TilTidspunkt = new TidspunktType() {
                                                        Item = true // The state finished (afsluttet) never ends
                                                    }
                                                }
                                            }
                                        }
                                    },
                                    RelationListe = new RelationListeType1() {
                                        Sagsaktoer = new RelationType[] {
                                            // The case owner (Ejer) 
                                            CreateRelationWithUdvidelse(
                                                ConfigVariables.EJER_ROLLE_UUID,
                                                ConfigVariables.EJER_ORGANISATION_TYPE_UUID,
                                                organisationUuid, // The UUID from searching Organisation CVR earlier
                                                null, 
                                                new SagsaktoerLokalUdvidelseType() {
                                                    CVRNummer = ConfigVariables.MYNDIGHEDS_CVR,
                                                    FuldtNavn = ConfigVariables.MYNDIGHEDS_NAVN
                                                }
                                            ),
                                            // The case responsible (Ansvarlig) 
                                            CreateRelationWithUdvidelse(
                                                ConfigVariables.ANSVARLIG_ROLLE_UUID,
                                                ConfigVariables.ANSVARLIG_ORGANISATIONSENHED_TYPE_UUID,
                                                ConfigVariables.ORGANISATIONS_ENHED_UUID, // The UUID for the responsible entity
                                                null, 
                                                new SagsaktoerLokalUdvidelseType() {
                                                    CVRNummer = ConfigVariables.MYNDIGHEDS_CVR,
                                                    FuldtNavn = ConfigVariables.ORGANISATIONS_ENHED_NAVN
                                                }
                                            ),
                                            // The case primary case worker (Primaer behandler) 
                                            CreateRelationWithUdvidelse(
                                                ConfigVariables.PRIMAER_BEHANDLER_ROLLE_UUID,
                                                ConfigVariables.BRUGER_TYPE_UUID,
                                                ConfigVariables.PRIMAER_BEHANDLER_UUID, // The UUID of the primary case worker
                                                null, 
                                                new SagsaktoerLokalUdvidelseType() {
                                                    CVRNummer = ConfigVariables.MYNDIGHEDS_CVR,
                                                    FuldtNavn = ConfigVariables.PRIMAER_BEHANDLER_NAVN
                                                }
                                            )
                                        },
                                        Sagspart = new RelationType[] {
                                            // The primary part (Primaer part) 
                                            CreateRelationWithUdvidelse(
                                                ConfigVariables.PRIMAER_PART_ROLLE_UUID,
                                                ConfigVariables.PERSON_TYPE_UUID,
                                                null,
                                                ConfigVariables.PRIMAER_PART_CPR, // The CPR of the primary client 
                                                new SagspartLokalUdvidelseType() {
                                                    FuldtNavn = ConfigVariables.PRIMAER_PART_NAVN
                                                }
                                            )
                                        },
                                        Sagsklasse = new RelationType[] {
                                            // The primary class (primaer klasse) 
                                            CreateRelationWithUdvidelse(
                                                ConfigVariables.PRIMAER_KLASSE_ROLLE_UUID,
                                                ConfigVariables.KLASSE_TYPE_UUID,
                                                emneUuid, // The UUID from searching kleKlasse earlier
                                                null, 
                                                new SagsklasseLokalUdvidelseType() {
                                                    BrugervendtNoegle = ConfigVariables.KLE_KLASSE,
                                                    Facettitel = ConfigVariables.KLASSE_FACET_TITEL, // Constant, not required although it is good practice
                                                    Klassetitel = emneKlasseTitel // Derived earlier, not required although it is good practice
                                                }
                                            ),
                                            // The Handlingsklasse (Handlingsklasse)
                                            CreateRelationWithUdvidelse(
                                                ConfigVariables.HANDLINGSKLASSE_ROLLE_UUID,
                                                ConfigVariables.KLASSE_TYPE_UUID,
                                                facetUuid, // The UUID from searching kleHandlingsfacet earlier
                                                null, 
                                                new SagsklasseLokalUdvidelseType() {
                                                    BrugervendtNoegle = ConfigVariables.KLE_HANDLINGSFACET,
                                                    Facettitel = ConfigVariables.HANDLINGS_KLASSE_FACET_TITEL, // Constant, not required although it is good practice
                                                    Klassetitel = facetKlasseTitel // Derived earlier, not required although it is good practice
                                                }
                                            )
                                        },
                                        Sagsarkiv = new RelationType[] {
                                            // The archive (Behandlingsarkiv) 
                                            CreateRelation(
                                                ConfigVariables.BEHANDLINGSARKIV_ROLLE_UUID,
                                                ConfigVariables.ARKIV_TYPE_UUID,
                                                ConfigVariables.ANVENDER_SYSTEM_UUID, // The UUID of your IT-system
                                                null  
                                            )
                                        },
                                        LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                            Udvidelse = new SagsitsystemRelationType[] {
                                                // The master IT-system (IT-system Master)
                                                new SagsitsystemRelationType() {
                                                    Rolle = new UnikIdType() {
                                                        Item = ConfigVariables.MASTER_UUID, // Constant for Master
                                                        ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                    },
                                                    Type = new UnikIdType() {
                                                        Item = ConfigVariables.IT_SYSTEM_TYPE_UUID, // Constant for IT-system
                                                        ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                    },
                                                    ReferenceID = new UnikIdType() {
                                                        Item = ConfigVariables.ANVENDER_SYSTEM_UUID, // The UUID of your IT-system
                                                        ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                    },
                                                    SystemNavn = ConfigVariables.ANVENDER_SYSTEM_NAVN,
                                                    Virkning = CreateVirkningNowToEternity()
                                                },
                                                // The sender IT-system (IT-system Afsender) 
                                                new SagsitsystemRelationType() {
                                                    Rolle = new UnikIdType() {
                                                        Item = ConfigVariables.AFSENDER_TYPE_UUID, // Constant for Afsender
                                                        ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                    },
                                                    Type = new UnikIdType() {
                                                        Item = ConfigVariables.IT_SYSTEM_TYPE_UUID, // Constant for IT-system
                                                        ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                    },
                                                    ReferenceID = new UnikIdType() {
                                                        Item = ConfigVariables.ANVENDER_SYSTEM_UUID, // The UUID of your IT-system
                                                        ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                    },
                                                    SystemNavn = ConfigVariables.ANVENDER_SYSTEM_NAVN, // The name of your IT-system
                                                    Virkning = CreateVirkningNowToEternity()
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                },
                RequestHeader = RequestHeader
            };
            // End of the Importer Request 

            // The Port is used to cache the Token 
            importerResponse response = Port.importer(request);

            // Prints response in the console
            foreach (var item in response.ImporterResponse1.ImporterSagDokumentIndeksOutput.Items)
            {
                Console.WriteLine("Importing Case...\n *Status: {0}\n *StatusText: {1}\n", item.StatusKode, item.FejlbeskedTekst);
            }
        }

        /// <summary>
        /// Searches for a case in SagDokumentIndeks.
        /// Outputs status code and status text.
        /// Outputs case number if a case is found.
        /// </summary>
        /// <param name="uuid">The UUID of the case</param>
        internal void Fremsoeg(string uuid) {
            fremsoegRequest request = new fremsoegRequest() {
                FremsoegRequest1 = new FremsoegRequestType() {
                    FremsoegSagDokumentIndeksInput = new FremsoegSagDokumentIndeksInputType() {
                        SagUuid = new string[] {
                            uuid
                        },
                        // The filter allows us to see egenskaber of the case (Sag) which mean we can get the case number below
                        Filter = new object[] {
                            new SagVisType()
                            {
                               Vis = SagVisFilterType.egenskaber
                            }
                        }

                    } 
                },
                RequestHeader = RequestHeader
            };

            // The Port is used to cache the Token 
            fremsoegResponse response = Port.fremsoeg(request);

            // Prints standard response in the console
            var retur = response.FremsoegResponse1.FremsoegSagDokumentIndeksOutput.StandardRetur;
            Console.WriteLine("Searching for case by UUID...\n *Status: {0}\n *StatusText: {1}", retur.StatusKode, retur.FejlbeskedTekst);
            
            // The case number (Sagsnummer) is only printed if a case is found 
            if (response.FremsoegResponse1.FremsoegSagDokumentIndeksOutput.Antal != null
                && response.FremsoegResponse1.FremsoegSagDokumentIndeksOutput.Antal.Length > 0)
            {
                // The case number (Sagsnummer) is retrieved from the returned XML
                var sagsNummer = response.FremsoegResponse1.FremsoegSagDokumentIndeksOutput.SagFiltreretOejebliksbillede[0].
                Registrering[0].AttributListe.Egenskaber[0].Sagsnummer;
                Console.WriteLine(" *Case Number: " + sagsNummer + "\n");
            }

        }

        /// <summary> 
        /// Removes a case in the SagDokumentIndeks
        /// Outputs status code and status text to the console
        /// </summary>
        /// <param name="uuid">The UUID of the case to remove</param>
        internal void Fjern(string uuid) {
            fjernRequest request = new fjernRequest() {
                FjernRequest1 = new FjernRequestType() {
                    FjernSagDokumentIndeksInput = new FjernSagDokumentIndeksInputType() {
                        Items = new UnikIdType[] {
                            new UnikIdType() {
                                Item = uuid,
                                ItemElementName = ItemChoiceType.UUIDIdentifikator
                            }
                        }
                    }
                },
                RequestHeader = RequestHeader
            };

            // The Port is used to cache the Token
            fjernResponse response = Port.fjern(request);

            // Prints response in the console
            foreach (var item in response.FjernResponse1.FjernSagDokumentIndeksOutput.Items) {
                Console.WriteLine("Removing case...\n *Status: {0}\n *Statustext: {1}\n", item.StatusKode, item.FejlbeskedTekst);
            }
        }

        /// <summary>
        /// Creates a Virkning that starts now and never ends
        /// </summary>
        /// <param name="uuid">The UUID of the case registrar</param>
        /// <returns></returns>
        private VirkningType CreateVirkningNowToEternity() {
            return new VirkningType() {
                AktoerRef = new UnikIdType() {
                    Item = ConfigVariables.AKTOER_REF,
                    ItemElementName = ItemChoiceType.UUIDIdentifikator
                },
                AktoerTypeKode = AktoerTypeKodeType.Bruger,
                AktoerTypeKodeSpecified = true,
                FraTidspunkt = new TidspunktType() {
                    Item = DateTime.Now
                },
                TilTidspunkt = new TidspunktType() {
                    Item = true
                }
            };
        }

        /// <summary>
        /// Creates a relation
        /// </summary>
        /// <param name="rolleUuid">The UUID of the role</param>
        /// <param name="typeUuid">The UUID of the type</param>
        /// <param name="referenceUuid">The UUID of the reference. Should be null if the reference is by URN!</param>
        /// <param name="referenceUrn">The URN of the reference. Should be null if the reference is by UUID!</param>
        /// <param name="virkningUuid">The UUID to pass on to the Virkning which is the case registrar</param>
        /// <returns></returns>
        private RelationType CreateRelation(string rolleUuid, string typeUuid, string referenceUuid, string referenceUrn) {
            return new RelationType() {
                Rolle = new UnikIdType() {
                    Item = rolleUuid,
                    ItemElementName = ItemChoiceType.UUIDIdentifikator
                },
                Type = new UnikIdType() {
                    Item = typeUuid,
                    ItemElementName = ItemChoiceType.UUIDIdentifikator
                },
                ReferenceID = new UnikIdType() {
                    Item = referenceUuid != null ? referenceUuid : referenceUrn,
                    ItemElementName = referenceUuid != null ? ItemChoiceType.UUIDIdentifikator : ItemChoiceType.URNIdentifikator
                },
                Virkning = CreateVirkningNowToEternity()
            };
        }

        /// <summary>
        /// Creates a relation with a LokalUdvidelse
        /// </summary>
        /// <param name="rolleUuid">The UUID of the role</param>
        /// <param name="typeUuid">The UUID of the type</param>
        /// <param name="referenceUuid">The UUID of the reference. Should be null if the reference is by URN!</param>
        /// <param name="referenceUrn">The URN of the reference. Should be null if the reference is by UUID!</param>
        /// <param name="virkningUuid">The UUID to pass on to the Virkning which is the case registrar</param>
        /// <param name="udvidelse">The LokalUdvidelse</param>
        /// <returns></returns>
        private RelationType CreateRelationWithUdvidelse(string rolleUuid, string typeUuid, string referenceUuid, string referenceUrn, object udvidelse) {
            RelationType relation = CreateRelation(rolleUuid, typeUuid, referenceUuid, referenceUrn);
            relation.LokalUdvidelseListe = new LokalUdvidelseListeType() {
                Udvidelse = new object[] {
                    udvidelse
                }
            };

            return relation;
        }

        #region Port and token helper methods

        /// <summary>
        /// The Port property used to send requests. Creates a new port only if it doesn't already exist, or the token has expired
        /// </summary>
        private SagDokumentIndeksPortType Port {
            get {
                if (port == null || TokenFetcher.IsTokenExpired(token)) {
                    port = CreatePort();
                }

                return port;
            }
            set {
                port = value;
            }
        }

        /// <summary>
        /// Creates the port by getting a token, setting the endpoint and loading the certificates.
        /// </summary>
        /// <returns></returns>
        private SagDokumentIndeksPortType CreatePort() {
            token = TokenFetcher.IssueToken(ConfigVariables.SagDokServiceEntityId);
            SagDokumentIndeksPortTypeClient client = new SagDokumentIndeksPortTypeClient();

            EndpointIdentity identity = EndpointIdentity.CreateDnsIdentity(ConfigVariables.ServiceCertificateAlias);
            EndpointAddress endpointAddress = new EndpointAddress(client.Endpoint.ListenUri, identity);
            client.Endpoint.Address = endpointAddress;
            var certificate = CertificateLoader.LoadCertificate(
                ConfigVariables.ClientCertificateStoreName,
                ConfigVariables.ClientCertificateStoreLocation,
                ConfigVariables.ClientCertificateThumbprint
            );
            client.ClientCredentials.ClientCertificate.Certificate = certificate;

            // This sets the MINIMUM level. Since the request header should not be signed, we set it to none.
            client.Endpoint.Contract.ProtectionLevel = ProtectionLevel.None;

            return client.ChannelFactory.CreateChannelWithIssuedToken(token);
        }

        /// <summary>
        /// Creates the request header which is simply a random UUID
        /// </summary>
        private RequestHeaderType RequestHeader {
            get {
                return new RequestHeaderType() {
                    TransactionUUID = Guid.NewGuid().ToString()
                };
            }
        }

        #endregion
    }
}
