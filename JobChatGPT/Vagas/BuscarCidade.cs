
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace JobChatGPT.Vagas
{
    public class BuscarCidade
    {
        private List<string> estados;
        private List<string> cidades;
        Dictionary<string, string> SiglaEstados;
        Dictionary<string, List<string>> estadosCidade;

        public BuscarCidade()
        {
            this.cidades = new List<string>();
            this.estados = new List<string>();
            this.SiglaEstados = new Dictionary<string, string>();
            this.estadosCidade = new Dictionary<string, List<string>>();

            #region Lista de Estados
            estados.AddRange(new List<string> { "Acre",
                                                "Alagoas",
                                                "Amapá",
                                                "Amazonas",
                                                "Bahia",
                                                "Ceará",
                                                "Distrito Federal",
                                                "Espírito Santo",
                                                "Goiás",
                                                "Maranhão",
                                                "Mato Grosso",
                                                "Mato Grosso do Sul",
                                                "Minas Gerais",
                                                "Pará",
                                                "Paraíba",
                                                "Paraná",
                                                "Pernambuco",
                                                "Piauí",
                                                "Rio de Janeiro",
                                                "Rio Grande do Norte",
                                                "Rio Grande do Sul",
                                                "Rondônia",
                                                "Roraima",
                                                "Santa Catarina",
                                                "São Paulo",
                                                "Sergipe",
                                                "Tocantins"
            });
            #endregion

            #region Lista de Siglas de Estados
            SiglaEstados.Add("AC", "Rio Branco");
            SiglaEstados.Add("AL", "Maceió");
            SiglaEstados.Add("AP", "Macapá");
            SiglaEstados.Add("AM", "Manaus");
            SiglaEstados.Add("BA", "Salvador");
            SiglaEstados.Add("CE", "Fortaleza");
            SiglaEstados.Add("DF", "Brasília");
            SiglaEstados.Add("ES", "Vitória");
            SiglaEstados.Add("GO", "Goiânia");
            SiglaEstados.Add("MA", "São Luís");
            SiglaEstados.Add("MT", "Cuiabá");
            SiglaEstados.Add("MS", "Campo Grande");
            SiglaEstados.Add("MG", "Belo Horizonte");
            SiglaEstados.Add("PA", "Belém");
            SiglaEstados.Add("PB", "João Pessoa");
            SiglaEstados.Add("PR", "Curitiba");
            SiglaEstados.Add("PE", "Recife");
            SiglaEstados.Add("PI", "Teresina");
            SiglaEstados.Add("RJ", "Rio de Janeiro");
            SiglaEstados.Add("RN", "Natal");
            SiglaEstados.Add("RS", "Porto Alegre");
            SiglaEstados.Add("RO", "Porto Velho");
            SiglaEstados.Add("RR", "Boa Vista");
            SiglaEstados.Add("SC", "Florianópolis");
            SiglaEstados.Add("SP", "São Paulo");
            SiglaEstados.Add("SE", "Aracaju");
            SiglaEstados.Add("TO", "Palmas");
            #endregion

            #region lista de Cidades
            cidades.AddRange(new List<string> {
                //Acre - AC
                "ACRELANDIA",
                "ASSIS BRASIL",
                "BRASILEIA",
                "BUJARI",
                "CAPIXABA",
                "CRUZEIRO DO SUL",
                "EPITACIOLANDIA",
                "FEIJO",
                "JORDAO",
                "MANCIO LIMA",
                "MANOEL URBANO",
                "MARECHAL THAUMATURGO",
                "PLACIDO DE CASTRO",
                "PORTO ACRE",
                "PORTO WALTER",
                "RIO BRANCO",
                "RODRIGUES ALVES",
                "SANTA ROSA DO PURUS",
                "SENA MADUREIRA",
                "SENADOR GUIOMARD",
                "TARAUACA",
                "XAPURI"
                //Alagoas - AL
                    ,
                "AGUA BRANCA",
                "ANADIA",
                "ARAPIRACA",
                "ATALAIA",
                "BARRA DE SANTO ANTONIO",
                "BARRA DE SAO MIGUEL",
                "BATALHA",
                "BELEM",
                "BELO MONTE",
                "BOCA DA MATA",
                "BRANQUINHA",
                "CACIMBINHAS",
                "CAJUEIRO",
                "CAMPESTRE",
                "CAMPO ALEGRE",
                "CAMPO GRANDE",
                "CANAPI",
                "CAPELA",
                "CARNEIROS",
                "CHA PRETA",
                "COITE DO NOIA",
                "COLONIA LEOPOLDINA",
                "COQUEIRO SECO",
                "CORURIPE",
                "CRAIBAS",
                "DELMIRO GOUVEIA",
                "DOIS RIACHOS",
                "ESTRELA DE ALAGOAS",
                "FEIRA GRANDE",
                "FELIZ DESERTO",
                "FLEXEIRAS",
                "GIRAU DO PONCIANO",
                "IBATEGUARA",
                "IGACI",
                "IGREJA NOVA",
                "INHAPI",
                "JACARE DOS HOMENS",
                "JACUIPE",
                "JAPARATINGA",
                "JARAMATAIA",
                "JEQUIA DA PRAIA",
                "JOAQUIM GOMES",
                "JUNDIA",
                "JUNQUEIRO",
                "LAGOA DA CANOA",
                "LIMOEIRO DE ANADIA",
                "MACEIO",
                "MAJOR ISIDORO",
                "MAR VERMELHO",
                "MARAGOGI",
                "MARAVILHA",
                "MARECHAL DEODORO",
                "MARIBONDO",
                "MATA GRANDE",
                "MATRIZ DE CAMARAGIBE",
                "MESSIAS",
                "MINADOR DO NEGRAO",
                "MONTEIROPOLIS",
                "MURICI",
                "NOVO LINO",
                "OLHO D'AGUA DAS FLORES",
                "OLHO D'AGUA DO CASADO",
                "OLHO D'AGUA GRANDE",
                "OLIVENCA",
                "OURO BRANCO",
                "PALESTINA",
                "PALMEIRA DOS INDIOS",
                "PAO DE ACUCAR",
                "PARICONHA",
                "PARIPUEIRA",
                "PASSO DE CAMARAGIBE",
                "PAULO JACINTO",
                "PENEDO",
                "PIACABUCU",
                "PILAR",
                "PINDOBA",
                "PIRANHAS",
                "POCO DAS TRINCHEIRAS",
                "PORTO CALVO",
                "PORTO DE PEDRAS",
                "PORTO REAL DO COLEGIO",
                "QUEBRANGULO",
                "RIO LARGO",
                "ROTEIRO",
                "SANTA LUZIA DO NORTE",
                "SANTANA DO IPANEMA",
                "SANTANA DO MUNDAU",
                "SAO BRAS",
                "SAO JOSE DA LAJE",
                "SAO JOSE DA TAPERA",
                "SAO LUIS DO QUITUNDE",
                "SAO MIGUEL DOS CAMPOS",
                "SAO MIGUEL DOS MILAGRES",
                "SAO SEBASTIAO",
                "SATUBA",
                "SENADOR RUI PALMEIRA",
                "TANQUE D'ARCA",
                "TAQUARANA",
                "TEOTONIO VILELA",
                "TRAIPU",
                "UNIAO DOS PALMARES",
                "VICOSA"
                //Amazonas - AM
                    ,
                "ALVARAES",
                "AMATURA",
                "ANAMA",
                "ANORI",
                "APUI",
                "ATALAIA DO NORTE",
                "AUTAZES",
                "BARCELOS",
                "BARREIRINHA",
                "BENJAMIN CONSTANT",
                "BERURI",
                "BOA VISTA DO RAMOS",
                "BOCA DO ACRE",
                "BORBA",
                "CAAPIRANGA",
                "CANUTAMA",
                "CARAUARI",
                "CAREIRO",
                "CAREIRO DA VARZEA",
                "COARI",
                "CODAJAS",
                "EIRUNEPE",
                "ENVIRA",
                "FONTE BOA",
                "GUAJARA",
                "HUMAITA",
                "IPIXUNA",
                "IRANDUBA",
                "ITACOATIARA",
                "ITAMARATI",
                "ITAPIRANGA",
                "JAPURA",
                "JURUA",
                "JUTAI",
                "LABREA",
                "MANACAPURU",
                "MANAQUIRI",
                "MANAUS",
                "MANICORE",
                "MARAA",
                "MAUES",
                "NHAMUNDA",
                "NOVA OLINDA DO NORTE",
                "NOVO AIRAO",
                "NOVO ARIPUANA",
                "PARINTINS",
                "PAUINI",
                "PRESIDENTE FIGUEIREDO",
                "RIO PRETO DA EVA",
                "SANTA ISABEL DO RIO NEGRO",
                "SANTO ANTONIO DO ICA",
                "SAO GABRIEL DA CACHOEIRA",
                "SAO PAULO DE OLIVENCA",
                "SAO SEBASTIAO DO UATUMA",
                "SILVES",
                "TABATINGA",
                "TAPAUA",
                "TEFE",
                "TONANTINS",
                "UARINI",
                "URUCARA",
                "URUCURITUBA"
                //Amapá - AP
                    ,
                "AMAPA",
                "CALCOENE",
                "CUTIAS",
                "FERREIRA GOMES",
                "ITAUBAL",
                "LARANJAL DO JARI",
                "MACAPA",
                "MAZAGAO",
                "OIAPOQUE",
                "PEDRA BRANCA DO AMAPARI",
                "PORTO GRANDE",
                "PRACUUBA",
                "SANTANA",
                "SERRA DO NAVIO",
                "TARTARUGALZINHO",
                "VITORIA DO JARI"
                //Bahia - BA
                    ,
                "ABAIRA",
                "ABARE",
                "ACAJUTIBA",
                "ADUSTINA",
                "AGUA FRIA",
                "AIQUARA",
                "ALAGOINHAS",
                "ALCOBACA",
                "ALMADINA",
                "AMARGOSA",
                "AMELIA RODRIGUES",
                "AMERICA DOURADA",
                "ANAGE",
                "ANDARAI",
                "ANDORINHA",
                "ANGICAL",
                "ANGUERA",
                "ANTAS",
                "ANTONIO CARDOSO",
                "ANTONIO GONCALVES",
                "APORA",
                "APUAREMA",
                "ARACAS",
                "ARACATU",
                "ARACI",
                "ARAMARI",
                "ARATACA",
                "ARATUIPE",
                "AURELINO LEAL",
                "BAIANOPOLIS",
                "BAIXA GRANDE",
                "BANZAE",
                "BARRA",
                "BARRA DA ESTIVA",
                "BARRA DO CHOCA",
                "BARRA DO MENDES",
                "BARRA DO ROCHA",
                "BARREIRAS",
                "BARRO ALTO",
                "BARROCAS",
                "BARRO PRETO",
                "BELMONTE",
                "BELO CAMPO",
                "BIRITINGA",
                "BOA NOVA",
                "BOA VISTA DO TUPIM",
                "BOM JESUS DA LAPA",
                "BOM JESUS DA SERRA",
                "BONINAL",
                "BONITO",
                "BOQUIRA",
                "BOTUPORA",
                "BREJOES",
                "BREJOLANDIA",
                "BROTAS DE MACAUBAS",
                "BRUMADO",
                "BUERAREMA",
                "BURITIRAMA",
                "CAATIBA",
                "CABACEIRAS DO PARAGUACU",
                "CACHOEIRA",
                "CACULE",
                "CAEM",
                "CAETANOS",
                "CAETITE",
                "CAFARNAUM",
                "CAIRU",
                "CALDEIRAO GRANDE",
                "CAMACAN",
                "CAMACARI",
                "CAMAMU",
                "CAMPO ALEGRE DE LOURDES",
                "CAMPO FORMOSO",
                "CANAPOLIS",
                "CANARANA",
                "CANAVIEIRAS",
                "CANDEAL",
                "CANDEIAS",
                "CANDIBA",
                "CANDIDO SALES",
                "CANSANCAO",
                "CANUDOS",
                "CAPELA DO ALTO ALEGRE",
                "CAPIM GROSSO",
                "CARAIBAS",
                "CARAVELAS",
                "CARDEAL DA SILVA",
                "CARINHANHA",
                "CASA NOVA",
                "CASTRO ALVES",
                "CATOLANDIA",
                "CATU",
                "CATURAMA",
                "CENTRAL",
                "CHORROCHO",
                "CICERO DANTAS",
                "CIPO",
                "COARACI",
                "COCOS",
                "CONCEICAO DA FEIRA",
                "CONCEICAO DO ALMEIDA",
                "CONCEICAO DO COITE",
                "CONCEICAO DO JACUIPE",
                "CONDE",
                "CONDEUBA",
                "CONTENDAS DO SINCORA",
                "CORACAO DE MARIA",
                "CORDEIROS",
                "CORIBE",
                "CORONEL JOAO SA",
                "CORRENTINA",
                "COTEGIPE",
                "CRAVOLANDIA",
                "CRISOPOLIS",
                "CRISTOPOLIS",
                "CRUZ DAS ALMAS",
                "CURACA",
                "DARIO MEIRA",
                "DIAS D'AVILA",
                "DOM BASILIO",
                "DOM MACEDO COSTA",
                "ELISIO MEDRADO",
                "ENCRUZILHADA",
                "ENTRE RIOS",
                "ERICO CARDOSO",
                "ESPLANADA",
                "EUCLIDES DA CUNHA",
                "EUNAPOLIS",
                "FATIMA",
                "FEIRA DA MATA",
                "FEIRA DE SANTANA",
                "FILADELFIA",
                "FIRMINO ALVES",
                "FLORESTA AZUL",
                "FORMOSA DO RIO PRETO",
                "GANDU",
                "GAVIAO",
                "GENTIO DO OURO",
                "GLORIA",
                "GONGOGI",
                "GOVERNADOR MANGABEIRA",
                "GUAJERU",
                "GUANAMBI",
                "GUARATINGA",
                "HELIOPOLIS",
                "IACU",
                "IBIASSUCE",
                "IBICARAI",
                "IBICOARA",
                "IBICUI",
                "IBIPEBA",
                "IBIPITANGA",
                "IBIQUERA",
                "IBIRAPITANGA",
                "IBIRAPUA",
                "IBIRATAIA",
                "IBITIARA",
                "IBITITA",
                "IBOTIRAMA",
                "ICHU",
                "IGAPORA",
                "IGRAPIUNA",
                "IGUAI",
                "ILHEUS",
                "INHAMBUPE",
                "IPECAETA",
                "IPIAU",
                "IPIRA",
                "IPUPIARA",
                "IRAJUBA",
                "IRAMAIA",
                "IRAQUARA",
                "IRARA",
                "IRECE",
                "ITABELA",
                "ITABERABA",
                "ITABUNA",
                "ITACARE",
                "ITAETE",
                "ITAGI",
                "ITAGIBA",
                "ITAGIMIRIM",
                "ITAGUACU DA BAHIA",
                "ITAJU DO COLONIA",
                "ITAJUIPE",
                "ITAMARAJU",
                "ITAMARI",
                "ITAMBE",
                "ITANAGRA",
                "ITANHEM",
                "ITAPARICA",
                "ITAPE",
                "ITAPEBI",
                "ITAPETINGA",
                "ITAPICURU",
                "ITAPITANGA",
                "ITAQUARA",
                "ITARANTIM",
                "ITATIM",
                "ITIRUCU",
                "ITIUBA",
                "ITORORO",
                "ITUACU",
                "ITUBERA",
                "IUIU",
                "JABORANDI",
                "JACARACI",
                "JACOBINA",
                "JAGUAQUARA",
                "JAGUARARI",
                "JAGUARIPE",
                "JANDAIRA",
                "JEQUIE",
                "JEREMOABO",
                "JIQUIRICA",
                "JITAUNA",
                "JOAO DOURADO",
                "JUAZEIRO",
                "JUCURUCU",
                "JUSSARA",
                "JUSSARI",
                "JUSSIAPE",
                "LAFAIETE COUTINHO",
                "LAGOA REAL",
                "LAJE",
                "LAJEDAO",
                "LAJEDINHO",
                "LAJEDO DO TABOCAL",
                "LAMARAO",
                "LAPAO",
                "LAURO DE FREITAS",
                "LENCOIS",
                "LICINIO DE ALMEIDA",
                "LIVRAMENTO DE NOSSA SENHORA",
                "LUIS EDUARDO MAGALHAES",
                "MACAJUBA",
                "MACARANI",
                "MACAUBAS",
                "MACURURE",
                "MADRE DE DEUS",
                "MAETINGA",
                "MAIQUINIQUE",
                "MAIRI",
                "MALHADA",
                "MALHADA DE PEDRAS",
                "MANOEL VITORINO",
                "MANSIDAO",
                "MARACAS",
                "MARAGOGIPE",
                "MARAU",
                "MARCIONILIO SOUZA",
                "MASCOTE",
                "MATA DE SAO JOAO",
                "MATINA",
                "MEDEIROS NETO",
                "MIGUEL CALMON",
                "MILAGRES",
                "MIRANGABA",
                "MIRANTE",
                "MONTE SANTO",
                "MORPARA",
                "MORRO DO CHAPEU",
                "MORTUGABA",
                "MUCUGE",
                "MUCURI",
                "MULUNGU DO MORRO",
                "MUNDO NOVO",
                "MUNIZ FERREIRA",
                "MUQUEM DE SAO FRANCISCO",
                "MURITIBA",
                "MUTUIPE",
                "NAZARE",
                "NILO PECANHA",
                "NORDESTINA",
                "NOVA CANAA",
                "NOVA FATIMA",
                "NOVA IBIA",
                "NOVA ITARANA",
                "NOVA REDENCAO",
                "NOVA SOURE",
                "NOVA VICOSA",
                "NOVO HORIZONTE",
                "NOVO TRIUNFO",
                "OLINDINA",
                "OLIVEIRA DOS BREJINHOS",
                "OURICANGAS",
                "OUROLANDIA",
                "PALMAS DE MONTE ALTO",
                "PALMEIRAS",
                "PARAMIRIM",
                "PARATINGA",
                "PARIPIRANGA",
                "PAU BRASIL",
                "PAULO AFONSO",
                "PE DE SERRA",
                "PEDRAO",
                "PEDRO ALEXANDRE",
                "PIATA",
                "PILAO ARCADO",
                "PINDAI",
                "PINDOBACU",
                "PINTADAS",
                "PIRAI DO NORTE",
                "PIRIPA",
                "PIRITIBA",
                "PLANALTINO",
                "PLANALTO",
                "POCOES",
                "POJUCA",
                "PONTO NOVO",
                "PORTO SEGURO",
                "POTIRAGUA",
                "PRADO",
                "PRESIDENTE DUTRA",
                "PRESIDENTE JANIO QUADROS",
                "PRESIDENTE TANCREDO NEVES",
                "QUEIMADAS",
                "QUIJINGUE",
                "QUIXABEIRA",
                "RAFAEL JAMBEIRO",
                "REMANSO",
                "RETIROLANDIA",
                "RIACHAO DAS NEVES",
                "RIACHAO DO JACUIPE",
                "RIACHO DE SANTANA",
                "RIBEIRA DO AMPARO",
                "RIBEIRA DO POMBAL",
                "RIBEIRAO DO LARGO",
                "RIO DE CONTAS",
                "RIO DO ANTONIO",
                "RIO DO PIRES",
                "RIO REAL",
                "RODELAS",
                "RUY BARBOSA",
                "SALINAS DA MARGARIDA",
                "SALVADOR",
                "SANTA BARBARA",
                "SANTA BRIGIDA",
                "SANTA CRUZ CABRALIA",
                "SANTA CRUZ DA VITORIA",
                "SANTA INES",
                "SANTA LUZIA",
                "SANTA MARIA DA VITORIA",
                "SANTA RITA DE CASSIA",
                "SANTA TERESINHA",
                "SANTALUZ",
                "SANTANA",
                "SANTANOPOLIS",
                "SANTO AMARO",
                "SANTO ANTONIO DE JESUS",
                "SANTO ESTEVAO",
                "SAO DESIDERIO",
                "SAO DOMINGOS",
                "SAO FELIPE",
                "SAO FELIX",
                "SAO FELIX DO CORIBE",
                "SAO FRANCISCO DO CONDE",
                "SAO GABRIEL",
                "SAO GONCALO DOS CAMPOS",
                "SAO JOSE DA VITORIA",
                "SAO JOSE DO JACUIPE",
                "SAO MIGUEL DAS MATAS",
                "SAO SEBASTIAO DO PASSE",
                "SAPEACU",
                "SATIRO DIAS",
                "SAUBARA",
                "SAUDE",
                "SEABRA",
                "SEBASTIAO LARANJEIRAS",
                "SENHOR DO BONFIM",
                "SENTO SE",
                "SERRA DO RAMALHO",
                "SERRA DOURADA",
                "SERRA PRETA",
                "SERRINHA",
                "SERROLANDIA",
                "SIMOES FILHO",
                "SITIO DO MATO",
                "SITIO DO QUINTO",
                "SOBRADINHO",
                "SOUTO SOARES",
                "TABOCAS DO BREJO VELHO",
                "TANHACU",
                "TANQUE NOVO",
                "TANQUINHO",
                "TAPEROA",
                "TAPIRAMUTA",
                "TEIXEIRA DE FREITAS",
                "TEODORO SAMPAIO",
                "TEOFILANDIA",
                "TEOLANDIA",
                "TERRA NOVA",
                "TREMEDAL",
                "TUCANO",
                "UAUA",
                "UBAIRA",
                "UBAITABA",
                "UBATA",
                "UIBAI",
                "UMBURANAS",
                "UNA",
                "URANDI",
                "URUCUCA",
                "UTINGA",
                "VALENCA",
                "VALENTE",
                "VARZEA DA ROCA",
                "VARZEA DO POCO",
                "VARZEA NOVA",
                "VARZEDO",
                "VERA CRUZ",
                "VEREDA",
                "VITORIA DA CONQUISTA",
                "WAGNER",
                "WANDERLEY",
                "WENCESLAU GUIMARAES",
                "XIQUE-XIQUE"
                //Ceará - CE
                    ,
                "ABAIARA",
                "ACARAPE",
                "ACARAU",
                "ACOPIARA",
                "AIUABA",
                "ALCANTARAS",
                "ALTANEIRA",
                "ALTO SANTO",
                "AMONTADA",
                "ANTONINA DO NORTE",
                "APUIARES",
                "AQUIRAZ",
                "ARACATI",
                "ARACOIABA",
                "ARARENDA",
                "ARARIPE",
                "ARATUBA",
                "ARNEIROZ",
                "ASSARE",
                "AURORA",
                "BAIXIO",
                "BANABUIU",
                "BARBALHA",
                "BARREIRA",
                "BARRO",
                "BARROQUINHA",
                "BATURITE",
                "BEBERIBE",
                "BELA CRUZ",
                "BOA VIAGEM",
                "BREJO SANTO",
                "CAMOCIM",
                "CAMPOS SALES",
                "CANINDE",
                "CAPISTRANO",
                "CARIDADE",
                "CARIRE",
                "CARIRIACU",
                "CARIUS",
                "CARNAUBAL",
                "CASCAVEL",
                "CATARINA",
                "CATUNDA",
                "CAUCAIA",
                "CEDRO",
                "CHAVAL",
                "CHORO",
                "CHOROZINHO",
                "COREAU",
                "CRATEUS",
                "CRATO",
                "CROATA",
                "CRUZ",
                "DEPUTADO IRAPUAN PINHEIRO",
                "ERERE",
                "EUSEBIO",
                "FARIAS BRITO",
                "FORQUILHA",
                "FORTALEZA",
                "FORTIM",
                "FRECHEIRINHA",
                "GENERAL SAMPAIO",
                "GRACA",
                "GRANJA",
                "GRANJEIRO",
                "GROAIRAS",
                "GUAIUBA",
                "GUARACIABA DO NORTE",
                "GUARAMIRANGA",
                "HIDROLANDIA",
                "HORIZONTE",
                "IBARETAMA",
                "IBIAPINA",
                "IBICUITINGA",
                "ICAPUI",
                "ICO",
                "IGUATU",
                "INDEPENDENCIA",
                "IPAPORANGA",
                "IPAUMIRIM",
                "IPU",
                "IPUEIRAS",
                "IRACEMA",
                "IRAUCUBA",
                "ITAICABA",
                "ITAITINGA",
                "ITAPAJE",
                "ITAPIPOCA",
                "ITAPIUNA",
                "ITAREMA",
                "ITATIRA",
                "JAGUARETAMA",
                "JAGUARIBARA",
                "JAGUARIBE",
                "JAGUARUANA",
                "JARDIM",
                "JATI",
                "JIJOCA DE JERICOAROARA",
                "JUAZEIRO DO NORTE",
                "JUCAS",
                "LAVRAS DA MANGABEIRA",
                "LIMOEIRO DO NORTE",
                "MADALENA",
                "MARACANAU",
                "MARANGUAPE",
                "MARCO",
                "MARTINOPOLE",
                "MASSAPE",
                "MAURITI",
                "MERUOCA",
                "MILAGRES",
                "MILHA",
                "MIRAIMA",
                "MISSAO VELHA",
                "MOMBACA",
                "MONSENHOR TABOSA",
                "MORADA NOVA",
                "MORAUJO",
                "MORRINHOS",
                "MUCAMBO",
                "MULUNGU",
                "NOVA OLINDA",
                "NOVA RUSSAS",
                "NOVO ORIENTE",
                "OCARA",
                "OROS",
                "PACAJUS",
                "PACATUBA",
                "PACOTI",
                "PACUJA",
                "PALHANO",
                "PALMACIA",
                "PARACURU",
                "PARAIPABA",
                "PARAMBU",
                "PARAMOTI",
                "PEDRA BRANCA",
                "PENAFORTE",
                "PENTECOSTE",
                "PEREIRO",
                "PINDORETAMA",
                "PIQUET CARNEIRO",
                "PIRES FERREIRA",
                "PORANGA",
                "PORTEIRAS",
                "POTENGI",
                "POTIRETAMA",
                "QUITERIANOPOLIS",
                "QUIXADA",
                "QUIXELO",
                "QUIXERAMOBIM",
                "QUIXERE",
                "REDENCAO",
                "RERIUTABA",
                "RUSSAS",
                "SABOEIRO",
                "SALITRE",
                "SANTA QUITERIA",
                "SANTANA DO ACARAU",
                "SANTANA DO CARIRI",
                "SAO BENEDITO",
                "SAO GONCALO DO AMARANTE",
                "SAO JOAO DO JAGUARIBE",
                "SAO LUIS DO CURU",
                "SENADOR POMPEU",
                "SENADOR SA",
                "SOBRAL",
                "SOLONOPOLE",
                "TABULEIRO DO NORTE",
                "TAMBORIL",
                "TARRAFAS",
                "TAUA",
                "TEJUCUOCA",
                "TIANGUA",
                "TRAIRI",
                "TURURU",
                "UBAJARA",
                "UMARI",
                "UMIRIM",
                "URUBURETAMA",
                "URUOCA",
                "VARJOTA",
                "VARZEA ALEGRE",
                "VICOSA DO CEARA"
                //Distrito Federal - DF
                    ,
                "AGUAS CLARAS",
                "ARNIQUEIRA",
                "BRASILIA",
                "BRAZLANDIA",
                "CANDANGOLANDIA",
                "CEILANDIA",
                "CRUZEIRO",
                "ESTRUTURAL",
                "FERCAL",
                "GAMA",
                "GUARA",
                "ITAPOA",
                "JARDIM BOTANICO",
                "LAGO NORTE",
                "LAGO SUL",
                "NUCLEO BANDEIRANTE",
                "OCTOGONAL",
                "PARANOA",
                "PARK WAY",
                "PLANALTINA",
                "PLANO PILOTO",
                "POR DO SOL",
                "RECANTO DAS EMAS",
                "RIACHO FUNDO II",
                "RIACHO FUNDO",
                "SAMAMBAIA",
                "SANTA MARIA",
                "SAO SEBASTIAO",
                "SIA",
                "SOBRADINHO II",
                "SOBRADINHO",
                "SOL NASCENTE",
                "SUDOESTE",
                "TAGUATINGA",
                "VARJAO",
                "VICENTE PIRES"
                //Espírito Santo - ES
                    ,
                "AFONSO CLAUDIO",
                "AGUA DOCE DO NORTE",
                "AGUIA BRANCA",
                "ALEGRE",
                "ALFREDO CHAVES",
                "ALTO RIO NOVO",
                "ANCHIETA",
                "APIACA",
                "ARACRUZ",
                "ATILIO VIVACQUA",
                "BAIXO GUANDU",
                "BARRA DE SAO FRANCISCO",
                "BOA ESPERANCA",
                "BOM JESUS DO NORTE",
                "BREJETUBA",
                "CACHOEIRO DE ITAPEMIRIM",
                "CARIACICA",
                "CASTELO",
                "COLATINA",
                "CONCEICAO DA BARRA",
                "CONCEICAO DO CASTELO",
                "DIVINO DE SAO LOURENCO",
                "DOMINGOS MARTINS",
                "DORES DO RIO PRETO",
                "ECOPORANGA",
                "FUNDAO",
                "GOVERNADOR LINDENBERG",
                "GUACUI",
                "GUARAPARI",
                "IBATIBA",
                "IBIRACU",
                "IBITIRAMA",
                "ICONHA",
                "IRUPI",
                "ITAGUACU",
                "ITAPEMIRIM",
                "ITARANA",
                "IUNA",
                "JAGUARE",
                "JERONIMO MONTEIRO",
                "JOAO NEIVA",
                "LARANJA DA TERRA",
                "LINHARES",
                "MANTENOPOLIS",
                "MARATAIZES",
                "MARECHAL FLORIANO",
                "MARILANDIA",
                "MIMOSO DO SUL",
                "MONTANHA",
                "MUCURICI",
                "MUNIZ FREIRE",
                "MUQUI",
                "NOVA VENECIA",
                "PANCAS",
                "PEDRO CANARIO",
                "PINHEIROS",
                "PIUMA",
                "PONTO BELO",
                "PRESIDENTE KENNEDY",
                "RIO BANANAL",
                "RIO NOVO DO SUL",
                "SANTA LEOPOLDINA",
                "SANTA MARIA DE JETIBA",
                "SANTA TERESA",
                "SAO DOMINGOS DO NORTE",
                "SAO GABRIEL DA PALHA",
                "SAO JOSE DO CALCADO",
                "SAO MATEUS",
                "SAO ROQUE DO CANAA",
                "SERRA",
                "SOORETAMA",
                "VARGEM ALTA",
                "VENDA NOVA DO IMIGRANTE",
                "VIANA",
                "VILA PAVAO",
                "VILA VALERIO",
                "VILA VELHA",
                "VITORIA"
                //Goiás - GO
                    ,
                "ABADIA DE GOIAS",
                "ABADIANIA",
                "ACREUNA",
                "ADELANDIA",
                "AGUA FRIA DE GOIAS",
                "AGUA LIMPA",
                "AGUAS LINDAS DE GOIAS",
                "ALEXANIA",
                "ALOANDIA",
                "ALTO HORIZONTE",
                "ALTO PARAISO DE GOIAS",
                "ALVORADA DO NORTE",
                "AMARALINA",
                "AMERICANO DO BRASIL",
                "AMORINOPOLIS",
                "ANAPOLIS",
                "ANHANGUERA",
                "ANICUNS",
                "APARECIDA DE GOIANIA",
                "APARECIDA DO RIO DOCE",
                "APORE",
                "ARACU",
                "ARAGARCAS",
                "ARAGOIANIA",
                "ARAGUAPAZ",
                "ARENOPOLIS",
                "ARUANA",
                "AURILANDIA",
                "AVELINOPOLIS",
                "BALIZA",
                "BARRO ALTO",
                "BELA VISTA DE GOIAS",
                "BOM JARDIM DE GOIAS",
                "BOM JESUS DE GOIAS",
                "BONFINOPOLIS",
                "BONOPOLIS",
                "BRAZABRANTES",
                "BRITANIA",
                "BURITI ALEGRE",
                "BURITI DE GOIAS",
                "BURITINOPOLIS",
                "CABECEIRAS",
                "CACHOEIRA ALTA",
                "CACHOEIRA DE GOIAS",
                "CACHOEIRA DOURADA",
                "CACU",
                "CAIAPONIA",
                "CALDAS NOVAS",
                "CALDAZINHA",
                "CAMPESTRE DE GOIAS",
                "CAMPINACU",
                "CAMPINORTE",
                "CAMPO ALEGRE DE GOIAS",
                "CAMPOS LIMPO DE GOIAS",
                "CAMPOS BELOS",
                "CAMPOS VERDES",
                "CARMO DO RIO VERDE",
                "CASTELANDIA",
                "CATALAO",
                "CATURAI",
                "CAVALCANTE",
                "CERES",
                "CEZARINA",
                "CHAPADAO DO CEU",
                "CIDADE OCIDENTAL",
                "COCALZINHO DE GOIAS",
                "COLINAS DO SUL",
                "CORREGO DO OURO",
                "CORUMBA DE GOIAS",
                "CORUMBAIBA",
                "CRISTALINA",
                "CRISTIANOPOLIS",
                "CRIXAS",
                "CROMINIA",
                "CUMARI",
                "DAMIANOPOLIS",
                "DAMOLANDIA",
                "DAVINOPOLIS",
                "DIORAMA",
                "DIVINOPOLIS DE GOIAS",
                "DOVERLANDIA",
                "EDEALINA",
                "EDEIA",
                "ESTRELA DO NORTE",
                "FAINA",
                "FAZENDA NOVA",
                "FIRMINOPOLIS",
                "FLORES DE GOIAS",
                "FORMOSA",
                "FORMOSO",
                "GAMELEIRA DE GOIAS",
                "GOIANAPOLIS",
                "GOIANDIRA",
                "GOIANESIA",
                "GOIANIA",
                "GOIANIRA",
                "GOIAS",
                "GOIATUBA",
                "GOUVELANDIA",
                "GUAPO",
                "GUARAITA",
                "GUARANI DE GOIAS",
                "GUARINOS",
                "HEITORAI",
                "HIDROLANDIA",
                "HIDROLINA",
                "IACIARA",
                "INACIOLANDIA",
                "INDIARA",
                "INHUMAS",
                "IPAMERI",
                "IPIRANGA DE GOIAS",
                "IPORA",
                "ISRAELANDIA",
                "ITABERAI",
                "ITAGUARI",
                "ITAGUARU",
                "ITAJA",
                "ITAPACI",
                "ITAPIRAPUA",
                "ITAPURANGA",
                "ITARUMA",
                "ITAUCU",
                "ITUMBIARA",
                "IVOLANDIA",
                "JANDAIA",
                "JARAGUA",
                "JATAI",
                "JAUPACI",
                "JESUPOLIS",
                "JOVIANIA",
                "JUSSARA",
                "LAGOA SANTA",
                "LEOPOLDO DE BULHOES",
                "LUZIANIA",
                "MAIRIPOTABA",
                "MAMBAI",
                "MARA ROSA",
                "MARZAGAO",
                "MATRINCHA",
                "MAURILANDIA",
                "MIMOSO DE GOIAS",
                "MINACU",
                "MINEIROS",
                "MOIPORA",
                "MONTE ALEGRE DE GOIAS",
                "MONTES CLAROS DE GOIAS",
                "MONTIVIDIU",
                "MONTIVIDIU DO NORTE",
                "MORRINHOS",
                "MORRO AGUDO DE GOIAS",
                "MOSSAMEDES",
                "MOZARLANDIA",
                "MUNDO NOVO",
                "MUTUNOPOLIS",
                "NAZARIO",
                "NEROPOLIS",
                "NIQUELANDIA",
                "NOVA AMERICA",
                "NOVA AURORA",
                "NOVA CRIXAS",
                "NOVA GLORIA",
                "NOVA IGUACU DE GOIAS",
                "NOVA ROMA",
                "NOVA VENEZA",
                "NOVO BRASIL",
                "NOVO GAMA",
                "NOVO PLANALTO",
                "ORIZONA",
                "OURO VERDE DE GOIAS",
                "OUVIDOR",
                "PADRE BERNARDO",
                "PALESTINA DE GOIAS",
                "PALMEIRAS DE GOIAS",
                "PALMELO",
                "PALMINOPOLIS",
                "PANAMA",
                "PARANAIGUARA",
                "PARAUNA",
                "PEROLANDIA",
                "PETROLINA DE GOIAS",
                "PILAR DE GOIAS",
                "PIRACANJUBA",
                "PIRANHAS",
                "PIRENOPOLIS",
                "PIRES DO RIO",
                "PLANALTINA",
                "PONTALINA",
                "PORANGATU",
                "PORTEIRAO",
                "PORTELANDIA",
                "POSSE",
                "PROFESSOR JAMIL",
                "QUIRINOPOLIS",
                "RIALMA",
                "RIANAPOLIS",
                "RIO QUENTE",
                "RIO VERDE",
                "RUBIATABA",
                "SANCLERLANDIA",
                "SANTA BARBARA DE GOIAS",
                "SANTA CRUZ DE GOIAS",
                "SANTA FE DE GOIAS",
                "SANTA HELENA DE GOIAS",
                "SANTA ISABEL",
                "SANTA RITA DO ARAGUAIA",
                "SANTA RITA DO NOVO DESTINO",
                "SANTA ROSA DE GOIAS",
                "SANTA TEREZA DE GOIAS",
                "SANTA TEREZINHA DE GOIAS",
                "SANTO ANTONIO DA BARRA",
                "SANTO ANTONIO DE GOIAS",
                "SANTO ANTONIO DO DESCOBERTO",
                "SAO DOMINGOS",
                "SAO FRANCISCO DE GOIAS",
                "SAO JOAO D'ALIANCA",
                "SAO JOAO DA PARAUNA",
                "SAO LUIS DE MONTES BELOS",
                "SAO LUIZ DO NORTE",
                "SAO MIGUEL DO ARAGUAIA",
                "SAO MIGUEL DO PASSA QUATRO",
                "SAO PATRICIO",
                "SAO SIMAO",
                "SENADOR CANEDO",
                "SERRANOPOLIS",
                "SILVANIA",
                "SIMOLANDIA",
                "SITIO D'ABADIA",
                "TAQUARAL DE GOIAS",
                "TERESINA DE GOIAS",
                "TEREZOPOLIS DE GOIAS",
                "TRES RANCHOS",
                "TRINDADE",
                "TROMBAS",
                "TURVANIA",
                "TURVELANDIA",
                "UIRAPURU",
                "URUACU",
                "URUANA",
                "URUTAI",
                "VALPARAISO DE GOIAS",
                "VARJAO",
                "VIANOPOLIS",
                "VICENTINOPOLIS",
                "VILA BOA",
                "VILA PROPICIO"
                //Maranhão - MA
                    ,
                "ACAILANDIA",
                "AFONSO CUNHA",
                "AGUA DOCE DO MARANHAO",
                "ALCANTARA",
                "ALDEIAS ALTAS",
                "ALTAMIRA DO MARANHAO",
                "ALTO ALEGRE DO MARANHAO",
                "ALTO ALEGRE DO PINDARE",
                "ALTO PARNAIBA",
                "AMAPA DO MARANHAO",
                "AMARANTE DO MARANHAO",
                "ANAJATUBA",
                "ANAPURUS",
                "APICUM-ACU",
                "ARAGUANA",
                "ARAIOSES",
                "ARAME",
                "ARARI",
                "AXIXA",
                "BACABAL",
                "BACABEIRA",
                "BACURI",
                "BACURITUBA",
                "BALSAS",
                "BARAO DE GRAJAU",
                "BARRA DO CORDA",
                "BARREIRINHAS",
                "BELA VISTA DO MARANHAO",
                "BELAGUA",
                "BENEDITO LEITE",
                "BEQUIMAO",
                "BERNARDO DO MEARIM",
                "BOA VISTA DO GURUPI",
                "BOM JARDIM",
                "BOM JESUS DAS SELVAS",
                "BOM LUGAR",
                "BREJO",
                "BREJO DE AREIA",
                "BURITI",
                "BURITI BRAVO",
                "BURITICUPU",
                "BURITIRANA",
                "CACHOEIRA GRANDE",
                "CAJAPIO",
                "CAJARI",
                "CAMPESTRE DO MARANHAO",
                "CANDIDO MENDES",
                "CANTANHEDE",
                "CAPINZAL DO NORTE",
                "CAROLINA",
                "CARUTAPERA",
                "CAXIAS",
                "CEDRAL",
                "CENTRAL DO MARANHAO",
                "CENTRO DO GUILHERME",
                "CENTRO NOVO DO MARANHAO",
                "CHAPADINHA",
                "CIDELANDIA",
                "CODO",
                "COELHO NETO",
                "COLINAS",
                "CONCEICAO DO LAGO-ACU",
                "COROATA",
                "CURURUPU",
                "DAVINOPOLIS",
                "DOM PEDRO",
                "DUQUE BACELAR",
                "ESPERANTINOPOLIS",
                "ESTREITO",
                "FEIRA NOVA DO MARANHAO",
                "FERNANDO FALCAO",
                "FORMOSA DA SERRA NEGRA",
                "FORTALEZA DOS NOGUEIRAS",
                "FORTUNA",
                "GODOFREDO VIANA",
                "GONCALVES DIAS",
                "GOVERNADOR ARCHER",
                "GOVERNADOR EDISON LOBAO",
                "GOVERNADOR EUGENIO BARROS",
                "GOVERNADOR LUIZ ROCHA",
                "GOVERNADOR NEWTON BELLO",
                "GOVERNADOR NUNES FREIRE",
                "GRACA ARANHA",
                "GRAJAU",
                "GUIMARAES",
                "HUMBERTO DE CAMPOS",
                "ICATU",
                "IGARAPE DO MEIO",
                "IGARAPE GRANDE",
                "IMPERATRIZ",
                "ITAIPAVA DO GRAJAU",
                "ITAPECURU MIRIM",
                "ITINGA DO MARANHAO",
                "JATOBA",
                "JENIPAPO DOS VIEIRAS",
                "JOAO LISBOA",
                "JOSELANDIA",
                "JUNCO DO MARANHAO",
                "LAGO DA PEDRA",
                "LAGO DO JUNCO",
                "LAGO DOS RODRIGUES",
                "LAGO VERDE",
                "LAGOA DO MATO",
                "LAGOA GRANDE DO MARANHAO",
                "LAJEADO NOVO",
                "LIMA CAMPOS",
                "LORETO",
                "LUIS DOMINGUES",
                "MAGALHAES DE ALMEIDA",
                "MARACACUME",
                "MARAJA DO SENA",
                "MARANHAOZINHO",
                "MATA ROMA",
                "MATINHA",
                "MATOES",
                "MATOES DO NORTE",
                "MILAGRES DO MARANHAO",
                "MIRADOR",
                "MIRANDA DO NORTE",
                "MIRINZAL",
                "MONCAO",
                "MONTES ALTOS",
                "MORROS",
                "NINA RODRIGUES",
                "NOVA COLINAS",
                "NOVA IORQUE",
                "NOVA OLINDA DO MARANHAO",
                "OLHO D'AGUA DAS CUNHAS",
                "OLINDA NOVA DO MARANHAO",
                "PACO DO LUMIAR",
                "PALMEIRANDIA",
                "PARAIBANO",
                "PARNARAMA",
                "PASSAGEM FRANCA",
                "PASTOS BONS",
                "PAULINO NEVES",
                "PAULO RAMOS",
                "PEDREIRAS",
                "PEDRO DO ROSARIO",
                "PENALVA",
                "PERI MIRIM",
                "PERITORO",
                "PINDARE MIRIM",
                "PINHEIRO",
                "PIO XII",
                "PIRAPEMAS",
                "POCAO DE PEDRAS",
                "PORTO FRANCO",
                "PORTO RICO DO MARANHAO",
                "PRESIDENTE DUTRA",
                "PRESIDENTE JUSCELINO",
                "PRESIDENTE MEDICI",
                "PRESIDENTE SARNEY",
                "PRESIDENTE VARGAS",
                "PRIMEIRA CRUZ",
                "RAPOSA",
                "RIACHAO",
                "RIBAMAR FIQUENE",
                "ROSARIO",
                "SAMBAIBA",
                "SANTA FILOMENA DO MARANHAO",
                "SANTA HELENA",
                "SANTA INES",
                "SANTA LUZIA",
                "SANTA LUZIA DO PARUA",
                "SANTA QUITERIA DO MARANHAO",
                "SANTA RITA",
                "SANTANA DO MARANHAO",
                "SANTO AMARO DO MARANHAO",
                "SANTO ANTONIO DOS LOPES",
                "SAO BENEDITO DO RIO PRETO",
                "SAO BENTO",
                "SAO BERNARDO",
                "SAO DOMINGOS DO AZEITAO",
                "SAO DOMINGOS DO MARANHAO",
                "SAO FELIX DE BALSAS",
                "SAO FRANCISCO DO BREJAO",
                "SAO FRANCISCO DO MARANHAO",
                "SAO JOAO BATISTA",
                "SAO JOAO DO CARU",
                "SAO JOAO DO PARAISO",
                "SAO JOAO DO SOTER",
                "SAO JOAO DOS PATOS",
                "SAO JOSE DE RIBAMAR",
                "SAO JOSE DOS BASILIOS",
                "SAO LUIS",
                "SAO LUIS GONZAGA DO MARANHAO",
                "SAO MATEUS DO MARANHAO",
                "SAO PEDRO DA AGUA BRANCA",
                "SAO PEDRO DOS CRENTES",
                "SAO RAIMUNDO DAS MANGABEIRAS",
                "SAO RAIMUNDO DO DOCA BEZERRA",
                "SAO ROBERTO",
                "SAO VICENTE FERRER",
                "SATUBINHA",
                "SENADOR ALEXANDRE COSTA",
                "SENADOR LA ROCQUE",
                "SERRANO DO MARANHAO",
                "SITIO NOVO",
                "SUCUPIRA DO NORTE",
                "SUCUPIRA DO RIACHAO",
                "TASSO FRAGOSO",
                "TIMBIRAS",
                "TIMON",
                "TRIZIDELA DO VALE",
                "TUFILANDIA",
                "TUNTUM",
                "TURIACU",
                "TURILANDIA",
                "TUTOIA",
                "URBANO SANTOS",
                "VARGEM GRANDE",
                "VIANA",
                "VILA NOVA DOS MARTIRIOS",
                "VITORIA DO MEARIM",
                "VITORINO FREIRE",
                "ZE DOCA"
                //Minas Gerais - MG
                    ,
                "ABADIA DOS DOURADOS",
                "ABAETE",
                "ABRE CAMPO",
                "ACAIACA",
                "ACUCENA",
                "AGUA BOA",
                "AGUA COMPRIDA",
                "AGUANIL",
                "AGUAS FORMOSAS",
                "AGUAS VERMELHAS",
                "AIMORES",
                "AIURUOCA",
                "ALAGOA",
                "ALBERTINA",
                "ALEM PARAIBA",
                "ALFENAS",
                "ALFREDO VASCONCELOS",
                "ALMENARA",
                "ALPERCATA",
                "ALPINOPOLIS",
                "ALTEROSA",
                "ALTO CAPARAO",
                "ALTO JEQUITIBA",
                "ALTO RIO DOCE",
                "ALVARENGA",
                "ALVINOPOLIS",
                "ALVORADA DE MINAS",
                "AMPARO DO SERRA",
                "ANDRADAS",
                "ANDRELANDIA",
                "ANGELANDIA",
                "ANTONIO CARLOS",
                "ANTONIO DIAS",
                "ANTONIO PRADO DE MINAS",
                "ARACAI",
                "ARACITABA",
                "ARACUAI",
                "ARAGUARI",
                "ARANTINA",
                "ARAPONGA",
                "ARAPORA",
                "ARAPUA",
                "ARAUJOS",
                "ARAXA",
                "ARCEBURGO",
                "ARCOS",
                "AREADO",
                "ARGIRITA",
                "ARICANDUVA",
                "ARINOS",
                "ASTOLFO DUTRA",
                "ATALEIA",
                "AUGUSTO DE LIMA",
                "BAEPENDI",
                "BALDIM",
                "BAMBUI",
                "BANDEIRA",
                "BANDEIRA DO SUL",
                "BARAO DE COCAIS",
                "BARAO DE MONTE ALTO",
                "BARBACENA",
                "BARRA LONGA",
                "BARROSO",
                "BELA VISTA DE MINAS",
                "BELMIRO BRAGA",
                "BELO HORIZONTE",
                "BELO ORIENTE",
                "BELO VALE",
                "BERILO",
                "BERIZAL",
                "BERTOPOLIS",
                "BETIM",
                "BIAS FORTES",
                "BICAS",
                "BIQUINHAS",
                "BOA ESPERANCA",
                "BOCAINA DE MINAS",
                "BOCAIUVA",
                "BOM DESPACHO",
                "BOM JARDIM DE MINAS",
                "BOM JESUS DA PENHA",
                "BOM JESUS DO AMPARO",
                "BOM JESUS DO GALHO",
                "BOM REPOUSO",
                "BOM SUCESSO",
                "BONFIM",
                "BONFINOPOLIS DE MINAS",
                "BONITO DE MINAS",
                "BORDA DA MATA",
                "BOTELHOS",
                "BOTUMIRIM",
                "BRAS PIRES",
                "BRASILANDIA DE MINAS",
                "BRASILIA DE MINAS",
                "BRASOPOLIS",
                "BRAUNAS",
                "BRUMADINHO",
                "BUENO BRANDAO",
                "BUENOPOLIS",
                "BUGRE",
                "BURITIS",
                "BURITIZEIRO",
                "CABECEIRA GRANDE",
                "CABO VERDE",
                "CACHOEIRA DA PRATA",
                "CACHOEIRA DE MINAS",
                "CACHOEIRA DE PAJEU",
                "CACHOEIRA DOURADA",
                "CAETANOPOLIS",
                "CAETE",
                "CAIANA",
                "CAJURI",
                "CALDAS",
                "CAMACHO",
                "CAMANDUCAIA",
                "CAMBUI",
                "CAMBUQUIRA",
                "CAMPANARIO",
                "CAMPANHA",
                "CAMPESTRE",
                "CAMPINA VERDE",
                "CAMPO AZUL",
                "CAMPO BELO",
                "CAMPO DO MEIO",
                "CAMPO FLORIDO",
                "CAMPOS ALTOS",
                "CAMPOS GERAIS",
                "CANA VERDE",
                "CANAA",
                "CANAPOLIS",
                "CANDEIAS",
                "CANTAGALO",
                "CAPARAO",
                "CAPELA NOVA",
                "CAPELINHA",
                "CAPETINGA",
                "CAPIM BRANCO",
                "CAPINOPOLIS",
                "CAPITAO ANDRADE",
                "CAPITAO ENEAS",
                "CAPITOLIO",
                "CAPUTIRA",
                "CARAI",
                "CARANAIBA",
                "CARANDAI",
                "CARANGOLA",
                "CARATINGA",
                "CARBONITA",
                "CAREACU",
                "CARLOS CHAGAS",
                "CARMESIA",
                "CARMO DA CACHOEIRA",
                "CARMO DA MATA",
                "CARMO DE MINAS",
                "CARMO DO CAJURU",
                "CARMO DO PARANAIBA",
                "CARMO DO RIO CLARO",
                "CARMOPOLIS DE MINAS",
                "CARNEIRINHO",
                "CARRANCAS",
                "CARVALHOPOLIS",
                "CARVALHOS",
                "CASA GRANDE",
                "CASCALHO RICO",
                "CASSIA",
                "CATAGUASES",
                "CATAS ALTAS",
                "CATAS ALTAS DA NORUEGA",
                "CATUJI",
                "CATUTI",
                "CAXAMBU",
                "CEDRO DO ABAETE",
                "CENTRAL DE MINAS",
                "CENTRALINA",
                "CHACARA",
                "CHALE",
                "CHAPADA DO NORTE",
                "CHAPADA GAUCHA",
                "CHIADOR",
                "CIPOTANEA",
                "CLARAVAL",
                "CLARO DOS POCOES",
                "CLAUDIO",
                "COIMBRA",
                "COLUNA",
                "COMENDADOR GOMES",
                "COMERCINHO",
                "CONCEICAO DA APARECIDA",
                "CONCEICAO DA BARRA DE MINAS",
                "CONCEICAO DAS ALAGOAS",
                "CONCEICAO DAS PEDRAS",
                "CONCEICAO DE IPANEMA",
                "CONCEICAO DO MATO DENTRO",
                "CONCEICAO DO PARA",
                "CONCEICAO DO RIO VERDE",
                "CONCEICAO DOS OUROS",
                "CONEGO MARINHO",
                "CONFINS",
                "CONGONHAL",
                "CONGONHAS",
                "CONGONHAS DO NORTE",
                "CONQUISTA",
                "CONSELHEIRO LAFAIETE",
                "CONSELHEIRO PENA",
                "CONSOLACAO",
                "CONTAGEM",
                "COQUEIRAL",
                "CORACAO DE JESUS",
                "CORDISBURGO",
                "CORDISLANDIA",
                "CORINTO",
                "COROACI",
                "COROMANDEL",
                "CORONEL FABRICIANO",
                "CORONEL MURTA",
                "CORONEL PACHECO",
                "CORONEL XAVIER CHAVES",
                "CORREGO DANTA",
                "CORREGO DO BOM JESUS",
                "CORREGO FUNDO",
                "CORREGO NOVO",
                "COUTO DE MAGALHAES DE MINAS",
                "CRISOLITA",
                "CRISTAIS",
                "CRISTALIA",
                "CRISTIANO OTONI",
                "CRISTINA",
                "CRUCILANDIA",
                "CRUZEIRO DA FORTALEZA",
                "CRUZILIA",
                "CUPARAQUE",
                "CURRAL DE DENTRO",
                "CURVELO",
                "DATAS",
                "DELFIM MOREIRA",
                "DELFINOPOLIS",
                "DELTA",
                "DESCOBERTO",
                "DESTERRO DE ENTRE RIOS",
                "DESTERRO DO MELO",
                "DIAMANTINA",
                "DIOGO DE VASCONCELOS",
                "DIONISIO",
                "DIVINESIA",
                "DIVINO",
                "DIVINO DAS LARANJEIRAS",
                "DIVINOLANDIA DE MINAS",
                "DIVINOPOLIS",
                "DIVISA ALEGRE",
                "DIVISA NOVA",
                "DIVISOPOLIS",
                "DOM BOSCO",
                "DOM CAVATI",
                "DOM JOAQUIM",
                "DOM SILVERIO",
                "DOM VICOSO",
                "DONA EUZEBIA",
                "DORES DE CAMPOS",
                "DORES DE GUANHAES",
                "DORES DO INDAIA",
                "DORES DO TURVO",
                "DORESOPOLIS",
                "DOURADOQUARA",
                "DURANDE",
                "ELOI MENDES",
                "ENGENHEIRO CALDAS",
                "ENGENHEIRO NAVARRO",
                "ENTRE FOLHAS",
                "ENTRE RIOS DE MINAS",
                "ERVALIA",
                "ESMERALDAS",
                "ESPERA FELIZ",
                "ESPINOSA",
                "ESPIRITO SANTO DO DOURADO",
                "ESTIVA",
                "ESTRELA DALVA",
                "ESTRELA DO INDAIA",
                "ESTRELA DO SUL",
                "EUGENOPOLIS",
                "EWBANK DA CAMARA",
                "EXTREMA",
                "FAMA",
                "FARIA LEMOS",
                "FELICIO DOS SANTOS",
                "FELISBURGO",
                "FELIXLANDIA",
                "FERNANDES TOURINHO",
                "FERROS",
                "FERVEDOURO",
                "FLORESTAL",
                "FORMIGA",
                "FORMOSO",
                "FORTALEZA DE MINAS",
                "FORTUNA DE MINAS",
                "FRANCISCO BADARO",
                "FRANCISCO DUMONT",
                "FRANCISCO SA",
                "FRANCISCOPOLIS",
                "FREI GASPAR",
                "FREI INOCENCIO",
                "FREI LAGONEGRO",
                "FRONTEIRA",
                "FRONTEIRA DOS VALES",
                "FRUTA DE LEITE",
                "FRUTAL",
                "FUNILANDIA",
                "GALILEIA",
                "GAMELEIRAS",
                "GLAUCILANDIA",
                "GOIABEIRA",
                "GOIANA",
                "GONCALVES",
                "GONZAGA",
                "GOUVEIA",
                "GOVERNADOR VALADARES",
                "GRAO MOGOL",
                "GRUPIARA",
                "GUANHAES",
                "GUAPE",
                "GUARACIABA",
                "GUARACIAMA",
                "GUARANESIA",
                "GUARANI",
                "GUARARA",
                "GUARDA-MOR",
                "GUAXUPE",
                "GUIDOVAL",
                "GUIMARANIA",
                "GUIRICEMA",
                "GURINHATA",
                "HELIODORA",
                "IAPU",
                "IBERTIOGA",
                "IBIA",
                "IBIAI",
                "IBIRACATU",
                "IBIRACI",
                "IBIRITE",
                "IBITIURA DE MINAS",
                "IBITURUNA",
                "ICARAI DE MINAS",
                "IGARAPE",
                "IGARATINGA",
                "IGUATAMA",
                "IJACI",
                "ILICINEA",
                "IMBE DE MINAS",
                "INCONFIDENTES",
                "INDAIABIRA",
                "INDIANOPOLIS",
                "INGAI",
                "INHAPIM",
                "INHAUMA",
                "INIMUTABA",
                "IPABA",
                "IPANEMA",
                "IPATINGA",
                "IPIACU",
                "IPUIUNA",
                "IRAI DE MINAS",
                "ITABIRA",
                "ITABIRINHA DE MANTENA",
                "ITABIRITO",
                "ITACAMBIRA",
                "ITACARAMBI",
                "ITAGUARA",
                "ITAIPE",
                "ITAJUBA",
                "ITAMARANDIBA",
                "ITAMARATI DE MINAS",
                "ITAMBACURI",
                "ITAMBE DO MATO DENTRO",
                "ITAMOGI",
                "ITAMONTE",
                "ITANHANDU",
                "ITANHOMI",
                "ITAOBIM",
                "ITAPAGIPE",
                "ITAPECERICA",
                "ITAPEVA",
                "ITATIAIUCU",
                "ITAU DE MINAS",
                "ITAUNA",
                "ITAVERAVA",
                "ITINGA",
                "ITUETA",
                "ITUIUTABA",
                "ITUMIRIM",
                "ITURAMA",
                "ITUTINGA",
                "JABOTICATUBAS",
                "JACINTO",
                "JACUI",
                "JACUTINGA",
                "JAGUARACU",
                "JAIBA",
                "JAMPRUCA",
                "JANAUBA",
                "JANUARIA",
                "JAPARAIBA",
                "JAPONVAR",
                "JECEABA",
                "JENIPAPO DE MINAS",
                "JEQUERI",
                "JEQUITAI",
                "JEQUITIBA",
                "JEQUITINHONHA",
                "JESUANIA",
                "JOAIMA",
                "JOANESIA",
                "JOAO MONLEVADE",
                "JOAO PINHEIRO",
                "JOAQUIM FELICIO",
                "JORDANIA",
                "JOSE GONCALVES DE MINAS",
                "JOSE RAYDAN",
                "JOSENOPOLIS",
                "JUATUBA",
                "JUIZ DE FORA",
                "JURAMENTO",
                "JURUAIA",
                "JUVENILIA",
                "LADAINHA",
                "LAGAMAR",
                "LAGOA DA PRATA",
                "LAGOA DOS PATOS",
                "LAGOA DOURADA",
                "LAGOA FORMOSA",
                "LAGOA GRANDE",
                "LAGOA SANTA",
                "LAJINHA",
                "LAMBARI",
                "LAMIM",
                "LARANJAL",
                "LASSANCE",
                "LAVRAS",
                "LEANDRO FERREIRA",
                "LEME DO PRADO",
                "LEOPOLDINA",
                "LIBERDADE",
                "LIMA DUARTE",
                "LIMEIRA DO OESTE",
                "LONTRA",
                "LUISBURGO",
                "LUISLANDIA",
                "LUMINARIAS",
                "LUZ",
                "MACHACALIS",
                "MACHADO",
                "MADRE DE DEUS DE MINAS",
                "MALACACHETA",
                "MAMONAS",
                "MANGA",
                "MANHUACU",
                "MANHUMIRIM",
                "MANTENA",
                "MAR DE ESPANHA",
                "MARAVILHAS",
                "MARIA DA FE",
                "MARIANA",
                "MARILAC",
                "MARIO CAMPOS",
                "MARIPA DE MINAS",
                "MARLIERIA",
                "MARMELOPOLIS",
                "MARTINHO CAMPOS",
                "MARTINS SOARES",
                "MATA VERDE",
                "MATERLANDIA",
                "MATEUS LEME",
                "MATHIAS LOBATO",
                "MATIAS BARBOSA",
                "MATIAS CARDOSO",
                "MATIPO",
                "MATO VERDE",
                "MATOZINHOS",
                "MATUTINA",
                "MEDEIROS",
                "MEDINA",
                "MENDES PIMENTEL",
                "MERCES",
                "MESQUITA",
                "MINAS NOVAS",
                "MINDURI",
                "MIRABELA",
                "MIRADOURO",
                "MIRAI",
                "MIRAVANIA",
                "MOEDA",
                "MOEMA",
                "MONJOLOS",
                "MONSENHOR PAULO",
                "MONTALVANIA",
                "MONTE ALEGRE DE MINAS",
                "MONTE AZUL",
                "MONTE BELO",
                "MONTE CARMELO",
                "MONTE FORMOSO",
                "MONTE SANTO DE MINAS",
                "MONTE SIAO",
                "MONTES CLAROS",
                "MONTEZUMA",
                "MORADA NOVA DE MINAS",
                "MORRO DA GARCA",
                "MORRO DO PILAR",
                "MUNHOZ",
                "MURIAE",
                "MUTUM",
                "MUZAMBINHO",
                "NACIP RAYDAN",
                "NANUQUE",
                "NAQUE",
                "NATALANDIA",
                "NATERCIA",
                "NAZARENO",
                "NEPOMUCENO",
                "NINHEIRA",
                "NOVA BELEM",
                "NOVA ERA",
                "NOVA LIMA",
                "NOVA MODICA",
                "NOVA PONTE",
                "NOVA PORTEIRINHA",
                "NOVA RESENDE",
                "NOVA SERRANA",
                "NOVA UNIAO",
                "NOVO CRUZEIRO",
                "NOVO ORIENTE DE MINAS",
                "NOVORIZONTE",
                "OLARIA",
                "OLHOS-D'AGUA",
                "OLIMPIO NORONHA",
                "OLIVEIRA",
                "OLIVEIRA FORTES",
                "ONCA DE PITANGUI",
                "ORATORIOS",
                "ORIZANIA",
                "OURO BRANCO",
                "OURO FINO",
                "OURO PRETO",
                "OURO VERDE DE MINAS",
                "PADRE CARVALHO",
                "PADRE PARAISO",
                "PAI PEDRO",
                "PAINEIRAS",
                "PAINS",
                "PAIVA",
                "PALMA",
                "PALMOPOLIS",
                "PAPAGAIOS",
                "PARA DE MINAS",
                "PARACATU",
                "PARAGUACU",
                "PARAISOPOLIS",
                "PARAOPEBA",
                "PASSA QUATRO",
                "PASSA TEMPO",
                "PASSA-VINTE",
                "PASSABEM",
                "PASSOS",
                "PATIS",
                "PATOS DE MINAS",
                "PATROCINIO",
                "PATROCINIO DO MURIAE",
                "PAULA CANDIDO",
                "PAULISTAS",
                "PAVAO",
                "PECANHA",
                "PEDRA AZUL",
                "PEDRA BONITA",
                "PEDRA DO ANTA",
                "PEDRA DO INDAIA",
                "PEDRA DOURADA",
                "PEDRALVA",
                "PEDRAS DE MARIA DA CRUZ",
                "PEDRINOPOLIS",
                "PEDRO LEOPOLDO",
                "PEDRO TEIXEIRA",
                "PEQUERI",
                "PEQUI",
                "PERDIGAO",
                "PERDIZES",
                "PERDOES",
                "PERIQUITO",
                "PESCADOR",
                "PIAU",
                "PIEDADE DE CARATINGA",
                "PIEDADE DE PONTE NOVA",
                "PIEDADE DO RIO GRANDE",
                "PIEDADE DOS GERAIS",
                "PIMENTA",
                "PINGO-D'AGUA",
                "PINTOPOLIS",
                "PIRACEMA",
                "PIRAJUBA",
                "PIRANGA",
                "PIRANGUCU",
                "PIRANGUINHO",
                "PIRAPETINGA",
                "PIRAPORA",
                "PIRAUBA",
                "PITANGUI",
                "PIUMHI",
                "PLANURA",
                "POCO FUNDO",
                "POCOS DE CALDAS",
                "POCRANE",
                "POMPEU",
                "PONTE NOVA",
                "PONTO CHIQUE",
                "PONTO DOS VOLANTES",
                "PORTEIRINHA",
                "PORTO FIRME",
                "POTE",
                "POUSO ALEGRE",
                "POUSO ALTO",
                "PRADOS",
                "PRATA",
                "PRATAPOLIS",
                "PRATINHA",
                "PRESIDENTE BERNARDES",
                "PRESIDENTE JUSCELINO",
                "PRESIDENTE KUBITSCHEK",
                "PRESIDENTE OLEGARIO",
                "PRUDENTE DE MORAIS",
                "QUARTEL GERAL",
                "QUELUZITO",
                "RAPOSOS",
                "RAUL SOARES",
                "RECREIO",
                "REDUTO",
                "RESENDE COSTA",
                "RESPLENDOR",
                "RESSAQUINHA",
                "RIACHINHO",
                "RIACHO DOS MACHADOS",
                "RIBEIRAO DAS NEVES",
                "RIBEIRAO VERMELHO",
                "RIO ACIMA",
                "RIO CASCA",
                "RIO DO PRADO",
                "RIO DOCE",
                "RIO ESPERA",
                "RIO MANSO",
                "RIO NOVO",
                "RIO PARANAIBA",
                "RIO PARDO DE MINAS",
                "RIO PIRACICABA",
                "RIO POMBA",
                "RIO PRETO",
                "RIO VERMELHO",
                "RITAPOLIS",
                "ROCHEDO DE MINAS",
                "RODEIRO",
                "ROMARIA",
                "ROSARIO DA LIMEIRA",
                "RUBELITA",
                "RUBIM",
                "SABARA",
                "SABINOPOLIS",
                "SACRAMENTO",
                "SALINAS",
                "SALTO DA DIVISA",
                "SANTA BARBARA",
                "SANTA BARBARA DO LESTE",
                "SANTA BARBARA DO MONTE VERDE",
                "SANTA BARBARA DO TUGURIO",
                "SANTA CRUZ DE MINAS",
                "SANTA CRUZ DE SALINAS",
                "SANTA CRUZ DO ESCALVADO",
                "SANTA EFIGENIA DE MINAS",
                "SANTA FE DE MINAS",
                "SANTA HELENA DE MINAS",
                "SANTA JULIANA",
                "SANTA LUZIA",
                "SANTA MARGARIDA",
                "SANTA MARIA DE ITABIRA",
                "SANTA MARIA DO SALTO",
                "SANTA MARIA DO SUACUI",
                "SANTA RITA DE CALDAS",
                "SANTA RITA DE IBITIPOCA",
                "SANTA RITA DE JACUTINGA",
                "SANTA RITA DE MINAS",
                "SANTA RITA DO ITUETO",
                "SANTA RITA DO SAPUCAI",
                "SANTA ROSA DA SERRA",
                "SANTA VITORIA",
                "SANTANA DA VARGEM",
                "SANTANA DE CATAGUASES",
                "SANTANA DE PIRAPAMA",
                "SANTANA DO DESERTO",
                "SANTANA DO GARAMBEU",
                "SANTANA DO JACARE",
                "SANTANA DO MANHUACU",
                "SANTANA DO PARAISO",
                "SANTANA DO RIACHO",
                "SANTANA DOS MONTES",
                "SANTO ANTONIO DO AMPARO",
                "SANTO ANTONIO DO AVENTUREIRO",
                "SANTO ANTONIO DO GRAMA",
                "SANTO ANTONIO DO ITAMBE",
                "SANTO ANTONIO DO JACINTO",
                "SANTO ANTONIO DO MONTE",
                "SANTO ANTONIO DO RETIRO",
                "SANTO ANTONIO DO RIO ABAIXO",
                "SANTO HIPOLITO",
                "SANTOS DUMONT",
                "SAO BENTO ABADE",
                "SAO BRAS DO SUACUI",
                "SAO DOMINGOS DAS DORES",
                "SAO DOMINGOS DO PRATA",
                "SAO FELIX DE MINAS",
                "SAO FRANCISCO",
                "SAO FRANCISCO DE PAULA",
                "SAO FRANCISCO DE SALES",
                "SAO FRANCISCO DO GLORIA",
                "SAO GERALDO",
                "SAO GERALDO DA PIEDADE",
                "SAO GERALDO DO BAIXIO",
                "SAO GONCALO DO ABAETE",
                "SAO GONCALO DO PARA",
                "SAO GONCALO DO RIO ABAIXO",
                "SAO GONCALO DO RIO PRETO",
                "SAO GONCALO DO SAPUCAI",
                "SAO GOTARDO",
                "SAO JOAO BATISTA DO GLORIA",
                "SAO JOAO DA LAGOA",
                "SAO JOAO DA MATA",
                "SAO JOAO DA PONTE",
                "SAO JOAO DAS MISSOES",
                "SAO JOAO DEL REI",
                "SAO JOAO DO MANHUACU",
                "SAO JOAO DO MANTENINHA",
                "SAO JOAO DO ORIENTE",
                "SAO JOAO DO PACUI",
                "SAO JOAO DO PARAISO",
                "SAO JOAO EVANGELISTA",
                "SAO JOAO NEPOMUCENO",
                "SAO JOAQUIM DE BICAS",
                "SAO JOSE DA BARRA",
                "SAO JOSE DA LAPA",
                "SAO JOSE DA SAFIRA",
                "SAO JOSE DA VARGINHA",
                "SAO JOSE DO ALEGRE",
                "SAO JOSE DO DIVINO",
                "SAO JOSE DO GOIABAL",
                "SAO JOSE DO JACURI",
                "SAO JOSE DO MANTIMENTO",
                "SAO LOURENCO",
                "SAO MIGUEL DO ANTA",
                "SAO PEDRO DA UNIAO",
                "SAO PEDRO DO SUACUI",
                "SAO PEDRO DOS FERROS",
                "SAO ROMAO",
                "SAO ROQUE DE MINAS",
                "SAO SEBASTIAO DA BELA VISTA",
                "SAO SEBASTIAO DA VARGEM ALEGRE",
                "SAO SEBASTIAO DO ANTA",
                "SAO SEBASTIAO DO MARANHAO",
                "SAO SEBASTIAO DO OESTE",
                "SAO SEBASTIAO DO PARAISO",
                "SAO SEBASTIAO DO RIO PRETO",
                "SAO SEBASTIAO DO RIO VERDE",
                "SAO THOME DAS LETRAS",
                "SAO TIAGO",
                "SAO TOMAS DE AQUINO",
                "SAO VICENTE DE MINAS",
                "SAPUCAI-MIRIM",
                "SARDOA",
                "SARZEDO",
                "SEM-PEIXE",
                "SENADOR AMARAL",
                "SENADOR CORTES",
                "SENADOR FIRMINO",
                "SENADOR JOSE BENTO",
                "SENADOR MODESTINO GONCALVES",
                "SENHORA DE OLIVEIRA",
                "SENHORA DO PORTO",
                "SENHORA DOS REMEDIOS",
                "SERICITA",
                "SERITINGA",
                "SERRA AZUL DE MINAS",
                "SERRA DA SAUDADE",
                "SERRA DO SALITRE",
                "SERRA DOS AIMORES",
                "SERRANIA",
                "SERRANOPOLIS DE MINAS",
                "SERRANOS",
                "SERRO",
                "SETE LAGOAS",
                "SETUBINHA",
                "SILVEIRANIA",
                "SILVIANOPOLIS",
                "SIMAO PEREIRA",
                "SIMONESIA",
                "SOBRALIA",
                "SOLEDADE DE MINAS",
                "TABULEIRO",
                "TAIOBEIRAS",
                "TAPARUBA",
                "TAPIRA",
                "TAPIRAI",
                "TAQUARACU DE MINAS",
                "TARUMIRIM",
                "TEIXEIRAS",
                "TEOFILO OTONI",
                "TIMOTEO",
                "TIRADENTES",
                "TIROS",
                "TOCANTINS",
                "TOCOS DO MOJI",
                "TOLEDO",
                "TOMBOS",
                "TRES CORACOES",
                "TRES MARIAS",
                "TRES PONTAS",
                "TUMIRITINGA",
                "TUPACIGUARA",
                "TURMALINA",
                "TURVOLANDIA",
                "UBA",
                "UBAI",
                "UBAPORANGA",
                "UBERABA",
                "UBERLANDIA",
                "UMBURATIBA",
                "UNAI",
                "UNIAO DE MINAS",
                "URUANA DE MINAS",
                "URUCANIA",
                "URUCUIA",
                "VARGEM ALEGRE",
                "VARGEM BONITA",
                "VARGEM GRANDE DO RIO PARDO",
                "VARGINHA",
                "VARJAO DE MINAS",
                "VARZEA DA PALMA",
                "VARZELANDIA",
                "VAZANTE",
                "VERDELANDIA",
                "VEREDINHA",
                "VERISSIMO",
                "VERMELHO NOVO",
                "VESPASIANO",
                "VICOSA",
                "VIEIRAS",
                "VIRGEM DA LAPA",
                "VIRGINIA",
                "VIRGINOPOLIS",
                "VIRGOLANDIA",
                "VISCONDE DO RIO BRANCO",
                "VOLTA GRANDE",
                "WENCESLAU BRAZ"
                //Mato Grosso do Sul - MS
                    ,
                "AGUA CLARA",
                "ALCINOPOLIS",
                "AMAMBAI",
                "ANASTACIO",
                "ANAURILANDIA",
                "ANGELICA",
                "ANTONIO JOAO",
                "APARECIDA DO TABOADO",
                "AQUIDAUANA",
                "ARAL MOREIRA",
                "BANDEIRANTES",
                "BATAGUASSU",
                "BATAIPORA",
                "BELA VISTA",
                "BODOQUENA",
                "BONITO",
                "BRASILANDIA",
                "CAARAPO",
                "CAMAPUA",
                "CAMPO GRANDE",
                "CARACOL",
                "CASSILANDIA",
                "CHAPADAO DO SUL",
                "CORGUINHO",
                "CORONEL SAPUCAIA",
                "CORUMBA",
                "COSTA RICA",
                "COXIM",
                "DEODAPOLIS",
                "DOIS IRMAOS DO BURITI",
                "DOURADINA",
                "DOURADOS",
                "ELDORADO",
                "FATIMA DO SUL",
                "GLORIA DE DOURADOS",
                "GUIA LOPES DA LAGUNA",
                "IGUATEMI",
                "INOCENCIA",
                "ITAPORA",
                "ITAQUIRAI",
                "IVINHEMA",
                "JAPORA",
                "JARAGUARI",
                "JARDIM",
                "JATEI",
                "JUTI",
                "LADARIO",
                "LAGUNA CARAPA",
                "MARACAJU",
                "MIRANDA",
                "MUNDO NOVO",
                "NAVIRAI",
                "NIOAQUE",
                "NOVA ALVORADA DO SUL",
                "NOVA ANDRADINA",
                "NOVO HORIZONTE DO SUL",
                "PARANAIBA",
                "PARANHOS",
                "PEDRO GOMES",
                "PONTA PORA",
                "PORTO MURTINHO",
                "RIBAS DO RIO PARDO",
                "RIO BRILHANTE",
                "RIO NEGRO",
                "RIO VERDE DE MATO GROSSO",
                "ROCHEDO",
                "SANTA RITA DO PARDO",
                "SAO GABRIEL DO OESTE",
                "SELVIRIA",
                "SETE QUEDAS",
                "SIDROLANDIA",
                "SONORA",
                "TACURU",
                "TAQUARUSSU",
                "TERENOS",
                "TRES LAGOAS",
                "VICENTINA"
                //Mato Grosso - MT
                    ,
                "ACORIZAL",
                "AGUA BOA",
                "ALTA FLORESTA",
                "ALTO ARAGUAIA",
                "ALTO BOA VISTA",
                "ALTO GARCAS",
                "ALTO PARAGUAI",
                "ALTO TAQUARI",
                "APIACAS",
                "ARAGUAIANA",
                "ARAGUAINHA",
                "ARAPUTANGA",
                "ARENAPOLIS",
                "ARIPUANA",
                "BARAO DE MELGACO",
                "BARRA DO BUGRES",
                "BARRA DO GARCAS",
                "BOM JESUS DO ARAGUAIA",
                "BRASNORTE",
                "CACERES",
                "CAMPINAPOLIS",
                "CAMPO NOVO DO PARECIS",
                "CAMPO VERDE",
                "CAMPOS DE JULIO",
                "CANABRAVA DO NORTE",
                "CANARANA",
                "CARLINDA",
                "CASTANHEIRA",
                "CHAPADA DOS GUIMARAES",
                "CLAUDIA",
                "COCALINHO",
                "COLIDER",
                "COLNIZA",
                "COMODORO",
                "CONFRESA",
                "CONQUISTA D'OESTE",
                "COTRIGUACU",
                "CURVELANDIA",
                "CUIABA",
                "DENISE",
                "DIAMANTINO",
                "DOM AQUINO",
                "FELIZ NATAL",
                "FIGUEIROPOLIS D'OESTE",
                "GAUCHA DO NORTE",
                "GENERAL CARNEIRO",
                "GLORIA D'OESTE",
                "GUARANTA DO NORTE",
                "GUIRATINGA",
                "INDIAVAI",
                "ITAUBA",
                "ITIQUIRA",
                "JACIARA",
                "JANGADA",
                "JAURU",
                "JUARA",
                "JUINA",
                "JURUENA",
                "JUSCIMEIRA",
                "LAMBARI D'OESTE",
                "LUCAS DO RIO VERDE",
                "LUCIARA",
                "MARCELANDIA",
                "MATUPA",
                "MIRASSOL D'OESTE",
                "NOBRES",
                "NORTELANDIA",
                "NOSSA SENHORA DO LIVRAMENTO",
                "NOVA BANDEIRANTES",
                "NOVA BRASILANDIA",
                "NOVA CANAA DO NORTE",
                "NOVA GUARITA",
                "NOVA LACERDA",
                "NOVA MARILANDIA",
                "NOVA MARINGA",
                "NOVA MONTE VERDE",
                "NOVA MUTUM",
                "NOVA NAZARE",
                "NOVA OLIMPIA",
                "NOVA SANTA HELENA",
                "NOVA UBIRATA",
                "NOVA XAVANTINA",
                "NOVO HORIZONTE DO NORTE",
                "NOVO MUNDO",
                "NOVO SANTO ANTONIO",
                "NOVO SAO JOAQUIM",
                "PARANAITA",
                "PARANATINGA",
                "PEDRA PRETA",
                "PEIXOTO DE AZEVEDO",
                "PLANALTO DA SERRA",
                "POCONE",
                "PONTAL DO ARAGUAIA",
                "PONTE BRANCA",
                "PONTES E LACERDA",
                "PORTO ALEGRE DO NORTE",
                "PORTO DOS GAUCHOS",
                "PORTO ESPERIDIAO",
                "PORTO ESTRELA",
                "POXOREO",
                "PRIMAVERA DO LESTE",
                "QUERENCIA",
                "RESERVA DO CABACAL",
                "RIBEIRAO CASCALHEIRA",
                "RIBEIRAOZINHO",
                "RIO BRANCO",
                "RONDOLANDIA",
                "RONDONOPOLIS",
                "ROSARIO OESTE",
                "SALTO DO CEU",
                "SANTA CARMEM",
                "SANTA CRUZ DO XINGU",
                "SANTA RITA DO TRIVELATO",
                "SANTA TEREZINHA",
                "SANTO AFONSO",
                "SANTO ANTONIO DO LESTE",
                "SANTO ANTONIO DO LEVERGER",
                "SAO FELIX DO ARAGUAIA",
                "SAO JOSE DO POVO",
                "SAO JOSE DO RIO CLARO",
                "SAO JOSE DO XINGU",
                "SAO JOSE DOS QUATRO MARCOS",
                "SAO PEDRO DA CIPA",
                "SAPEZAL",
                "SERRA NOVA DOURADA",
                "SINOP",
                "SORRISO",
                "TABAPORA",
                "TANGARA DA SERRA",
                "TAPURAH",
                "TERRA NOVA DO NORTE",
                "TESOURO",
                "TORIXOREU",
                "UNIAO DO SUL",
                "VALE DE SAO DOMINGOS",
                "VARZEA GRANDE",
                "VERA",
                "VILA BELA DA SANTISSIMA TRINDADE",
                "VILA RICA"
                //Pará - PA
                    ,
                "ABAETETUBA",
                "ABEL FIGUEIREDO",
                "ACARA",
                "AFUA",
                "AGUA AZUL DO NORTE",
                "ALENQUER",
                "ALMEIRIM",
                "ALTAMIRA",
                "ANAJAS",
                "ANANINDEUA",
                "ANAPU",
                "AUGUSTO CORREA",
                "AURORA DO PARA",
                "AVEIRO",
                "BAGRE",
                "BAIAO",
                "BANNACH",
                "BARCARENA",
                "BELEM",
                "BELTERRA",
                "BENEVIDES",
                "BOM JESUS DO TOCANTINS",
                "BONITO",
                "BRAGANCA",
                "BRASIL NOVO",
                "BREJO GRANDE DO ARAGUAIA",
                "BREU BRANCO",
                "BREVES",
                "BUJARU",
                "CACHOEIRA DO ARARI",
                "CACHOEIRA DO PIRIA",
                "CAMETA",
                "CANAA DOS CARAJAS",
                "CAPANEMA",
                "CAPITAO POCO",
                "CASTANHAL",
                "CHAVES",
                "COLARES",
                "CONCEICAO DO ARAGUAIA",
                "CONCORDIA DO PARA",
                "CUMARU DO NORTE",
                "CURIONOPOLIS",
                "CURRALINHO",
                "CURUA",
                "CURUCA",
                "DOM ELISEU",
                "ELDORADO DOS CARAJAS",
                "FARO",
                "FLORESTA DO ARAGUAIA",
                "GARRAFAO DO NORTE",
                "GOIANESIA DO PARA",
                "GURUPA",
                "IGARAPE-ACU",
                "IGARAPE-MIRI",
                "INHANGAPI",
                "IPIXUNA DO PARA",
                "IRITUIA",
                "ITAITUBA",
                "ITUPIRANGA",
                "JACAREACANGA",
                "JACUNDA",
                "JURUTI",
                "LIMOEIRO DO AJURU",
                "MAE DO RIO",
                "MAGALHAES BARATA",
                "MARABA",
                "MARACANA",
                "MARAPANIM",
                "MARITUBA",
                "MEDICILANDIA",
                "MELGACO",
                "MOCAJUBA",
                "MOJU",
                "MONTE ALEGRE",
                "MUANA",
                "NOVA ESPERANCA DO PIRIA",
                "NOVA IPIXUNA",
                "NOVA TIMBOTEUA",
                "NOVO PROGRESSO",
                "NOVO REPARTIMENTO",
                "OBIDOS",
                "OEIRAS DO PARA",
                "ORIXIMINA",
                "OUREM",
                "OURILANDIA DO NORTE",
                "PACAJA",
                "PALESTINA DO PARA",
                "PARAGOMINAS",
                "PARAUAPEBAS",
                "PAU D'ARCO",
                "PEIXE-BOI",
                "PICARRA",
                "PLACAS",
                "PONTA DE PEDRAS",
                "PORTEL",
                "PORTO DE MOZ",
                "PRAINHA",
                "PRIMAVERA",
                "QUATIPURU",
                "REDENCAO",
                "RIO MARIA",
                "RONDON DO PARA",
                "RUROPOLIS",
                "SALINOPOLIS",
                "SALVATERRA",
                "SANTA BARBARA DO PARA",
                "SANTA CRUZ DO ARARI",
                "SANTA ISABEL DO PARA",
                "SANTA LUZIA DO PARA",
                "SANTA MARIA DAS BARREIRAS",
                "SANTA MARIA DO PARA",
                "SANTANA DO ARAGUAIA",
                "SANTAREM",
                "SANTAREM NOVO",
                "SANTO ANTONIO DO TAUA",
                "SAO CAETANO DE ODIVELA",
                "SAO DOMINGOS DO ARAGUAIA",
                "SAO DOMINGOS DO CAPIM",
                "SAO FELIX DO XINGU",
                "SAO FRANCISCO DO PARA",
                "SAO GERALDO DO ARAGUAIA",
                "SAO JOAO DA PONTA",
                "SAO JOAO DE PIRABAS",
                "SAO JOAO DO ARAGUAIA",
                "SAO MIGUEL DO GUAMA",
                "SAO SEBASTIAO DA BOA VISTA",
                "SAPUCAIA",
                "SENADOR JOSE PORFIRIO",
                "SOURE",
                "TAILANDIA",
                "TERRA ALTA",
                "TERRA SANTA",
                "TOME-ACU",
                "TRACUATEUA",
                "TRAIRAO",
                "TUCUMA",
                "TUCURUI",
                "ULIANOPOLIS",
                "URUARA",
                "VIGIA",
                "VISEU",
                "VITORIA DO XINGU",
                "XINGUARA"
                //Paraíba - PB
                    ,
                "AGUA BRANCA",
                "AGUIAR",
                "ALAGOA GRANDE",
                "ALAGOA NOVA",
                "ALAGOINHA",
                "ALCANTIL",
                "ALGODAO DE JANDAIRA",
                "ALHANDRA",
                "AMPARO",
                "APARECIDA",
                "ARACAGI",
                "ARARA",
                "ARARUNA",
                "AREIA",
                "AREIA DE BARAUNAS",
                "AREIAL",
                "AROEIRAS",
                "ASSUNCAO",
                "BAIA DA TRAICAO",
                "BANANEIRAS",
                "BARAUNA",
                "BARRA DE SANTA ROSA",
                "BARRA DE SANTANA",
                "BARRA DE SAO MIGUEL",
                "BAYEUX",
                "BELEM",
                "BELEM DO BREJO DO CRUZ",
                "BERNARDINO BATISTA",
                "BOA VENTURA",
                "BOA VISTA",
                "BOM JESUS",
                "BOM SUCESSO",
                "BONITO DE SANTA FE",
                "BOQUEIRAO",
                "BORBOREMA",
                "BREJO DO CRUZ",
                "BREJO DOS SANTOS",
                "CAAPORA",
                "CABACEIRAS",
                "CABEDELO",
                "CACHOEIRA DOS INDIOS",
                "CACIMBA DE AREIA",
                "CACIMBA DE DENTRO",
                "CACIMBAS",
                "CAICARA",
                "CAJAZEIRAS",
                "CAJAZEIRINHAS",
                "CALDAS BRANDAO",
                "CAMALAU",
                "CAMPINA GRANDE",
                "CAMPO DE SANTANA",
                "CAPIM",
                "CARAUBAS",
                "CARRAPATEIRA",
                "CASSERENGUE",
                "CATINGUEIRA",
                "CATOLE DO ROCHA",
                "CATURITE",
                "CONCEICAO",
                "CONDADO",
                "CONDE",
                "CONGO",
                "COREMAS",
                "COXIXOLA",
                "CRUZ DO ESPIRITO SANTO",
                "CUBATI",
                "CUITE",
                "CUITE DE MAMANGUAPE",
                "CUITEGI",
                "CURRAL DE CIMA",
                "CURRAL VELHO",
                "DAMIAO",
                "DESTERRO",
                "DIAMANTE",
                "DONA INES",
                "DUAS ESTRADAS",
                "EMAS",
                "ESPERANCA",
                "FAGUNDES",
                "FREI MARTINHO",
                "GADO BRAVO",
                "GUARABIRA",
                "GURINHEM",
                "GURJAO",
                "IBIARA",
                "IGARACY",
                "IMACULADA",
                "INGA",
                "ITABAIANA",
                "ITAPORANGA",
                "ITAPOROROCA",
                "ITATUBA",
                "JACARAU",
                "JERICO",
                "JOAO PESSOA",
                "JUAREZ TAVORA",
                "JUAZEIRINHO",
                "JUNCO DO SERIDO",
                "JURIPIRANGA",
                "JURU",
                "LAGOA",
                "LAGOA DE DENTRO",
                "LAGOA SECA",
                "LASTRO",
                "LIVRAMENTO",
                "LOGRADOURO",
                "LUCENA",
                "MAE D'AGUA",
                "MALTA",
                "MAMANGUAPE",
                "MANAIRA",
                "MARCACAO",
                "MARI",
                "MARIZOPOLIS",
                "MASSARANDUBA",
                "MATARACA",
                "MATINHAS",
                "MATO GROSSO",
                "MATUREIA",
                "MOGEIRO",
                "MONTADAS",
                "MONTE HOREBE",
                "MONTEIRO",
                "MULUNGU",
                "NATUBA",
                "NAZAREZINHO",
                "NOVA FLORESTA",
                "NOVA OLINDA",
                "NOVA PALMEIRA",
                "OLHO D'AGUA",
                "OLIVEDOS",
                "OURO VELHO",
                "PARARI",
                "PASSAGEM",
                "PATOS",
                "PAULISTA",
                "PEDRA BRANCA",
                "PEDRA LAVRADA",
                "PEDRAS DE FOGO",
                "PEDRO REGIS",
                "PIANCO",
                "PICUI",
                "PILAR",
                "PILOES",
                "PILOEZINHOS",
                "PIRPIRITUBA",
                "PITIMBU",
                "POCINHOS",
                "POCO DANTAS",
                "POCO DE JOSE DE MOURA",
                "POMBAL",
                "PRATA",
                "PRINCESA ISABEL",
                "PUXINANA",
                "QUEIMADAS",
                "QUIXABA",
                "REMIGIO",
                "RIACHAO",
                "RIACHAO DO BACAMARTE",
                "RIACHAO DO POCO",
                "RIACHO DE SANTO ANTONIO",
                "RIACHO DOS CAVALOS",
                "RIO TINTO",
                "SALGADINHO",
                "SALGADO DE SAO FELIX",
                "SANTA CECILIA",
                "SANTA CRUZ",
                "SANTA HELENA",
                "SANTA INES",
                "SANTA LUZIA",
                "SANTA RITA",
                "SANTA TERESINHA",
                "SANTANA DE MANGUEIRA",
                "SANTANA DOS GARROTES",
                "SANTAREM",
                "SANTO ANDRE",
                "SAO BENTINHO",
                "SAO BENTO",
                "SAO DOMINGOS DE POMBAL",
                "SAO DOMINGOS DO CARIRI",
                "SAO FRANCISCO",
                "SAO JOAO DO CARIRI",
                "SAO JOAO DO RIO DO PEIXE",
                "SAO JOAO DO TIGRE",
                "SAO JOSE DA LAGOA TAPADA",
                "SAO JOSE DE CAIANA",
                "SAO JOSE DE ESPINHARAS",
                "SAO JOSE DE PIRANHAS",
                "SAO JOSE DE PRINCESA",
                "SAO JOSE DO BONFIM",
                "SAO JOSE DO BREJO DO CRUZ",
                "SAO JOSE DO SABUGI",
                "SAO JOSE DOS CORDEIROS",
                "SAO JOSE DOS RAMOS",
                "SAO MAMEDE",
                "SAO MIGUEL DE TAIPU",
                "SAO SEBASTIAO DE LAGOA DE ROCA",
                "SAO SEBASTIAO DO UMBUZEIRO",
                "SAPE",
                "SERIDO",
                "SERRA BRANCA",
                "SERRA DA RAIZ",
                "SERRA GRANDE",
                "SERRA REDONDA",
                "SERRARIA",
                "SERTAOZINHO",
                "SOBRADO",
                "SOLANEA",
                "SOLEDADE",
                "SOSSEGO",
                "SOUSA",
                "SUME",
                "TAPEROA",
                "TAVARES",
                "TEIXEIRA",
                "TENORIO",
                "TRIUNFO",
                "UIRAUNA",
                "UMBUZEIRO",
                "VARZEA",
                "VIEIROPOLIS",
                "VISTA SERRANA",
                "ZABELE"
                //Pernambuco - PE
                    ,
                "ABREU E LIMA",
                "AFOGADOS DA INGAZEIRA",
                "AFRANIO",
                "AGRESTINA",
                "AGUA PRETA",
                "AGUAS BELAS",
                "ALAGOINHA",
                "ALIANCA",
                "ALTINHO",
                "AMARAJI",
                "ANGELIM",
                "ARACOIABA",
                "ARARIPINA",
                "ARCOVERDE",
                "BARRA DE GUABIRABA",
                "BARREIROS",
                "BELEM DE MARIA",
                "BELEM DE SAO FRANCISCO",
                "BELO JARDIM",
                "BETANIA",
                "BEZERROS",
                "BODOCO",
                "BOM CONSELHO",
                "BOM JARDIM",
                "BONITO",
                "BREJAO",
                "BREJINHO",
                "BREJO DA MADRE DE DEUS",
                "BUENOS AIRES",
                "BUIQUE",
                "CABO DE SANTO AGOSTINHO",
                "CABROBO",
                "CACHOEIRINHA",
                "CAETES",
                "CALCADO",
                "CALUMBI",
                "CAMARAGIBE",
                "CAMOCIM DE SAO FELIX",
                "CAMUTANGA",
                "CANHOTINHO",
                "CAPOEIRAS",
                "CARNAIBA",
                "CARNAUBEIRA DA PENHA",
                "CARPINA",
                "CARUARU",
                "CASINHAS",
                "CATENDE",
                "CEDRO",
                "CHA DE ALEGRIA",
                "CHA GRANDE",
                "CONDADO",
                "CORRENTES",
                "CORTES",
                "CUMARU",
                "CUPIRA",
                "CUSTODIA",
                "DORMENTES",
                "ESCADA",
                "EXU",
                "FEIRA NOVA",
                "FERNANDO DE NORONHA",
                "FERREIROS",
                "FLORES",
                "FLORESTA",
                "FREI MIGUELINHO",
                "GAMELEIRA",
                "GARANHUNS",
                "GLORIA DO GOITA",
                "GOIANA",
                "GRANITO",
                "GRAVATA",
                "IATI",
                "IBIMIRIM",
                "IBIRAJUBA",
                "IGARASSU",
                "IGUARACI",
                "INAJA",
                "INGAZEIRA",
                "IPOJUCA",
                "IPUBI",
                "ITACURUBA",
                "ITAIBA",
                "ITAMARACA",
                "ITAMBE",
                "ITAPETIM",
                "ITAPISSUMA",
                "ITAQUITINGA",
                "JABOATAO DOS GUARARAPES",
                "JAQUEIRA",
                "JATAUBA",
                "JATOBA",
                "JOAO ALFREDO",
                "JOAQUIM NABUCO",
                "JUCATI",
                "JUPI",
                "JUREMA",
                "LAGOA DO CARRO",
                "LAGOA DO ITAENGA",
                "LAGOA DO OURO",
                "LAGOA DOS GATOS",
                "LAGOA GRANDE",
                "LAJEDO",
                "LIMOEIRO",
                "MACAPARANA",
                "MACHADOS",
                "MANARI",
                "MARAIAL",
                "MIRANDIBA",
                "MOREILANDIA",
                "MORENO",
                "NAZARE DA MATA",
                "OLINDA",
                "OROBO",
                "OROCO",
                "OURICURI",
                "PALMARES",
                "PALMEIRINA",
                "PANELAS",
                "PARANATAMA",
                "PARNAMIRIM",
                "PASSIRA",
                "PAUDALHO",
                "PAULISTA",
                "PEDRA",
                "PESQUEIRA",
                "PETROLANDIA",
                "PETROLINA",
                "POCAO",
                "POMBOS",
                "PRIMAVERA",
                "QUIPAPA",
                "QUIXABA",
                "RECIFE",
                "RIACHO DAS ALMAS",
                "RIBEIRAO",
                "RIO FORMOSO",
                "SAIRE",
                "SALGADINHO",
                "SALGUEIRO",
                "SALOA",
                "SANHARO",
                "SANTA CRUZ",
                "SANTA CRUZ DA BAIXA VERDE",
                "SANTA CRUZ DO CAPIBARIBE",
                "SANTA FILOMENA",
                "SANTA MARIA DA BOA VISTA",
                "SANTA MARIA DO CAMBUCA",
                "SANTA TEREZINHA",
                "SAO BENEDITO DO SUL",
                "SAO BENTO DO UNA",
                "SAO CAITANO",
                "SAO JOAO",
                "SAO JOAQUIM DO MONTE",
                "SAO JOSE DA COROA GRANDE",
                "SAO JOSE DO BELMONTE",
                "SAO JOSE DO EGITO",
                "SAO LOURENCO DA MATA",
                "SAO VICENTE FERRER",
                "SERRA TALHADA",
                "SERRITA",
                "SERTANIA",
                "SIRINHAEM",
                "SOLIDAO",
                "SURUBIM",
                "TABIRA",
                "TACAIMBO",
                "TACARATU",
                "TAMANDARE",
                "TAQUARITINGA DO NORTE",
                "TEREZINHA",
                "TERRA NOVA",
                "TIMBAUBA",
                "TORITAMA",
                "TRACUNHAEM",
                "TRINDADE",
                "TRIUNFO",
                "TUPANATINGA",
                "TUPARETAMA",
                "VENTUROSA",
                "VERDEJANTE",
                "VERTENTE DO LERIO",
                "VERTENTES",
                "VICENCIA",
                "VITORIA DE SANTO ANTAO",
                "XEXEU"
                //Piauí - PI
                    ,
                "ACAUA",
                "AGRICOLANDIA",
                "AGUA BRANCA",
                "ALAGOINHA DO PIAUI",
                "ALEGRETE DO PIAUI",
                "ALTO LONGA",
                "ALTOS",
                "ALVORADA DO GURGUEIA",
                "AMARANTE",
                "ANGICAL DO PIAUI",
                "ANISIO DE ABREU",
                "ANTONIO ALMEIDA",
                "AROAZES",
                "ARRAIAL",
                "ASSUNCAO DO PIAUI",
                "AVELINO LOPES",
                "BAIXA GRANDE DO RIBEIRO",
                "BARRA D'ALCANTARA",
                "BARRAS",
                "BARREIRAS DO PIAUI",
                "BARRO DURO",
                "BATALHA",
                "BELA VISTA DO PIAUI",
                "BELEM DO PIAUI",
                "BENEDITINOS",
                "BERTOLINIA",
                "BETANIA DO PIAUI",
                "BOA HORA",
                "BOCAINA",
                "BOM JESUS",
                "BOM PRINCIPIO DO PIAUI",
                "BONFIM DO PIAUI",
                "BOQUEIRAO DO PIAUI",
                "BRASILEIRA",
                "BREJO DO PIAUI",
                "BURITI DOS LOPES",
                "BURITI DOS MONTES",
                "CABECEIRAS DO PIAUI",
                "CAJAZEIRAS DO PIAUI",
                "CAJUEIRO DA PRAIA",
                "CALDEIRAO GRANDE DO PIAUI",
                "CAMPINAS DO PIAUI",
                "CAMPO ALEGRE DO FIDALGO",
                "CAMPO GRANDE DO PIAUI",
                "CAMPO LARGO DO PIAUI",
                "CAMPO MAIOR",
                "CANAVIEIRA",
                "CANTO DO BURITI",
                "CAPITAO DE CAMPOS",
                "CAPITAO GERVASIO OLIVEIRA",
                "CARACOL",
                "CARAUBAS DO PIAUI",
                "CARIDADE DO PIAUI",
                "CASTELO DO PIAUI",
                "CAXINGO",
                "COCAL",
                "COCAL DE TELHA",
                "COCAL DOS ALVES",
                "COIVARAS",
                "COLONIA DO GURGUEIA",
                "COLONIA DO PIAUI",
                "CONCEICAO DO CANINDE",
                "CORONEL JOSE DIAS",
                "CORRENTE",
                "CRISTALANDIA DO PIAUI",
                "CRISTINO CASTRO",
                "CURIMATA",
                "CURRAIS",
                "CURRAL NOVO DO PIAUI",
                "CURRALINHOS",
                "DEMERVAL LOBAO",
                "DIRCEU ARCOVERDE",
                "DOM EXPEDITO LOPES",
                "DOM INOCENCIO",
                "DOMINGOS MOURAO",
                "ELESBAO VELOSO",
                "ELISEU MARTINS",
                "ESPERANTINA",
                "FARTURA DO PIAUI",
                "FLORES DO PIAUI",
                "FLORESTA DO PIAUI",
                "FLORIANO",
                "FRANCINOPOLIS",
                "FRANCISCO AYRES",
                "FRANCISCO MACEDO",
                "FRANCISCO SANTOS",
                "FRONTEIRAS",
                "GEMINIANO",
                "GILBUES",
                "GUADALUPE",
                "GUARIBAS",
                "HUGO NAPOLEAO",
                "ILHA GRANDE",
                "INHUMA",
                "IPIRANGA DO PIAUI",
                "ISAIAS COELHO",
                "ITAINOPOLIS",
                "ITAUEIRA",
                "JACOBINA DO PIAUI",
                "JAICOS",
                "JARDIM DO MULATO",
                "JATOBA DO PIAUI",
                "JERUMENHA",
                "JOAO COSTA",
                "JOAQUIM PIRES",
                "JOCA MARQUES",
                "JOSE DE FREITAS",
                "JUAZEIRO DO PIAUI",
                "JULIO BORGES",
                "JUREMA",
                "LAGOA ALEGRE",
                "LAGOA DE SAO FRANCISCO",
                "LAGOA DO BARRO DO PIAUI",
                "LAGOA DO PIAUI",
                "LAGOA DO SITIO",
                "LAGOINHA DO PIAUI",
                "LANDRI SALES",
                "LUIS CORREIA",
                "LUZILANDIA",
                "MADEIRO",
                "MANOEL EMIDIO",
                "MARCOLANDIA",
                "MARCOS PARENTE",
                "MASSAPE DO PIAUI",
                "MATIAS OLIMPIO",
                "MIGUEL ALVES",
                "MIGUEL LEAO",
                "MILTON BRANDAO",
                "MONSENHOR GIL",
                "MONSENHOR HIPOLITO",
                "MONTE ALEGRE DO PIAUI",
                "MORRO CABECA NO TEMPO",
                "MORRO DO CHAPEU DO PIAUI",
                "MURICI DOS PORTELAS",
                "NAZARE DO PIAUI",
                "NOSSA SENHORA DE NAZARE",
                "NOSSA SENHORA DOS REMEDIOS",
                "NOVA SANTA RITA",
                "NOVO ORIENTE DO PIAUI",
                "NOVO SANTO ANTONIO",
                "OEIRAS",
                "OLHO D'AGUA DO PIAUI",
                "PADRE MARCOS",
                "PAES LANDIM",
                "PAJEU DO PIAUI",
                "PALMEIRA DO PIAUI",
                "PALMEIRAIS",
                "PAQUETA",
                "PARNAGUA",
                "PARNAIBA",
                "PASSAGEM FRANCA DO PIAUI",
                "PATOS DO PIAUI",
                "PAU D'ARCO DO PIAUI",
                "PAULISTANA",
                "PAVUSSU",
                "PEDRO II",
                "PEDRO LAURENTINO",
                "PICOS",
                "PIMENTEIRAS",
                "PIO IX",
                "PIRACURUCA",
                "PIRIPIRI",
                "PORTO",
                "PORTO ALEGRE DO PIAUI",
                "PRATA DO PIAUI",
                "QUEIMADA NOVA",
                "REDENCAO DO GURGUEIA",
                "REGENERACAO",
                "RIACHO FRIO",
                "RIBEIRA DO PIAUI",
                "RIBEIRO GONCALVES",
                "RIO GRANDE DO PIAUI",
                "SANTA CRUZ DO PIAUI",
                "SANTA CRUZ DOS MILAGRES",
                "SANTA FILOMENA",
                "SANTA LUZ",
                "SANTA ROSA DO PIAUI",
                "SANTANA DO PIAUI",
                "SANTO ANTONIO DE LISBOA",
                "SANTO ANTONIO DOS MILAGRES",
                "SANTO INACIO DO PIAUI",
                "SAO BRAZ DO PIAUI",
                "SAO FELIX DO PIAUI",
                "SAO FRANCISCO DE ASSIS DO PIAUI",
                "SAO FRANCISCO DO PIAUI",
                "SAO GONCALO DO GURGUEIA",
                "SAO GONCALO DO PIAUI",
                "SAO JOAO DA CANABRAVA",
                "SAO JOAO DA FRONTEIRA",
                "SAO JOAO DA SERRA",
                "SAO JOAO DA VARJOTA",
                "SAO JOAO DO ARRAIAL",
                "SAO JOAO DO PIAUI",
                "SAO JOSE DO DIVINO",
                "SAO JOSE DO PEIXE",
                "SAO JOSE DO PIAUI",
                "SAO JULIAO",
                "SAO LOURENCO DO PIAUI",
                "SAO LUIS DO PIAUI",
                "SAO MIGUEL DA BAIXA GRANDE",
                "SAO MIGUEL DO FIDALGO",
                "SAO MIGUEL DO TAPUIO",
                "SAO PEDRO DO PIAUI",
                "SAO RAIMUNDO NONATO",
                "SEBASTIAO BARROS",
                "SEBASTIAO LEAL",
                "SIGEFREDO PACHECO",
                "SIMOES",
                "SIMPLICIO MENDES",
                "SOCORRO DO PIAUI",
                "SUSSUAPARA",
                "TAMBORIL DO PIAUI",
                "TANQUE DO PIAUI",
                "TERESINA",
                "UNIAO",
                "URUCUI",
                "VALENCA DO PIAUI",
                "VARZEA BRANCA",
                "VARZEA GRANDE",
                "VERA MENDES",
                "VILA NOVA DO PIAUI",
                "WALL FERRAZ"
                //Paraná - PR
                    ,
                "ABATIA",
                "ADRIANOPOLIS",
                "AGUDOS DO SUL",
                "ALMIRANTE TAMANDARE",
                "ALTAMIRA DO PARANA",
                "ALTO PARANA",
                "ALTO PIQUIRI",
                "ALTONIA",
                "ALVORADA DO SUL",
                "AMAPORA",
                "AMPERE",
                "ANAHY",
                "ANDIRA",
                "ANGULO",
                "ANTONINA",
                "ANTONIO OLINTO",
                "APUCARANA",
                "ARAPONGAS",
                "ARAPOTI",
                "ARAPUA",
                "ARARUNA",
                "ARAUCARIA",
                "ARIRANHA DO IVAI",
                "ASSAI",
                "ASSIS CHATEAUBRIAND",
                "ASTORGA",
                "ATALAIA",
                "BALSA NOVA",
                "BANDEIRANTES",
                "BARBOSA FERRAZ",
                "BARRA DO JACARE",
                "BARRACAO",
                "BELA VISTA DA CAROBA",
                "BELA VISTA DO PARAISO",
                "BITURUNA",
                "BOA ESPERANCA",
                "BOA ESPERANCA DO IGUACU",
                "BOA VENTURA DE SAO ROQUE",
                "BOA VISTA DA APARECIDA",
                "BOCAIUVA DO SUL",
                "BOM JESUS DO SUL",
                "BOM SUCESSO",
                "BOM SUCESSO DO SUL",
                "BORRAZOPOLIS",
                "BRAGANEY",
                "BRASILANDIA DO SUL",
                "CAFEARA",
                "CAFELANDIA",
                "CAFEZAL DO SUL",
                "CALIFORNIA",
                "CAMBARA",
                "CAMBE",
                "CAMBIRA",
                "CAMPINA DA LAGOA",
                "CAMPINA DO SIMAO",
                "CAMPINA GRANDE DO SUL",
                "CAMPO BONITO",
                "CAMPO DO TENENTE",
                "CAMPO LARGO",
                "CAMPO MAGRO",
                "CAMPO MOURAO",
                "CANDIDO DE ABREU",
                "CANDOI",
                "CANTAGALO",
                "CAPANEMA",
                "CAPITAO LEONIDAS MARQUES",
                "CARAMBEI",
                "CARLOPOLIS",
                "CASCAVEL",
                "CASTRO",
                "CATANDUVAS",
                "CENTENARIO DO SUL",
                "CERRO AZUL",
                "CEU AZUL",
                "CHOPINZINHO",
                "CIANORTE",
                "CIDADE GAUCHA",
                "CLEVELANDIA",
                "COLOMBO",
                "COLORADO",
                "CONGONHINHAS",
                "CONSELHEIRO MAIRINCK",
                "CONTENDA",
                "CORBELIA",
                "CORNELIO PROCOPIO",
                "CORONEL DOMINGOS SOARES",
                "CORONEL VIVIDA",
                "CORUMBATAI DO SUL",
                "CRUZ MACHADO",
                "CRUZEIRO DO IGUACU",
                "CRUZEIRO DO OESTE",
                "CRUZEIRO DO SUL",
                "CRUZMALTINA",
                "CURITIBA",
                "CURIUVA",
                "DIAMANTE D'OESTE",
                "DIAMANTE DO NORTE",
                "DIAMANTE DO SUL",
                "DOIS VIZINHOS",
                "DOURADINA",
                "DOUTOR CAMARGO",
                "DOUTOR ULYSSES",
                "ENEAS MARQUES",
                "ENGENHEIRO BELTRAO",
                "ENTRE RIOS DO OESTE",
                "ESPERANCA NOVA",
                "ESPIGAO ALTO DO IGUACU",
                "FAROL",
                "FAXINAL",
                "FAZENDA RIO GRANDE",
                "FENIX",
                "FERNANDES PINHEIRO",
                "FIGUEIRA",
                "FLOR DA SERRA DO SUL",
                "FLORAI",
                "FLORESTA",
                "FLORESTOPOLIS",
                "FLORIDA",
                "FORMOSA DO OESTE",
                "FOZ DO IGUACU",
                "FOZ DO JORDAO",
                "FRANCISCO ALVES",
                "FRANCISCO BELTRAO",
                "GENERAL CARNEIRO",
                "GODOY MOREIRA",
                "GOIOERE",
                "GOIOXIM",
                "GRANDES RIOS",
                "GUAIRA",
                "GUAIRACA",
                "GUAMIRANGA",
                "GUAPIRAMA",
                "GUAPOREMA",
                "GUARACI",
                "GUARANIACU",
                "GUARAPUAVA",
                "GUARAQUECABA",
                "GUARATUBA",
                "HONORIO SERPA",
                "IBAITI",
                "IBEMA",
                "IBIPORA",
                "ICARAIMA",
                "IGUARACU",
                "IGUATU",
                "IMBAU",
                "IMBITUVA",
                "INACIO MARTINS",
                "INAJA",
                "INDIANOPOLIS",
                "IPIRANGA",
                "IPORA",
                "IRACEMA DO OESTE",
                "IRATI",
                "IRETAMA",
                "ITAGUAJE",
                "ITAIPULANDIA",
                "ITAMBARACA",
                "ITAMBE",
                "ITAPEJARA D'OESTE",
                "ITAPERUCU",
                "ITAUNA DO SUL",
                "IVAI",
                "IVAIPORA",
                "IVATE",
                "IVATUBA",
                "JABOTI",
                "JACAREZINHO",
                "JAGUAPITA",
                "JAGUARIAIVA",
                "JANDAIA DO SUL",
                "JANIOPOLIS",
                "JAPIRA",
                "JAPURA",
                "JARDIM ALEGRE",
                "JARDIM OLINDA",
                "JATAIZINHO",
                "JESUITAS",
                "JOAQUIM TAVORA",
                "JUNDIAI DO SUL",
                "JURANDA",
                "JUSSARA",
                "KALORE",
                "LAPA",
                "LARANJAL",
                "LARANJEIRAS DO SUL",
                "LEOPOLIS",
                "LIDIANOPOLIS",
                "LINDOESTE",
                "LOANDA",
                "LOBATO",
                "LONDRINA",
                "LUIZIANA",
                "LUNARDELLI",
                "LUPIONOPOLIS",
                "MALLET",
                "MAMBORE",
                "MANDAGUACU",
                "MANDAGUARI",
                "MANDIRITUBA",
                "MANFRINOPOLIS",
                "MANGUEIRINHA",
                "MANOEL RIBAS",
                "MARECHAL CANDIDO RONDON",
                "MARIA HELENA",
                "MARIALVA",
                "MARILANDIA DO SUL",
                "MARILENA",
                "MARILUZ",
                "MARINGA",
                "MARIOPOLIS",
                "MARIPA",
                "MARMELEIRO",
                "MARQUINHO",
                "MARUMBI",
                "MATELANDIA",
                "MATINHOS",
                "MATO RICO",
                "MAUA DA SERRA",
                "MEDIANEIRA",
                "MERCEDES",
                "MIRADOR",
                "MIRASELVA",
                "MISSAL",
                "MOREIRA SALES",
                "MORRETES",
                "MUNHOZ DE MELO",
                "NOSSA SENHORA DAS GRACAS",
                "NOVA ALIANCA DO IVAI",
                "NOVA AMERICA DA COLINA",
                "NOVA AURORA",
                "NOVA CANTU",
                "NOVA ESPERANCA",
                "NOVA ESPERANCA DO SUDOESTE",
                "NOVA FATIMA",
                "NOVA LARANJEIRAS",
                "NOVA LONDRINA",
                "NOVA OLIMPIA",
                "NOVA PRATA DO IGUACU",
                "NOVA SANTA BARBARA",
                "NOVA SANTA ROSA",
                "NOVA TEBAS",
                "NOVO ITACOLOMI",
                "ORTIGUEIRA",
                "OURIZONA",
                "OURO VERDE DO OESTE",
                "PAICANDU",
                "PALMAS",
                "PALMEIRA",
                "PALMITAL",
                "PALOTINA",
                "PARAISO DO NORTE",
                "PARANACITY",
                "PARANAGUA",
                "PARANAPOEMA",
                "PARANAVAI",
                "PATO BRAGADO",
                "PATO BRANCO",
                "PAULA FREITAS",
                "PAULO FRONTIN",
                "PEABIRU",
                "PEROBAL",
                "PEROLA",
                "PEROLA D'OESTE",
                "PIEN",
                "PINHAIS",
                "PINHAL DE SAO BENTO",
                "PINHALAO",
                "PINHAO",
                "PIRAI DO SUL",
                "PIRAQUARA",
                "PITANGA",
                "PITANGUEIRAS",
                "PLANALTINA DO PARANA",
                "PLANALTO",
                "PONTA GROSSA",
                "PONTAL DO PARANA",
                "PORECATU",
                "PORTO AMAZONAS",
                "PORTO BARREIRO",
                "PORTO RICO",
                "PORTO VITORIA",
                "PRADO FERREIRA",
                "PRANCHITA",
                "PRESIDENTE CASTELO BRANCO",
                "PRIMEIRO DE MAIO",
                "PRUDENTOPOLIS",
                "QUARTO CENTENARIO",
                "QUATIGUA",
                "QUATRO BARRAS",
                "QUATRO PONTES",
                "QUEDAS DO IGUACU",
                "QUERENCIA DO NORTE",
                "QUINTA DO SOL",
                "QUITANDINHA",
                "RAMILANDIA",
                "RANCHO ALEGRE",
                "RANCHO ALEGRE D'OESTE",
                "REALEZA",
                "REBOUCAS",
                "RENASCENCA",
                "RESERVA",
                "RESERVA DO IGUACU",
                "RIBEIRAO CLARO",
                "RIBEIRAO DO PINHAL",
                "RIO AZUL",
                "RIO BOM",
                "RIO BONITO DO IGUACU",
                "RIO BRANCO DO IVAI",
                "RIO BRANCO DO SUL",
                "RIO NEGRO",
                "ROLANDIA",
                "RONCADOR",
                "RONDON",
                "ROSARIO DO IVAI",
                "SABAUDIA",
                "SALGADO FILHO",
                "SALTO DO ITARARE",
                "SALTO DO LONTRA",
                "SANTA AMELIA",
                "SANTA CECILIA DO PAVAO",
                "SANTA CRUZ MONTE CASTELO",
                "SANTA FE",
                "SANTA HELENA",
                "SANTA INES",
                "SANTA ISABEL DO IVAI",
                "SANTA IZABEL DO OESTE",
                "SANTA LUCIA",
                "SANTA MARIA DO OESTE",
                "SANTA MARIANA",
                "SANTA MONICA",
                "SANTA TEREZA DO OESTE",
                "SANTA TEREZINHA DE ITAIPU",
                "SANTANA DO ITARARE",
                "SANTO ANTONIO DA PLATINA",
                "SANTO ANTONIO DO CAIUA",
                "SANTO ANTONIO DO PARAISO",
                "SANTO ANTONIO DO SUDOESTE",
                "SANTO INACIO",
                "SAO CARLOS DO IVAI",
                "SAO JERONIMO DA SERRA",
                "SAO JOAO",
                "SAO JOAO DO CAIUA",
                "SAO JOAO DO IVAI",
                "SAO JOAO DO TRIUNFO",
                "SAO JORGE D'OESTE",
                "SAO JORGE DO IVAI",
                "SAO JORGE DO PATROCINIO",
                "SAO JOSE DA BOA VISTA",
                "SAO JOSE DAS PALMEIRAS",
                "SAO JOSE DOS PINHAIS",
                "SAO MANOEL DO PARANA",
                "SAO MATEUS DO SUL",
                "SAO MIGUEL DO IGUACU",
                "SAO PEDRO DO IGUACU",
                "SAO PEDRO DO IVAI",
                "SAO PEDRO DO PARANA",
                "SAO SEBASTIAO DA AMOREIRA",
                "SAO TOME",
                "SAPOPEMA",
                "SARANDI",
                "SAUDADE DO IGUACU",
                "SENGES",
                "SERRANOPOLIS DO IGUACU",
                "SERTANEJA",
                "SERTANOPOLIS",
                "SIQUEIRA CAMPOS",
                "SULINA",
                "TAMARANA",
                "TAMBOARA",
                "TAPEJARA",
                "TAPIRA",
                "TEIXEIRA SOARES",
                "TELEMACO BORBA",
                "TERRA BOA",
                "TERRA RICA",
                "TERRA ROXA",
                "TIBAGI",
                "TIJUCAS DO SUL",
                "TOLEDO",
                "TOMAZINA",
                "TRES BARRAS DO PARANA",
                "TUNAS DO PARANA",
                "TUNEIRAS DO OESTE",
                "TUPASSI",
                "TURVO",
                "UBIRATA",
                "UMUARAMA",
                "UNIAO DA VITORIA",
                "UNIFLOR",
                "URAI",
                "VENTANIA",
                "VERA CRUZ DO OESTE",
                "VERE",
                "VILA ALTA",
                "VIRMOND",
                "VITORINO",
                "WENCESLAU BRAZ",
                "XAMBRE"
                //Rio de Janeiro - RJ
                    ,
                "ANGRA DOS REIS",
                "APERIBE",
                "ARARUAMA",
                "AREAL",
                "ARMACAO DE BUZIOS",
                "ARRAIAL DO CABO",
                "BARRA DO PIRAI",
                "BARRA MANSA",
                "BELFORD ROXO",
                "BOM JARDIM",
                "BOM JESUS DO ITABAPOANA",
                "CABO FRIO",
                "CACHOEIRAS DE MACACU",
                "CAMBUCI",
                "CAMPOS DOS GOYTACAZES",
                "CANTAGALO",
                "CARAPEBUS",
                "CARDOSO MOREIRA",
                "CARMO",
                "CASIMIRO DE ABREU",
                "COMENDADOR LEVY GASPARIAN",
                "CONCEICAO DE MACABU",
                "CORDEIRO",
                "DUAS BARRAS",
                "DUQUE DE CAXIAS",
                "ENGENHEIRO PAULO DE FRONTIN",
                "GUAPIMIRIM",
                "IGUABA GRANDE",
                "ITABORAI",
                "ITAGUAI",
                "ITALVA",
                "ITAOCARA",
                "ITAPERUNA",
                "ITATIAIA",
                "JAPERI",
                "LAJE DO MURIAE",
                "MACAE",
                "MACUCO",
                "MAGE",
                "MANGARATIBA",
                "MARICA",
                "MENDES",
                "MESQUITA",
                "MIGUEL PEREIRA",
                "MIRACEMA",
                "NATIVIDADE",
                "NILOPOLIS",
                "NITEROI",
                "NOVA FRIBURGO",
                "NOVA IGUACU",
                "PARACAMBI",
                "PARAIBA DO SUL",
                "PARATI",
                "PATY DO ALFERES",
                "PETROPOLIS",
                "PINHEIRAL",
                "PIRAI",
                "PORCIUNCULA",
                "PORTO REAL",
                "QUATIS",
                "QUEIMADOS",
                "QUISSAMA",
                "RESENDE",
                "RIO BONITO",
                "RIO CLARO",
                "RIO DAS FLORES",
                "RIO DAS OSTRAS",
                "RIO DE JANEIRO",
                "SANTA MARIA MADALENA",
                "SANTO ANTONIO DE PADUA",
                "SAO FIDELIS",
                "SAO FRANCISCO DE ITABAPOANA",
                "SAO GONCALO",
                "SAO JOAO DA BARRA",
                "SAO JOAO DE MERITI",
                "SAO JOSE DE UBA",
                "SAO JOSE DO VALE DO RIO PRETO",
                "SAO PEDRO DA ALDEIA",
                "SAO SEBASTIAO DO ALTO",
                "SAPUCAIA",
                "SAQUAREMA",
                "SEROPEDICA",
                "SILVA JARDIM",
                "SUMIDOURO",
                "TANGUA",
                "TERESOPOLIS",
                "TRAJANO DE MORAIS",
                "TRES RIOS",
                "VALENCA",
                "VARRE-SAI",
                "VASSOURAS",
                "VOLTA REDONDA"
                //Rio Grande do Norte - RN
                    ,
                "ACARI",
                "ACU",
                "AFONSO BEZERRA",
                "AGUA NOVA",
                "ALEXANDRIA",
                "ALMINO AFONSO",
                "ALTO DO RODRIGUES",
                "ANGICOS",
                "ANTONIO MARTINS",
                "APODI",
                "AREIA BRANCA",
                "ARES",
                "AUGUSTO SEVERO",
                "BAIA FORMOSA",
                "BARAUNA",
                "BARCELONA",
                "BENTO FERNANDES",
                "BODO",
                "BOM JESUS",
                "BREJINHO",
                "CAICARA DO NORTE",
                "CAICARA DO RIO DO VENTO",
                "CAICO",
                "CAMPO REDONDO",
                "CANGUARETAMA",
                "CARAUBAS",
                "CARNAUBA DOS DANTAS",
                "CARNAUBAIS",
                "CEARA-MIRIM",
                "CERRO CORA",
                "CORONEL EZEQUIEL",
                "CORONEL JOAO PESSOA",
                "CRUZETA",
                "CURRAIS NOVOS",
                "DOUTOR SEVERIANO",
                "ENCANTO",
                "EQUADOR",
                "ESPIRITO SANTO",
                "EXTREMOZ",
                "FELIPE GUERRA",
                "FERNANDO PEDROZA",
                "FLORANIA",
                "FRANCISCO DANTAS",
                "FRUTUOSO GOMES",
                "GALINHOS",
                "GOIANINHA",
                "GOVERNADOR DIX-SEPT ROSADO",
                "GROSSOS",
                "GUAMARE",
                "IELMO MARINHO",
                "IPANGUACU",
                "IPUEIRA",
                "ITAJA",
                "ITAU",
                "JACANA",
                "JANDAIRA",
                "JANDUIS",
                "JANUARIO CICCO",
                "JAPI",
                "JARDIM DE ANGICOS",
                "JARDIM DE PIRANHAS",
                "JARDIM DO SERIDO",
                "JOAO CAMARA",
                "JOAO DIAS",
                "JOSE DA PENHA",
                "JUCURUTU",
                "JUNDIA",
                "LAGOA D'ANTA",
                "LAGOA DE PEDRAS",
                "LAGOA DE VELHOS",
                "LAGOA NOVA",
                "LAGOA SALGADA",
                "LAJES",
                "LAJES PINTADAS",
                "LUCRECIA",
                "LUIS GOMES",
                "MACAIBA",
                "MACAU",
                "MAJOR SALES",
                "MARCELINO VIEIRA",
                "MARTINS",
                "MAXARANGUAPE",
                "MESSIAS TARGINO",
                "MONTANHAS",
                "MONTE ALEGRE",
                "MONTE DAS GAMELEIRAS",
                "MOSSORO",
                "NATAL",
                "NISIA FLORESTA",
                "NOVA CRUZ",
                "OLHO-D'AGUA DO BORGES",
                "OURO BRANCO",
                "PARANA",
                "PARAU",
                "PARAZINHO",
                "PARELHAS",
                "PARNAMIRIM",
                "PASSA E FICA",
                "PASSAGEM",
                "PATU",
                "PAU DOS FERROS",
                "PEDRA GRANDE",
                "PEDRA PRETA",
                "PEDRO AVELINO",
                "PEDRO VELHO",
                "PENDENCIAS",
                "PILOES",
                "POCO BRANCO",
                "PORTALEGRE",
                "PORTO DO MANGUE",
                "PRESIDENTE JUSCELINO",
                "PUREZA",
                "RAFAEL FERNANDES",
                "RAFAEL GODEIRO",
                "RIACHO DA CRUZ",
                "RIACHO DE SANTANA",
                "RIACHUELO",
                "RIO DO FOGO",
                "RODOLFO FERNANDES",
                "RUY BARBOSA",
                "SANTA CRUZ",
                "SANTA MARIA",
                "SANTANA DO MATOS",
                "SANTANA DO SERIDO",
                "SANTO ANTONIO",
                "SAO BENTO DO NORTE",
                "SAO BENTO DO TRAIRI",
                "SAO FERNANDO",
                "SAO FRANCISCO DO OESTE",
                "SAO GONCALO DO AMARANTE",
                "SAO JOAO DO SABUGI",
                "SAO JOSE DE MIPIBU",
                "SAO JOSE DO CAMPESTRE",
                "SAO JOSE DO SERIDO",
                "SAO MIGUEL",
                "SAO MIGUEL DE TOUROS",
                "SAO PAULO DO POTENGI",
                "SAO PEDRO",
                "SAO RAFAEL",
                "SAO TOME",
                "SAO VICENTE",
                "SENADOR ELOI DE SOUZA",
                "SENADOR GEORGINO AVELINO",
                "SERRA DE SAO BENTO",
                "SERRA DO MEL",
                "SERRA NEGRA DO NORTE",
                "SERRINHA",
                "SERRINHA DOS PINTOS",
                "SEVERIANO MELO",
                "SITIO NOVO",
                "TABOLEIRO GRANDE",
                "TAIPU",
                "TANGARA",
                "TENENTE ANANIAS",
                "TENENTE LAURENTINO CRUZ",
                "TIBAU",
                "TIBAU DO SUL",
                "TIMBAUBA DOS BATISTAS",
                "TOUROS",
                "TRIUNFO POTIGUAR",
                "UMARIZAL",
                "UPANEMA",
                "VARZEA",
                "VENHA-VER",
                "VERA CRUZ",
                "VICOSA",
                "VILA FLOR"
                //Rondônia - RO
                    ,
                "ALTA FLORESTA D'OESTE",
                "ALTO ALEGRE DO PARECIS",
                "ALTO PARAISO",
                "ALVORADA D'OESTE",
                "ARIQUEMES",
                "BURITIS",
                "CABIXI",
                "CACAULANDIA",
                "CACOAL",
                "CAMPO NOVO DE RONDONIA",
                "CANDEIAS DO JAMARI",
                "CASTANHEIRAS",
                "CEREJEIRAS",
                "CHUPINGUAIA",
                "COLORADO DO OESTE",
                "CORUMBIARA",
                "COSTA MARQUES",
                "CUJUBIM",
                "ESPIGAO D'OESTE",
                "GOVERNADOR JORGE TEIXEIRA",
                "GUAJARA-MIRIM",
                "ITAPUA DO OESTE",
                "JARU",
                "JI-PARANA",
                "MACHADINHO D'OESTE",
                "MINISTRO ANDREAZZA",
                "MIRANTE DA SERRA",
                "MONTE NEGRO",
                "NOVA BRASILANDIA D'OESTE",
                "NOVA MAMORE",
                "NOVA UNIAO",
                "NOVO HORIZONTE DO OESTE",
                "OURO PRETO DO OESTE",
                "PARECIS",
                "PIMENTA BUENO",
                "PIMENTEIRAS DO OESTE",
                "PORTO VELHO",
                "PRESIDENTE MEDICI",
                "PRIMAVERA DE RONDONIA",
                "RIO CRESPO",
                "ROLIM DE MOURA",
                "SANTA LUZIA D'OESTE",
                "SAO FELIPE D'OESTE",
                "SAO FRANCISCO DO GUAPORE",
                "SAO MIGUEL DO GUAPORE",
                "SERINGUEIRAS",
                "TEIXEIROPOLIS",
                "THEOBROMA",
                "URUPA",
                "VALE DO ANARI",
                "VALE DO PARAISO",
                "VILHENA"
                //Roraima - RR
                    ,
                "ALTO ALEGRE",
                "AMAJARI",
                "BOA VISTA",
                "BONFIM",
                "CANTA",
                "CARACARAI",
                "CAROEBE",
                "IRACEMA",
                "MUCAJAI",
                "NORMANDIA",
                "PACARAIMA",
                "RORAINOPOLIS",
                "SAO JOAO DA BALIZA",
                "SAO LUIZ",
                "UIRAMUTA"
                //Rio Grande do Sul - RS
                    ,
                "ACEGUA",
                "AGUA SANTA",
                "AGUDO",
                "AJURICABA",
                "ALECRIM",
                "ALEGRETE",
                "ALEGRIA",
                "ALMIRANTE TAMANDARE DO SUL",
                "ALPESTRE",
                "ALTO ALEGRE",
                "ALTO FELIZ",
                "ALVORADA",
                "AMARAL FERRADOR",
                "AMETISTA DO SUL",
                "ANDRE DA ROCHA",
                "ANTA GORDA",
                "ANTONIO PRADO",
                "ARAMBARE",
                "ARARICA",
                "ARATIBA",
                "ARROIO DO MEIO",
                "ARROIO DO PADRE",
                "ARROIO DO SAL",
                "ARROIO DO TIGRE",
                "ARROIO DOS RATOS",
                "ARROIO GRANDE",
                "ARVOREZINHA",
                "AUGUSTO PESTANA",
                "AUREA",
                "BAGE",
                "BALNEARIO PINHAL",
                "BARAO",
                "BARAO DE COTEGIPE",
                "BARAO DO TRIUNFO",
                "BARRA DO GUARITA",
                "BARRA DO QUARAI",
                "BARRA DO RIBEIRO",
                "BARRA DO RIO AZUL",
                "BARRA FUNDA",
                "BARRACAO",
                "BARROS CASSAL",
                "BENJAMIN CONSTAN DO SUL",
                "BENTO GONCALVES",
                "BOA VISTA DAS MISSOES",
                "BOA VISTA DO BURICA",
                "BOA VISTA DO CADEADO",
                "BOA VISTA DO INCRA",
                "BOA VISTA DO SUL",
                "BOM JESUS",
                "BOM PRINCIPIO",
                "BOM PROGRESSO",
                "BOM RETIRO DO SUL",
                "BOQUEIRAO DO LEAO",
                "BOSSOROCA",
                "BOZANO",
                "BRAGA",
                "BROCHIER",
                "BUTIA",
                "CACAPAVA DO SUL",
                "CACEQUI",
                "CACHOEIRA DO SUL",
                "CACHOEIRINHA",
                "CACIQUE DOBLE",
                "CAIBATE",
                "CAICARA",
                "CAMAQUA",
                "CAMARGO",
                "CAMBARA DO SUL",
                "CAMPESTRE DA SERRA",
                "CAMPINA DAS MISSOES",
                "CAMPINAS DO SUL",
                "CAMPO BOM",
                "CAMPO NOVO",
                "CAMPOS BORGES",
                "CANDELARIA",
                "CANDIDO GODOI",
                "CANDIOTA",
                "CANELA",
                "CANGUCU",
                "CANOAS",
                "CANUDOS DO VALE",
                "CAPAO BONITO DO SUL",
                "CAPAO DA CANOA",
                "CAPAO DO CIPO",
                "CAPAO DO LEAO",
                "CAPELA DE SANTANA",
                "CAPITAO",
                "CAPIVARI DO SUL",
                "CARAA",
                "CARAZINHO",
                "CARLOS BARBOSA",
                "CARLOS GOMES",
                "CASCA",
                "CASEIROS",
                "CATUIPE",
                "CAXIAS DO SUL",
                "CENTENARIO",
                "CERRITO",
                "CERRO BRANCO",
                "CERRO GRANDE",
                "CERRO GRANDE DO SUL",
                "CERRO LARGO",
                "CHAPADA",
                "CHARQUEADAS",
                "CHARRUA",
                "CHIAPETA",
                "CHUI",
                "CHUVISCA",
                "CIDREIRA",
                "CIRIACO",
                "COLINAS",
                "COLORADO",
                "CONDOR",
                "CONSTANTINA",
                "COQUEIRO BAIXO",
                "COQUEIROS DO SUL",
                "CORONEL BARROS",
                "CORONEL BICACO",
                "CORONEL PILAR",
                "COTIPORA",
                "COXILHA",
                "CRISSIUMAL",
                "CRISTAL",
                "CRISTAL DO SUL",
                "CRUZ ALTA",
                "CRUZALTENSE",
                "CRUZEIRO DO SUL",
                "DAVID CANABARRO",
                "DERRUBADAS",
                "DEZESSEIS DE NOVEMBRO",
                "DILERMANDO DE AGUIAR",
                "DOIS IRMAOS",
                "DOIS IRMAOS DAS MISSOES",
                "DOIS LAJEADOS",
                "DOM FELICIANO",
                "DOM PEDRITO",
                "DOM PEDRO DE ALCANTARA",
                "DONA FRANCISCA",
                "DOUTOR MAURICIO CARDOSO",
                "DOUTOR RICARDO",
                "ELDORADO DO SUL",
                "ENCANTADO",
                "ENCRUZILHADA DO SUL",
                "ENGENHO VELHO",
                "ENTRE RIOS DO SUL",
                "ENTRE-IJUIS",
                "EREBANGO",
                "ERECHIM",
                "ERNESTINA",
                "ERVAL GRANDE",
                "ERVAL SECO",
                "ESMERALDA",
                "ESPERANCA DO SUL",
                "ESPUMOSO",
                "ESTACAO",
                "ESTANCIA VELHA",
                "ESTEIO",
                "ESTRELA",
                "ESTRELA VELHA",
                "EUGENIO DE CASTRO",
                "FAGUNDES VARELA",
                "FARROUPILHA",
                "FAXINAL DO SOTURNO",
                "FAXINALZINHO",
                "FAZENDA VILANOVA",
                "FELIZ",
                "FLORES DA CUNHA",
                "FLORIANO PEIXOTO",
                "FONTOURA XAVIER",
                "FORMIGUEIRO",
                "FORQUETINHA",
                "FORTALEZA DOS VALOS",
                "FREDERICO WESTPHALEN",
                "GARIBALDI",
                "GARRUCHOS",
                "GAURAMA",
                "GENERAL CAMARA",
                "GENTIL",
                "GETULIO VARGAS",
                "GIRUA",
                "GLORINHA",
                "GRAMADO",
                "GRAMADO DOS LOUREIROS",
                "GRAMADO XAVIER",
                "GRAVATAI",
                "GUABIJU",
                "GUAIBA",
                "GUAPORE",
                "GUARANI DAS MISSOES",
                "HARMONIA",
                "HERVAL",
                "HERVEIRAS",
                "HORIZONTINA",
                "HULHA NEGRA",
                "HUMAITA",
                "IBARAMA",
                "IBIACA",
                "IBIRAIARAS",
                "IBIRAPUITA",
                "IBIRUBA",
                "IGREJINHA",
                "IJUI",
                "ILOPOLIS",
                "IMBE",
                "IMIGRANTE",
                "INDEPENDENCIA",
                "INHACORA",
                "IPE",
                "IPIRANGA DO SUL",
                "IRAI",
                "ITAARA",
                "ITACURUBI",
                "ITAPUCA",
                "ITAQUI",
                "ITATI",
                "ITATIBA DO SUL",
                "IVORA",
                "IVOTI",
                "JABOTICABA",
                "JACUIZINHO",
                "JACUTINGA",
                "JAGUARAO",
                "JAGUARI",
                "JAQUIRANA",
                "JARI",
                "JOIA",
                "JULIO DE CASTILHOS",
                "LAGOA BONITA DO SUL",
                "LAGOA DOS TRES CANTOS",
                "LAGOA VERMELHA",
                "LAGOAO",
                "LAJEADO",
                "LAJEADO DO BUGRE",
                "LAVRAS DO SUL",
                "LIBERATO SALZANO",
                "LINDOLFO COLLOR",
                "LINHA NOVA",
                "MACAMBARA",
                "MACHADINHO",
                "MAMPITUBA",
                "MANOEL VIANA",
                "MAQUINE",
                "MARATA",
                "MARAU",
                "MARCELINO RAMOS",
                "MARIANA PIMENTEL",
                "MARIANO MORO",
                "MARQUES DE SOUZA",
                "MATA",
                "MATO CASTELHANO",
                "MATO LEITAO",
                "MATO QUEIMADO",
                "MAXIMILIANO DE ALMEIDA",
                "MINAS DO LEAO",
                "MIRAGUAI",
                "MONTAURI",
                "MONTE ALEGRE DOS CAMPOS",
                "MONTE BELO DO SUL",
                "MONTENEGRO",
                "MORMACO",
                "MORRINHOS DO SUL",
                "MORRO REDONDO",
                "MORRO REUTER",
                "MOSTARDAS",
                "MUCUM",
                "MUITOS CAPOES",
                "MULITERNO",
                "NAO-ME-TOQUE",
                "NICOLAU VERGUEIRO",
                "NONOAI",
                "NOVA ALVORADA",
                "NOVA ARACA",
                "NOVA BASSANO",
                "NOVA BOA VISTA",
                "NOVA BRESCIA",
                "NOVA CANDELARIA",
                "NOVA ESPERANCA DO SUL",
                "NOVA HARTZ",
                "NOVA PADUA",
                "NOVA PALMA",
                "NOVA PETROPOLIS",
                "NOVA PRATA",
                "NOVA RAMADA",
                "NOVA ROMA DO SUL",
                "NOVA SANTA RITA",
                "NOVO BARREIRO",
                "NOVO CABRAIS",
                "NOVO HAMBURGO",
                "NOVO MACHADO",
                "NOVO TIRADENTES",
                "NOVO XINGU",
                "OSORIO",
                "PAIM FILHO",
                "PALMARES DO SUL",
                "PALMEIRA DAS MISSOES",
                "PALMITINHO",
                "PANAMBI",
                "PANTANO GRANDE",
                "PARAI",
                "PARAISO DO SUL",
                "PARECI NOVO",
                "PAROBE",
                "PASSA SETE",
                "PASSO DO SOBRADO",
                "PASSO FUNDO",
                "PAULO BENTO",
                "PAVERAMA",
                "PEDRAS ALTAS",
                "PEDRO OSORIO",
                "PEJUCARA",
                "PELOTAS",
                "PICADA CAFE",
                "PINHAL",
                "PINHAL DA SERRA",
                "PINHAL GRANDE",
                "PINHEIRINHO DO VALE",
                "PINHEIRO MACHADO",
                "PIRAPO",
                "PIRATINI",
                "PLANALTO",
                "POCO DAS ANTAS",
                "PONTAO",
                "PONTE PRETA",
                "PORTAO",
                "PORTO ALEGRE",
                "PORTO LUCENA",
                "PORTO MAUA",
                "PORTO VERA CRUZ",
                "PORTO XAVIER",
                "POUSO NOVO",
                "PRESIDENTE LUCENA",
                "PROGRESSO",
                "PROTASIO ALVES",
                "PUTINGA",
                "QUARAI",
                "QUATRO IRMAOS",
                "QUEVEDOS",
                "QUINZE DE NOVEMBRO",
                "REDENTORA",
                "RELVADO",
                "RESTINGA SECA",
                "RIO DOS INDIOS",
                "RIO GRANDE",
                "RIO PARDO",
                "RIOZINHO",
                "ROCA SALES",
                "RODEIO BONITO",
                "ROLADOR",
                "ROLANTE",
                "RONDA ALTA",
                "RONDINHA",
                "ROQUE GONZALES",
                "ROSARIO DO SUL",
                "SAGRADA FAMILIA",
                "SALDANHA MARINHO",
                "SALTO DO JACUI",
                "SALVADOR DAS MISSOES",
                "SALVADOR DO SUL",
                "SANANDUVA",
                "SANTA BARBARA DO SUL",
                "SANTA CECILIA DO SUL",
                "SANTA CLARA DO SUL",
                "SANTA CRUZ DO SUL",
                "SANTA MARGARIDA DO SUL",
                "SANTA MARIA",
                "SANTA MARIA DO HERVAL",
                "SANTA ROSA",
                "SANTA TEREZA",
                "SANTA VITORIA DO PALMAR",
                "SANTANA DA BOA VISTA",
                "SANTANA DO LIVRAMENTO",
                "SANTIAGO",
                "SANTO ANGELO",
                "SANTO ANTONIO DA PATRULHA",
                "SANTO ANTONIO DAS MISSOES",
                "SANTO ANTONIO DO PALMA",
                "SANTO ANTONIO DO PLANALTO",
                "SANTO AUGUSTO",
                "SANTO CRISTO",
                "SANTO EXPEDITO DO SUL",
                "SAO BORJA",
                "SAO DOMINGOS DO SUL",
                "SAO FRANCISCO DE ASSIS",
                "SAO FRANCISCO DE PAULA",
                "SAO GABRIEL",
                "SAO JERONIMO",
                "SAO JOAO DA URTIGA",
                "SAO JOAO DO POLESINE",
                "SAO JORGE",
                "SAO JOSE DAS MISSOES",
                "SAO JOSE DO HERVAL",
                "SAO JOSE DO HORTENCIO",
                "SAO JOSE DO INHACORA",
                "SAO JOSE DO NORTE",
                "SAO JOSE DO OURO",
                "SAO JOSE DO SUL",
                "SAO JOSE DOS AUSENTES",
                "SAO LEOPOLDO",
                "SAO LOURENCO DO SUL",
                "SAO LUIZ GONZAGA",
                "SAO MARCOS",
                "SAO MARTINHO",
                "SAO MARTINHO DA SERRA",
                "SAO MIGUEL DAS MISSOES",
                "SAO NICOLAU",
                "SAO PAULO DAS MISSOES",
                "SAO PEDRO DA SERRA",
                "SAO PEDRO DAS MISSOES",
                "SAO PEDRO DO BUTIA",
                "SAO PEDRO DO SUL",
                "SAO SEBASTIAO DO CAI",
                "SAO SEPE",
                "SAO VALENTIM",
                "SAO VALENTIM DO SUL",
                "SAO VALERIO DO SUL",
                "SAO VENDELINO",
                "SAO VICENTE DO SUL",
                "SAPIRANGA",
                "SAPUCAIA DO SUL",
                "SARANDI",
                "SEBERI",
                "SEDE NOVA",
                "SEGREDO",
                "SELBACH",
                "SENADOR SALGADO FILHO",
                "SENTINELA DO SUL",
                "SERAFINA CORREA",
                "SERIO",
                "SERTAO",
                "SERTAO SANTANA",
                "SETE DE SETEMBRO",
                "SEVERIANO DE ALMEIDA",
                "SILVEIRA MARTINS",
                "SINIMBU",
                "SOBRADINHO",
                "SOLEDADE",
                "TABAI",
                "TAPEJARA",
                "TAPERA",
                "TAPES",
                "TAQUARA",
                "TAQUARI",
                "TAQUARUCU DO SUL",
                "TAVARES",
                "TENENTE PORTELA",
                "TERRA DE AREIA",
                "TEUTONIA",
                "TIO HUGO",
                "TIRADENTES DO SUL",
                "TOROPI",
                "TORRES",
                "TRAMANDAI",
                "TRAVESSEIRO",
                "TRES ARROIOS",
                "TRES CACHOEIRAS",
                "TRES COROAS",
                "TRES DE MAIO",
                "TRES FORQUILHAS",
                "TRES PALMEIRAS",
                "TRES PASSOS",
                "TRINDADE DO SUL",
                "TRIUNFO",
                "TUCUNDUVA",
                "TUNAS",
                "TUPANCI DO SUL",
                "TUPANCIRETA",
                "TUPANDI",
                "TUPARENDI",
                "TURUCU",
                "UBIRETAMA",
                "UNIAO DA SERRA",
                "UNISTALDA",
                "URUGUAIANA",
                "VACARIA",
                "VALE DO SOL",
                "VALE REAL",
                "VALE VERDE",
                "VANINI",
                "VENANCIO AIRES",
                "VERA CRUZ",
                "VERANOPOLIS",
                "VESPASIANO CORREA",
                "VIADUTOS",
                "VIAMAO",
                "VICENTE DUTRA",
                "VICTOR GRAEFF",
                "VILA FLORES",
                "VILA LANGARO",
                "VILA MARIA",
                "VILA NOVA DO SUL",
                "VISTA ALEGRE",
                "VISTA ALEGRE DO PRATA",
                "VISTA GAUCHA",
                "VITORIA DAS MISSOES",
                "WESTFALIA",
                "XANGRI-LA"
                //Santa Catarina - SC
                    ,
                "ABDON BATISTA",
                "ABELARDO LUZ",
                "AGROLANDIA",
                "AGRONOMICA",
                "AGUA DOCE",
                "AGUAS DE CHAPECO",
                "AGUAS FRIAS",
                "AGUAS MORNAS",
                "ALFREDO WAGNER",
                "ALTO BELA VISTA",
                "ANCHIETA",
                "ANGELINA",
                "ANITA GARIBALDI",
                "ANITAPOLIS",
                "ANTONIO CARLOS",
                "APIUNA",
                "ARABUTA",
                "ARAQUARI",
                "ARARANGUA",
                "ARMAZEM",
                "ARROIO TRINTA",
                "ARVOREDO",
                "ASCURRA",
                "ATALANTA",
                "AURORA",
                "BALNEARIO ARROIO DO SILVA",
                "BALNEARIO BARRA DO SUL",
                "BALNEARIO CAMBORIU",
                "BALNEARIO GAIVOTA",
                "BANDEIRANTE",
                "BARRA BONITA",
                "BARRA VELHA",
                "BELA VISTA DO TOLDO",
                "BELMONTE",
                "BENEDITO NOVO",
                "BIGUACU",
                "BLUMENAU",
                "BOCAINA DO SUL",
                "BOM JARDIM DA SERRA",
                "BOM JESUS",
                "BOM JESUS DO OESTE",
                "BOM RETIRO",
                "BOMBINHAS",
                "BOTUVERA",
                "BRACO DO NORTE",
                "BRACO DO TROMBUDO",
                "BRUNOPOLIS",
                "BRUSQUE",
                "CACADOR",
                "CAIBI",
                "CALMON",
                "CAMBORIU",
                "CAMPO ALEGRE",
                "CAMPO BELO DO SUL",
                "CAMPO ERE",
                "CAMPOS NOVOS",
                "CANELINHA",
                "CANOINHAS",
                "CAPAO ALTO",
                "CAPINZAL",
                "CAPIVARI DE BAIXO",
                "CATANDUVAS",
                "CAXAMBU DO SUL",
                "CELSO RAMOS",
                "CERRO NEGRO",
                "CHAPADAO DO LAGEADO",
                "CHAPECO",
                "COCAL DO SUL",
                "CONCORDIA",
                "CORDILHEIRA ALTA",
                "CORONEL FREITAS",
                "CORONEL MARTINS",
                "CORREIA PINTO",
                "CORUPA",
                "CRICIUMA",
                "CUNHA PORA",
                "CUNHATAI",
                "CURITIBANOS",
                "DESCANSO",
                "DIONISIO CERQUEIRA",
                "DONA EMMA",
                "DOUTOR PEDRINHO",
                "ENTRE RIOS",
                "ERMO",
                "ERVAL VELHO",
                "FAXINAL DOS GUEDES",
                "FLOR DO SERTAO",
                "FLORIANOPOLIS",
                "FORMOSA DO SUL",
                "FORQUILHINHA",
                "FRAIBURGO",
                "FREI ROGERIO",
                "GALVAO",
                "GAROPABA",
                "GARUVA",
                "GASPAR",
                "GOVERNADOR CELSO RAMOS",
                "GRAO PARA",
                "GRAVATAL",
                "GUABIRUBA",
                "GUARACIABA",
                "GUARAMIRIM",
                "GUARUJA DO SUL",
                "GUATAMBU",
                "HERVAL D'OESTE",
                "IBIAM",
                "IBICARE",
                "IBIRAMA",
                "ICARA",
                "ILHOTA",
                "IMARUI",
                "IMBITUBA",
                "IMBUIA",
                "INDAIAL",
                "IOMERE",
                "IPIRA",
                "IPORA DO OESTE",
                "IPUACU",
                "IPUMIRIM",
                "IRACEMINHA",
                "IRANI",
                "IRATI",
                "IRINEOPOLIS",
                "ITA",
                "ITAIOPOLIS",
                "ITAJAI",
                "ITAPEMA",
                "ITAPIRANGA",
                "ITAPOA",
                "ITUPORANGA",
                "JABORA",
                "JACINTO MACHADO",
                "JAGUARUNA",
                "JARAGUA DO SUL",
                "JARDINOPOLIS",
                "JOACABA",
                "JOINVILLE",
                "JOSE BOITEUX",
                "JUPIA",
                "LACERDOPOLIS",
                "LAGES",
                "LAGUNA",
                "LAJEADO GRANDE",
                "LAURENTINO",
                "LAURO MULLER",
                "LEBON REGIS",
                "LEOBERTO LEAL",
                "LINDOIA DO SUL",
                "LONTRAS",
                "LUIZ ALVES",
                "LUZERNA",
                "MACIEIRA",
                "MAFRA",
                "MAJOR GERCINO",
                "MAJOR VIEIRA",
                "MARACAJA",
                "MARAVILHA",
                "MAREMA",
                "MASSARANDUBA",
                "MATOS COSTA",
                "MELEIRO",
                "MIRIM DOCE",
                "MODELO",
                "MONDAI",
                "MONTE CARLO",
                "MONTE CASTELO",
                "MORRO DA FUMACA",
                "MORRO GRANDE",
                "NAVEGANTES",
                "NOVA ERECHIM",
                "NOVA ITABERABA",
                "NOVA TRENTO",
                "NOVA VENEZA",
                "NOVO HORIZONTE",
                "ORLEANS",
                "OTACILIO COSTA",
                "OURO",
                "OURO VERDE",
                "PAIAL",
                "PAINEL",
                "PALHOCA",
                "PALMA SOLA",
                "PALMEIRA",
                "PALMITOS",
                "PAPANDUVA",
                "PARAISO",
                "PASSO DE TORRES",
                "PASSOS MAIA",
                "PAULO LOPES",
                "PEDRAS GRANDES",
                "PENHA",
                "PERITIBA",
                "PETROLANDIA",
                "PICARRAS",
                "PINHALZINHO",
                "PINHEIRO PRETO",
                "PIRATUBA",
                "PLANALTO ALEGRE",
                "POMERODE",
                "PONTE ALTA",
                "PONTE ALTA DO NORTE",
                "PONTE SERRADA",
                "PORTO BELO",
                "PORTO UNIAO",
                "POUSO REDONDO",
                "PRAIA GRANDE",
                "PRESIDENTE CASTELO BRANCO",
                "PRESIDENTE GETULIO",
                "PRESIDENTE NEREU",
                "PRINCESA",
                "QUILOMBO",
                "RANCHO QUEIMADO",
                "RIO DAS ANTAS",
                "RIO DO CAMPO",
                "RIO DO OESTE",
                "RIO DO SUL",
                "RIO DOS CEDROS",
                "RIO FORTUNA",
                "RIO NEGRINHO",
                "RIO RUFINO",
                "RIQUEZA",
                "RODEIO",
                "ROMELANDIA",
                "SALETE",
                "SALTINHO",
                "SALTO VELOSO",
                "SANGAO",
                "SANTA CECILIA",
                "SANTA HELENA",
                "SANTA ROSA DE LIMA",
                "SANTA ROSA DO SUL",
                "SANTA TEREZINHA",
                "SANTA TEREZINHA DO PROGRESSO",
                "SANTIAGO DO SUL",
                "SANTO AMARO DA IMPERATRIZ",
                "SAO BENTO DO SUL",
                "SAO BERNARDINO",
                "SAO BONIFACIO",
                "SAO CARLOS",
                "SAO CRISTOVAO DO SUL",
                "SAO DOMINGOS",
                "SAO FRANCISCO DO SUL",
                "SAO JOAO BATISTA",
                "SAO JOAO DO ITAPERIU",
                "SAO JOAO DO OESTE",
                "SAO JOAO DO SUL",
                "SAO JOAQUIM",
                "SAO JOSE",
                "SAO JOSE DO CEDRO",
                "SAO JOSE DO CERRITO",
                "SAO LOURENCO DO OESTE",
                "SAO LUDGERO",
                "SAO MARTINHO",
                "SAO MIGUEL DA BOA VISTA",
                "SAO MIGUEL DO OESTE",
                "SAO PEDRO DE ALCANTARA",
                "SAUDADES",
                "SCHROEDER",
                "SEARA",
                "SERRA ALTA",
                "SIDEROPOLIS",
                "SOMBRIO",
                "SUL BRASIL",
                "TAIO",
                "TANGARA",
                "TIGRINHOS",
                "TIJUCAS",
                "TIMBE DO SUL",
                "TIMBO",
                "TIMBO GRANDE",
                "TRES BARRAS",
                "TREVISO",
                "TREZE DE MAIO",
                "TREZE TILIAS",
                "TROMBUDO CENTRAL",
                "TUBARAO",
                "TUNAPOLIS",
                "TURVO",
                "UNIAO DO OESTE",
                "URUBICI",
                "URUPEMA",
                "URUSSANGA",
                "VARGEAO",
                "VARGEM",
                "VARGEM BONITA",
                "VIDAL RAMOS",
                "VIDEIRA",
                "VITOR MEIRELES",
                "WITMARSUM",
                "XANXERE",
                "XAVANTINA",
                "XAXIM",
                "ZORTEA"
                //Sergipe - SE
                    ,
                "AMPARO DE SAO FRANCISCO",
                "AQUIDABA",
                "ARACAJU",
                "ARAUA",
                "AREIA BRANCA",
                "BARRA DOS COQUEIROS",
                "BOQUIM",
                "BREJO GRANDE",
                "CAMPO DO BRITO",
                "CANHOBA",
                "CANINDE DE SAO FRANCISCO",
                "CAPELA",
                "CARIRA",
                "CARMOPOLIS",
                "CEDRO DE SAO JOAO",
                "CRISTINAPOLIS",
                "CUMBE",
                "DIVINA PASTORA",
                "ESTANCIA",
                "FEIRA NOVA",
                "FREI PAULO",
                "GARARU",
                "GENERAL MAYNARD",
                "GRACHO CARDOSO",
                "ILHA DAS FLORES",
                "INDIAROBA",
                "ITABAIANA",
                "ITABAIANINHA",
                "ITABI",
                "ITAPORANGA D'AJUDA",
                "JAPARATUBA",
                "JAPOATA",
                "LAGARTO",
                "LARANJEIRAS",
                "MACAMBIRA",
                "MALHADA DOS BOIS",
                "MALHADOR",
                "MARUIM",
                "MOITA BONITA",
                "MONTE ALEGRE DE SERGIPE",
                "MURIBECA",
                "NEOPOLIS",
                "NOSSA SENHORA APARECIDA",
                "NOSSA SENHORA DA GLORIA",
                "NOSSA SENHORA DAS DORES",
                "NOSSA SENHORA DE LOURDES",
                "NOSSA SENHORA DO SOCORRO",
                "PACATUBA",
                "PEDRA MOLE",
                "PEDRINHAS",
                "PINHAO",
                "PIRAMBU",
                "POCO REDONDO",
                "POCO VERDE",
                "PORTO DA FOLHA",
                "PROPRIA",
                "RIACHAO DO DANTAS",
                "RIACHUELO",
                "RIBEIROPOLIS",
                "ROSARIO DO CATETE",
                "SALGADO",
                "SANTA LUZIA DO ITANHY",
                "SANTA ROSA DE LIMA",
                "SANTANA DO SAO FRANCISCO",
                "SANTO AMARO DAS BROTAS",
                "SAO CRISTOVAO",
                "SAO DOMINGOS",
                "SAO FRANCISCO",
                "SAO MIGUEL DO ALEIXO",
                "SIMAO DIAS",
                "SIRIRI",
                "TELHA",
                "TOBIAS BARRETO",
                "TOMAR DO GERU",
                "UMBAUBA"
                //São Paulo - SP
                    ,
                "ADAMANTINA",
                "ADOLFO",
                "AGUAI",
                "AGUAS DA PRATA",
                "AGUAS DE LINDOIA",
                "AGUAS DE SANTA BARBARA",
                "AGUAS DE SAO PEDRO",
                "AGUDOS",
                "ALAMBARI",
                "ALFREDO MARCONDES",
                "ALTAIR",
                "ALTINOPOLIS",
                "ALTO ALEGRE",
                "ALUMINIO",
                "ALVARES FLORENCE",
                "ALVARES MACHADO",
                "ALVARO DE CARVALHO",
                "ALVINLANDIA",
                "AMERICANA",
                "AMERICO BRASILIENSE",
                "AMERICO DE CAMPOS",
                "AMPARO",
                "ANALANDIA",
                "ANDRADINA",
                "ANGATUBA",
                "ANHEMBI",
                "ANHUMAS",
                "APARECIDA",
                "APARECIDA D'OESTE",
                "APIAI",
                "ARACARIGUAMA",
                "ARACATUBA",
                "ARACOIABA DA SERRA",
                "ARAMINA",
                "ARANDU",
                "ARAPEI",
                "ARARAQUARA",
                "ARARAS",
                "ARCO-IRIS",
                "AREALVA",
                "AREIAS",
                "AREIOPOLIS",
                "ARIRANHA",
                "ARTUR NOGUEIRA",
                "ARUJA",
                "ASPASIA",
                "ASSIS",
                "ATIBAIA",
                "AURIFLAMA",
                "AVAI",
                "AVANHANDAVA",
                "AVARE",
                "BADY BASSITT",
                "BALBINOS",
                "BALSAMO",
                "BANANAL",
                "BARAO DE ANTONINA",
                "BARBOSA",
                "BARIRI",
                "BARRA BONITA",
                "BARRA DO CHAPEU",
                "BARRA DO TURVO",
                "BARRETOS",
                "BARRINHA",
                "BARUERI",
                "BASTOS",
                "BATATAIS",
                "BAURU",
                "BEBEDOURO",
                "BENTO DE ABREU",
                "BERNARDINO DE CAMPOS",
                "BERTIOGA",
                "BILAC",
                "BIRIGUI",
                "BIRITIBA-MIRIM",
                "BOA ESPERANCA DO SUL",
                "BOCAINA",
                "BOFETE",
                "BOITUVA",
                "BOM JESUS DOS PERDOES",
                "BOM SUCESSO DE ITARARE",
                "BORA",
                "BORACEIA",
                "BORBOREMA",
                "BOREBI",
                "BOTUCATU",
                "BRAGANCA PAULISTA",
                "BRAUNA",
                "BREJO ALEGRE",
                "BRODOWSKI",
                "BROTAS",
                "BURI",
                "BURITAMA",
                "BURITIZAL",
                "CABRALIA PAULISTA",
                "CABREUVA",
                "CACAPAVA",
                "CACHOEIRA PAULISTA",
                "CACONDE",
                "CAFELANDIA",
                "CAIABU",
                "CAIEIRAS",
                "CAIUA",
                "CAJAMAR",
                "CAJATI",
                "CAJOBI",
                "CAJURU",
                "CAMPINA DO MONTE ALEGRE",
                "CAMPINAS",
                "CAMPO LIMPO PAULISTA",
                "CAMPOS DO JORDAO",
                "CAMPOS NOVOS PAULISTA",
                "CANANEIA",
                "CANAS",
                "CANDIDO MOTA",
                "CANDIDO RODRIGUES",
                "CANITAR",
                "CAPAO BONITO",
                "CAPELA DO ALTO",
                "CAPIVARI",
                "CARAGUATATUBA",
                "CARAPICUIBA",
                "CARDOSO",
                "CASA BRANCA",
                "CASSIA DOS COQUEIROS",
                "CASTILHO",
                "CATANDUVA",
                "CATIGUA",
                "CEDRAL",
                "CERQUEIRA CESAR",
                "CERQUILHO",
                "CESARIO LANGE",
                "CHARQUEADA",
                "CHAVANTES",
                "CLEMENTINA",
                "COLINA",
                "COLOMBIA",
                "CONCHAL",
                "CONCHAS",
                "CORDEIROPOLIS",
                "COROADOS",
                "CORONEL MACEDO",
                "CORUMBATAI",
                "COSMOPOLIS",
                "COSMORAMA",
                "COTIA",
                "CRAVINHOS",
                "CRISTAIS PAULISTA",
                "CRUZALIA",
                "CRUZEIRO",
                "CUBATAO",
                "CUNHA",
                "DESCALVADO",
                "DIADEMA",
                "DIRCE REIS",
                "DIVINOLANDIA",
                "DOBRADA",
                "DOIS CORREGOS",
                "DOLCINOPOLIS",
                "DOURADO",
                "DRACENA",
                "DUARTINA",
                "DUMONT",
                "ECHAPORA",
                "ELDORADO",
                "ELIAS FAUSTO",
                "ELISIARIO",
                "EMBAUBA",
                "EMBU",
                "EMBU-GUACU",
                "EMILIANOPOLIS",
                "ENGENHEIRO COELHO",
                "ESPIRITO SANTO DO PINHAL",
                "ESPIRITO SANTO DO TURVO",
                "ESTIVA GERBI",
                "ESTRELA D'OESTE",
                "ESTRELA DO NORTE",
                "EUCLIDES DA CUNHA PAULISTA",
                "FARTURA",
                "FERNANDO PRESTES",
                "FERNANDOPOLIS",
                "FERNAO",
                "FERRAZ DE VASCONCELOS",
                "FLORA RICA",
                "FLOREAL",
                "FLORINIA",
                "FLORIDA PAULISTA",
                "FRANCA",
                "FRANCISCO MORATO",
                "FRANCO DA ROCHA",
                "GABRIEL MONTEIRO",
                "GALIA",
                "GARCA",
                "GASTAO VIDIGAL",
                "GAVIAO PEIXOTO",
                "GENERAL SALGADO",
                "GETULINA",
                "GLICERIO",
                "GUAICARA",
                "GUAIMBE",
                "GUAIRA",
                "GUAPIACU",
                "GUAPIARA",
                "GUARA",
                "GUARACAI",
                "GUARACI",
                "GUARANI D'OESTE",
                "GUARANTA",
                "GUARARAPES",
                "GUARAREMA",
                "GUARATINGUETA",
                "GUAREI",
                "GUARIBA",
                "GUARUJA",
                "GUARULHOS",
                "GUATAPARA",
                "GUZOLANDIA",
                "HERCULANDIA",
                "HOLAMBRA",
                "HORTOLANDIA",
                "IACANGA",
                "IACRI",
                "IARAS",
                "IBATE",
                "IBIRA",
                "IBIRAREMA",
                "IBITINGA",
                "IBIUNA",
                "ICEM",
                "IEPE",
                "IGARACU DO TIETE",
                "IGARAPAVA",
                "IGARATA",
                "IGUAPE",
                "ILHA COMPRIDA",
                "ILHA SOLTEIRA",
                "ILHABELA",
                "INDAIATUBA",
                "INDIANA",
                "INDIAPORA",
                "INUBIA PAULISTA",
                "IPAUCU",
                "IPERO",
                "IPEUNA",
                "IPIGUA",
                "IPORANGA",
                "IPUA",
                "IRACEMAPOLIS",
                "IRAPUA",
                "IRAPURU",
                "ITABERA",
                "ITAI",
                "ITAJOBI",
                "ITAJU",
                "ITANHAEM",
                "ITAOCA",
                "ITAPECERICA DA SERRA",
                "ITAPETININGA",
                "ITAPEVA",
                "ITAPEVI",
                "ITAPIRA",
                "ITAPIRAPUA PAULISTA",
                "ITAPOLIS",
                "ITAPORANGA",
                "ITAPUI",
                "ITAPURA",
                "ITAQUAQUECETUBA",
                "ITARARE",
                "ITARIRI",
                "ITATIBA",
                "ITATINGA",
                "ITIRAPINA",
                "ITIRAPUA",
                "ITOBI",
                "ITU",
                "ITUPEVA",
                "ITUVERAVA",
                "JABORANDI",
                "JABOTICABAL",
                "JACAREI",
                "JACI",
                "JACUPIRANGA",
                "JAGUARIUNA",
                "JALES",
                "JAMBEIRO",
                "JANDIRA",
                "JARDINOPOLIS",
                "JARINU",
                "JAU",
                "JERIQUARA",
                "JOANOPOLIS",
                "JOAO RAMALHO",
                "JOSE BONIFACIO",
                "JULIO MESQUITA",
                "JUMIRIM",
                "JUNDIAI",
                "JUNQUEIROPOLIS",
                "JUQUIA",
                "JUQUITIBA",
                "LAGOINHA",
                "LARANJAL PAULISTA",
                "LAVINIA",
                "LAVRINHAS",
                "LEME",
                "LENCOIS PAULISTA",
                "LIMEIRA",
                "LINDOIA",
                "LINS",
                "LORENA",
                "LOURDES",
                "LOUVEIRA",
                "LUCELIA",
                "LUCIANOPOLIS",
                "LUIS ANTONIO",
                "LUIZIANIA",
                "LUPERCIO",
                "LUTECIA",
                "MACATUBA",
                "MACAUBAL",
                "MACEDONIA",
                "MAGDA",
                "MAIRINQUE",
                "MAIRIPORA",
                "MANDURI",
                "MARABA PAULISTA",
                "MARACAI",
                "MARAPOAMA",
                "MARIAPOLIS",
                "MARILIA",
                "MARINOPOLIS",
                "MARTINOPOLIS",
                "MATAO",
                "MAUA",
                "MENDONCA",
                "MERIDIANO",
                "MESOPOLIS",
                "MIGUELOPOLIS",
                "MINEIROS DO TIETE",
                "MIRA ESTRELA",
                "MIRACATU",
                "MIRANDOPOLIS",
                "MIRANTE DO PARANAPANEMA",
                "MIRASSOL",
                "MIRASSOLANDIA",
                "MOCOCA",
                "MOGI DAS CRUZES",
                "MOGI-GUACU",
                "MOGI-MIRIM",
                "MOMBUCA",
                "MONCOES",
                "MONGAGUA",
                "MONTE ALEGRE DO SUL",
                "MONTE ALTO",
                "MONTE APRAZIVEL",
                "MONTE AZUL PAULISTA",
                "MONTE CASTELO",
                "MONTE MOR",
                "MONTEIRO LOBATO",
                "MORRO AGUDO",
                "MORUNGABA",
                "MOTUCA",
                "MURUTINGA DO SUL",
                "NANTES",
                "NARANDIBA",
                "NATIVIDADE DA SERRA",
                "NAZARE PAULISTA",
                "NEVES PAULISTA",
                "NHANDEARA",
                "NIPOA",
                "NOVA ALIANCA",
                "NOVA CAMPINA",
                "NOVA CANAA PAULISTA",
                "NOVA CASTILHO",
                "NOVA EUROPA",
                "NOVA GRANADA",
                "NOVA GUATAPORANGA",
                "NOVA INDEPENDENCIA",
                "NOVA LUZITANIA",
                "NOVA ODESSA",
                "NOVAIS",
                "NOVO HORIZONTE",
                "NUPORANGA",
                "OCAUCU",
                "OLEO",
                "OLIMPIA",
                "ONDA VERDE",
                "ORIENTE",
                "ORINDIUVA",
                "ORLANDIA",
                "OSASCO",
                "OSCAR BRESSANE",
                "OSVALDO CRUZ",
                "OURINHOS",
                "OURO VERDE",
                "OUROESTE",
                "PACAEMBU",
                "PALESTINA",
                "PALMARES PAULISTA",
                "PALMEIRA D'OESTE",
                "PALMITAL",
                "PANORAMA",
                "PARAGUACU PAULISTA",
                "PARAIBUNA",
                "PARAISO",
                "PARANAPANEMA",
                "PARANAPUA",
                "PARAPUA",
                "PARDINHO",
                "PARIQUERA-ACU",
                "PARISI",
                "PATROCINIO PAULISTA",
                "PAULICEIA",
                "PAULINIA",
                "PAULISTANIA",
                "PAULO DE FARIA",
                "PEDERNEIRAS",
                "PEDRA BELA",
                "PEDRANOPOLIS",
                "PEDREGULHO",
                "PEDREIRA",
                "PEDRINHAS PAULISTA",
                "PEDRO DE TOLEDO",
                "PENAPOLIS",
                "PEREIRA BARRETO",
                "PEREIRAS",
                "PERUIBE",
                "PIACATU",
                "PIEDADE",
                "PILAR DO SUL",
                "PINDAMONHANGABA",
                "PINDORAMA",
                "PINHALZINHO",
                "PIQUEROBI",
                "PIQUETE",
                "PIRACAIA",
                "PIRACICABA",
                "PIRAJU",
                "PIRAJUI",
                "PIRANGI",
                "PIRAPORA DO BOM JESUS",
                "PIRAPOZINHO",
                "PIRASSUNUNGA",
                "PIRATININGA",
                "PITANGUEIRAS",
                "PLANALTO",
                "PLATINA",
                "POA",
                "POLONI",
                "POMPEIA",
                "PONGAI",
                "PONTAL",
                "PONTALINDA",
                "PONTES GESTAL",
                "POPULINA",
                "PORANGABA",
                "PORTO FELIZ",
                "PORTO FERREIRA",
                "POTIM",
                "POTIRENDABA",
                "PRACINHA",
                "PRADOPOLIS",
                "PRAIA GRANDE",
                "PRATANIA",
                "PRESIDENTE ALVES",
                "PRESIDENTE BERNARDES",
                "PRESIDENTE EPITACIO",
                "PRESIDENTE PRUDENTE",
                "PRESIDENTE VENCESLAU",
                "PROMISSAO",
                "QUADRA",
                "QUATA",
                "QUEIROZ",
                "QUELUZ",
                "QUINTANA",
                "RAFARD",
                "RANCHARIA",
                "REDENCAO DA SERRA",
                "REGENTE FEIJO",
                "REGINOPOLIS",
                "REGISTRO",
                "RESTINGA",
                "RIBEIRA",
                "RIBEIRAO BONITO",
                "RIBEIRAO BRANCO",
                "RIBEIRAO CORRENTE",
                "RIBEIRAO DO SUL",
                "RIBEIRAO DOS INDIOS",
                "RIBEIRAO GRANDE",
                "RIBEIRAO PIRES",
                "RIBEIRAO PRETO",
                "RIFAINA",
                "RINCAO",
                "RINOPOLIS",
                "RIO CLARO",
                "RIO DAS PEDRAS",
                "RIO GRANDE DA SERRA",
                "RIOLANDIA",
                "RIVERSUL",
                "ROSANA",
                "ROSEIRA",
                "RUBIACEA",
                "RUBINEIA",
                "SABINO",
                "SAGRES",
                "SALES",
                "SALES OLIVEIRA",
                "SALESOPOLIS",
                "SALMOURAO",
                "SALTINHO",
                "SALTO",
                "SALTO DE PIRAPORA",
                "SALTO GRANDE",
                "SANDOVALINA",
                "SANTA ADELIA",
                "SANTA ALBERTINA",
                "SANTA BARBARA D'OESTE",
                "SANTA BRANCA",
                "SANTA CLARA D'OESTE",
                "SANTA CRUZ DA CONCEICAO",
                "SANTA CRUZ DA ESPERANCA",
                "SANTA CRUZ DAS PALMEIRAS",
                "SANTA CRUZ DO RIO PARDO",
                "SANTA ERNESTINA",
                "SANTA FE DO SUL",
                "SANTA GERTRUDES",
                "SANTA ISABEL",
                "SANTA LUCIA",
                "SANTA MARIA DA SERRA",
                "SANTA MERCEDES",
                "SANTA RITA D'OESTE",
                "SANTA RITA DO PASSA QUATRO",
                "SANTA ROSA DE VITERBO",
                "SANTA SALETE",
                "SANTANA DA PONTE PENSA",
                "SANTANA DE PARNAIBA",
                "SANTO ANASTACIO",
                "SANTO ANDRE",
                "SANTO ANTONIO DA ALEGRIA",
                "SANTO ANTONIO DE POSSE",
                "SANTO ANTONIO DO ARACANGUA",
                "SANTO ANTONIO DO JARDIM",
                "SANTO ANTONIO DO PINHAL",
                "SANTO EXPEDITO",
                "SANTOPOLIS DO AGUAPEI",
                "SANTOS",
                "SAO BENTO DO SAPUCAI",
                "SAO BERNARDO DO CAMPO",
                "SAO CAETANO DO SUL",
                "SAO CARLOS",
                "SAO FRANCISCO",
                "SAO JOAO DA BOA VISTA",
                "SAO JOAO DAS DUAS PONTES",
                "SAO JOAO DE IRACEMA",
                "SAO JOAO DO PAU D'ALHO",
                "SAO JOAQUIM DA BARRA",
                "SAO JOSE DA BELA VISTA",
                "SAO JOSE DO BARREIRO",
                "SAO JOSE DO RIO PARDO",
                "SAO JOSE DO RIO PRETO",
                "SAO JOSE DOS CAMPOS",
                "SAO LOURENCO DA SERRA",
                "SAO LUIS DO PARAITINGA",
                "SAO MANUEL",
                "SAO MIGUEL ARCANJO",
                "SAO PAULO",
                "SAO PEDRO",
                "SAO PEDRO DO TURVO",
                "SAO ROQUE",
                "SAO SEBASTIAO",
                "SAO SEBASTIAO DA GRAMA",
                "SAO SIMAO",
                "SAO VICENTE",
                "SARAPUI",
                "SARUTAIA",
                "SEBASTIANOPOLIS DO SUL",
                "SERRA AZUL",
                "SERRA NEGRA",
                "SERRANA",
                "SERTAOZINHO",
                "SETE BARRAS",
                "SEVERINIA",
                "SILVEIRAS",
                "SOCORRO",
                "SOROCABA",
                "SUD MENNUCCI",
                "SUMARE",
                "SUZANAPOLIS",
                "SUZANO",
                "TABAPUA",
                "TABATINGA",
                "TABOAO DA SERRA",
                "TACIBA",
                "TAGUAI",
                "TAIACU",
                "TAIUVA",
                "TAMBAU",
                "TANABI",
                "TAPIRAI",
                "TAPIRATIBA",
                "TAQUARAL",
                "TAQUARITINGA",
                "TAQUARITUBA",
                "TAQUARIVAI",
                "TARABAI",
                "TARUMA",
                "TATUI",
                "TAUBATE",
                "TEJUPA",
                "TEODORO SAMPAIO",
                "TERRA ROXA",
                "TIETE",
                "TIMBURI",
                "TORRE DE PEDRA",
                "TORRINHA",
                "TRABIJU",
                "TREMEMBE",
                "TRES FRONTEIRAS",
                "TUIUTI",
                "TUPA",
                "TUPI PAULISTA",
                "TURIUBA",
                "TURMALINA",
                "UBARANA",
                "UBATUBA",
                "UBIRAJARA",
                "UCHOA",
                "UNIAO PAULISTA",
                "URANIA",
                "URU",
                "URUPES",
                "VALENTIM GENTIL",
                "VALINHOS",
                "VALPARAISO",
                "VARGEM",
                "VARGEM GRANDE DO SUL",
                "VARGEM GRANDE PAULISTA",
                "VARZEA PAULISTA",
                "VERA CRUZ",
                "VINHEDO",
                "VIRADOURO",
                "VISTA ALEGRE DO ALTO",
                "VITORIA BRASIL",
                "VOTORANTIM",
                "VOTUPORANGA",
                "ZACARIAS"
                //Tocantins - TO
                    ,
                "ABREULANDIA",
                "AGUIARNOPOLIS",
                "ALIANCA DO TOCANTINS",
                "ALMAS",
                "ALVORADA",
                "ANANAS",
                "ANGICO",
                "APARECIDA DO RIO NEGRO",
                "ARAGOMINAS",
                "ARAGUACEMA",
                "ARAGUACU",
                "ARAGUAINA",
                "ARAGUANA",
                "ARAGUATINS",
                "ARAPOEMA",
                "ARRAIAS",
                "AUGUSTINOPOLIS",
                "AURORA DO TOCANTINS",
                "AXIXA DO TOCANTINS",
                "BABACULANDIA",
                "BANDEIRANTES DO TOCANTINS",
                "BARRA DO OURO",
                "BARROLANDIA",
                "BERNARDO SAYAO",
                "BOM JESUS DO TOCANTINS",
                "BRASILANDIA DO TOCANTINS",
                "BREJINHO DE NAZARE",
                "BURITI DO TOCANTINS",
                "CACHOEIRINHA",
                "CAMPOS LINDOS",
                "CARIRI DO TOCANTINS",
                "CARMOLANDIA",
                "CARRASCO BONITO",
                "CASEARA",
                "CENTENARIO",
                "CHAPADA DA NATIVIDADE",
                "CHAPADA DE AREIA",
                "COLINAS DO TOCANTINS",
                "COLMEIA",
                "COMBINADO",
                "CONCEICAO DO TOCANTINS",
                "COUTO MAGALHAES",
                "CRISTALANDIA",
                "CRIXAS DO TOCANTINS",
                "DARCINOPOLIS",
                "DIANOPOLIS",
                "DIVINOPOLIS DO TOCANTINS",
                "DOIS IRMAOS DO TOCANTINS",
                "DUERE",
                "ESPERANTINA",
                "FATIMA",
                "FIGUEIROPOLIS",
                "FILADELFIA",
                "FORMOSO DO ARAGUAIA",
                "FORTALEZA DO TABOCAO",
                "GOIANORTE",
                "GOIATINS",
                "GUARAI",
                "GURUPI",
                "IPUEIRAS",
                "ITACAJA",
                "ITAGUATINS",
                "ITAPIRATINS",
                "ITAPORA DO TOCANTINS",
                "JAU DO TOCANTINS",
                "JUARINA",
                "LAGOA DA CONFUSAO",
                "LAGOA DO TOCANTINS",
                "LAJEADO",
                "LAVANDEIRA",
                "LIZARDA",
                "LUZINOPOLIS",
                "MARIANOPOLIS DO TOCANTINS",
                "MATEIROS",
                "MAURILANDIA DO TOCANTINS",
                "MIRACEMA DO TOCANTINS",
                "MIRANORTE",
                "MONTE DO CARMO",
                "MONTE SANTO DO TOCANTINS",
                "MURICILANDIA",
                "NATIVIDADE",
                "NAZARE",
                "NOVA OLINDA",
                "NOVA ROSALANDIA",
                "NOVO ACORDO",
                "NOVO ALEGRE",
                "NOVO JARDIM",
                "OLIVEIRA DE FATIMA",
                "PALMAS",
                "PALMEIRANTE",
                "PALMEIRAS DO TOCANTINS",
                "PALMEIROPOLIS",
                "PARAISO DO TOCANTINS",
                "PARANA",
                "PAU D'ARCO",
                "PEDRO AFONSO",
                "PEIXE",
                "PEQUIZEIRO",
                "PINDORAMA DO TOCANTINS",
                "PIRAQUE",
                "PIUM",
                "PONTE ALTA DO BOM JESUS",
                "PONTE ALTA DO TOCANTINS",
                "PORTO ALEGRE DO TOCANTINS",
                "PORTO NACIONAL",
                "PRAIA NORTE",
                "PRESIDENTE KENNEDY",
                "PUGMIL",
                "RECURSOLANDIA",
                "RIACHINHO",
                "RIO DA CONCEICAO",
                "RIO DOS BOIS",
                "RIO SONO",
                "SAMPAIO",
                "SANDOLANDIA",
                "SANTA FE DO ARAGUAIA",
                "SANTA MARIA DO TOCANTINS",
                "SANTA RITA DO TOCANTINS",
                "SANTA ROSA DO TOCANTINS",
                "SANTA TEREZA DO TOCANTINS",
                "SANTA TEREZINHA DO TOCANTINS",
                "SAO BENTO DO TOCANTINS",
                "SAO FELIX DO TOCANTINS",
                "SAO MIGUEL DO TOCANTINS",
                "SAO SALVADOR DO TOCANTINS",
                "SAO SEBASTIAO DO TOCANTINS",
                "SAO VALERIO",
                "SILVANOPOLIS",
                "SITIO NOVO DO TOCANTINS",
                "SUCUPIRA",
                "TAGUATINGA",
                "TAIPAS DO TOCANTINS",
                "TALISMA",
                "TOCANTINIA",
                "TOCANTINOPOLIS",
                "TUPIRAMA",
                "TUPIRATINS",
                "WANDERLANDIA",
                "XAMBIOA"
            });
            #endregion

            #region Lista de Cidades com Estado
            estadosCidade.Add("AC", new List<string>() { "ACRE", "ACRELANDIA", "ASSIS BRASIL", "BRASILEIA", "BUJARI", "CAPIXABA", "CRUZEIRO DO SUL", "EPITACIOLANDIA", "FEIJO", "JORDAO", "MANCIO LIMA", "MANOEL URBANO", "MARECHAL THAUMATURGO", "PLACIDO DE CASTRO", "PORTO ACRE", "PORTO WALTER", "RIO BRANCO", "RODRIGUES ALVES", "SANTA ROSA DO PURUS", "SENA MADUREIRA", "SENADOR GUIOMARD", "TARAUACA", "XAPURI" });
            estadosCidade.Add("AL", new List<string>() { "ALAGOAS", "AGUA BRANCA", "ANADIA", "ARAPIRACA", "ATALAIA", "BARRA DE SANTO ANTONIO", "BARRA DE SAO MIGUEL", "BATALHA", "BELEM", "BELO MONTE", "BOCA DA MATA", "BRANQUINHA", "CACIMBINHAS", "CAJUEIRO", "CAMPESTRE", "CAMPO ALEGRE", "CAMPO GRANDE", "CANAPI", "CAPELA", "CARNEIROS", "CHA PRETA", "COITE DO NOIA", "COLONIA LEOPOLDINA", "COQUEIRO SECO", "CORURIPE", "CRAIBAS", "DELMIRO GOUVEIA", "DOIS RIACHOS", "ESTRELA DE ALAGOAS", "FEIRA GRANDE", "FELIZ DESERTO", "FLEXEIRAS", "GIRAU DO PONCIANO", "IBATEGUARA", "IGACI", "IGREJA NOVA", "INHAPI", "JACARE DOS HOMENS", "JACUIPE", "JAPARATINGA", "JARAMATAIA", "JEQUIA DA PRAIA", "JOAQUIM GOMES", "JUNDIA", "JUNQUEIRO", "LAGOA DA CANOA", "LIMOEIRO DE ANADIA", "MACEIO", "MAJOR ISIDORO", "MAR VERMELHO", "MARAGOGI", "MARAVILHA", "MARECHAL DEODORO", "MARIBONDO", "MATA GRANDE", "MATRIZ DE CAMARAGIBE", "MESSIAS", "MINADOR DO NEGRAO", "MONTEIROPOLIS", "MURICI", "NOVO LINO", "OLHO D'AGUA DAS FLORES", "OLHO D'AGUA DO CASADO", "OLHO D'AGUA GRANDE", "OLIVENCA", "OURO BRANCO", "PALESTINA", "PALMEIRA DOS INDIOS", "PAO DE ACUCAR", "PARICONHA", "PARIPUEIRA", "PASSO DE CAMARAGIBE", "PAULO JACINTO", "PENEDO", "PIACABUCU", "PILAR", "PINDOBA", "PIRANHAS", "POCO DAS TRINCHEIRAS", "PORTO CALVO", "PORTO DE PEDRAS", "PORTO REAL DO COLEGIO", "QUEBRANGULO", "RIO LARGO", "ROTEIRO", "SANTA LUZIA DO NORTE", "SANTANA DO IPANEMA", "SANTANA DO MUNDAU", "SAO BRAS", "SAO JOSE DA LAJE", "SAO JOSE DA TAPERA", "SAO LUIS DO QUITUNDE", "SAO MIGUEL DOS CAMPOS", "SAO MIGUEL DOS MILAGRES", "SAO SEBASTIAO", "SATUBA", "SENADOR RUI PALMEIRA", "TANQUE D'ARCA", "TAQUARANA", "TEOTONIO VILELA", "TRAIPU", "UNIAO DOS PALMARES", "VICOSA" });
            estadosCidade.Add("AM", new List<string>() { "AMAZONAS", "ALVARAES", "AMATURA", "ANAMA", "ANORI", "APUI", "ATALAIA DO NORTE", "AUTAZES", "BARCELOS", "BARREIRINHA", "BENJAMIN CONSTANT", "BERURI", "BOA VISTA DO RAMOS", "BOCA DO ACRE", "BORBA", "CAAPIRANGA", "CANUTAMA", "CARAUARI", "CAREIRO", "CAREIRO DA VARZEA", "COARI", "CODAJAS", "EIRUNEPE", "ENVIRA", "FONTE BOA", "GUAJARA", "HUMAITA", "IPIXUNA", "IRANDUBA", "ITACOATIARA", "ITAMARATI", "ITAPIRANGA", "JAPURA", "JURUA", "JUTAI", "LABREA", "MANACAPURU", "MANAQUIRI", "MANAUS", "MANICORE", "MARAA", "MAUES", "NHAMUNDA", "NOVA OLINDA DO NORTE", "NOVO AIRAO", "NOVO ARIPUANA", "PARINTINS", "PAUINI", "PRESIDENTE FIGUEIREDO", "RIO PRETO DA EVA", "SANTA ISABEL DO RIO NEGRO", "SANTO ANTONIO DO ICA", "SAO GABRIEL DA CACHOEIRA", "SAO PAULO DE OLIVENCA", "SAO SEBASTIAO DO UATUMA", "SILVES", "TABATINGA", "TAPAUA", "TEFE", "TONANTINS", "UARINI", "URUCARA", "URUCURITUBA" });
            estadosCidade.Add("AP", new List<string>() { "AMAPÁ", "AMAPA", "CALCOENE", "CUTIAS", "FERREIRA GOMES", "ITAUBAL", "LARANJAL DO JARI", "MACAPA", "MAZAGAO", "OIAPOQUE", "PEDRA BRANCA DO AMAPARI", "PORTO GRANDE", "PRACUUBA", "SANTANA", "SERRA DO NAVIO", "TARTARUGALZINHO", "VITORIA DO JARI" });
            estadosCidade.Add("BA", new List<string>() { "BAHIA", "ABAIRA", "ABARE", "ACAJUTIBA", "ADUSTINA", "AGUA FRIA", "AIQUARA", "ALAGOINHAS", "ALCOBACA", "ALMADINA", "AMARGOSA", "AMELIA RODRIGUES", "AMERICA DOURADA", "ANAGE", "ANDARAI", "ANDORINHA", "ANGICAL", "ANGUERA", "ANTAS", "ANTONIO CARDOSO", "ANTONIO GONCALVES", "APORA", "APUAREMA", "ARACAS", "ARACATU", "ARACI", "ARAMARI", "ARATACA", "ARATUIPE", "AURELINO LEAL", "BAIANOPOLIS", "BAIXA GRANDE", "BANZAE", "BARRA", "BARRA DA ESTIVA", "BARRA DO CHOCA", "BARRA DO MENDES", "BARRA DO ROCHA", "BARREIRAS", "BARRO ALTO", "BARROCAS", "BARRO PRETO", "BELMONTE", "BELO CAMPO", "BIRITINGA", "BOA NOVA", "BOA VISTA DO TUPIM", "BOM JESUS DA LAPA", "BOM JESUS DA SERRA", "BONINAL", "BONITO", "BOQUIRA", "BOTUPORA", "BREJOES", "BREJOLANDIA", "BROTAS DE MACAUBAS", "BRUMADO", "BUERAREMA", "BURITIRAMA", "CAATIBA", "CABACEIRAS DO PARAGUACU", "CACHOEIRA", "CACULE", "CAEM", "CAETANOS", "CAETITE", "CAFARNAUM", "CAIRU", "CALDEIRAO GRANDE", "CAMACAN", "CAMACARI", "CAMAMU", "CAMPO ALEGRE DE LOURDES", "CAMPO FORMOSO", "CANAPOLIS", "CANARANA", "CANAVIEIRAS", "CANDEAL", "CANDEIAS", "CANDIBA", "CANDIDO SALES", "CANSANCAO", "CANUDOS", "CAPELA DO ALTO ALEGRE", "CAPIM GROSSO", "CARAIBAS", "CARAVELAS", "CARDEAL DA SILVA", "CARINHANHA", "CASA NOVA", "CASTRO ALVES", "CATOLANDIA", "CATU", "CATURAMA", "CENTRAL", "CHORROCHO", "CICERO DANTAS", "CIPO", "COARACI", "COCOS", "CONCEICAO DA FEIRA", "CONCEICAO DO ALMEIDA", "CONCEICAO DO COITE", "CONCEICAO DO JACUIPE", "CONDE", "CONDEUBA", "CONTENDAS DO SINCORA", "CORACAO DE MARIA", "CORDEIROS", "CORIBE", "CORONEL JOAO SA", "CORRENTINA", "COTEGIPE", "CRAVOLANDIA", "CRISOPOLIS", "CRISTOPOLIS", "CRUZ DAS ALMAS", "CURACA", "DARIO MEIRA", "DIAS D'AVILA", "DOM BASILIO", "DOM MACEDO COSTA", "ELISIO MEDRADO", "ENCRUZILHADA", "ENTRE RIOS", "ERICO CARDOSO", "ESPLANADA", "EUCLIDES DA CUNHA", "EUNAPOLIS", "FATIMA", "FEIRA DA MATA", "FEIRA DE SANTANA", "FILADELFIA", "FIRMINO ALVES", "FLORESTA AZUL", "FORMOSA DO RIO PRETO", "GANDU", "GAVIAO", "GENTIO DO OURO", "GLORIA", "GONGOGI", "GOVERNADOR MANGABEIRA", "GUAJERU", "GUANAMBI", "GUARATINGA", "HELIOPOLIS", "IACU", "IBIASSUCE", "IBICARAI", "IBICOARA", "IBICUI", "IBIPEBA", "IBIPITANGA", "IBIQUERA", "IBIRAPITANGA", "IBIRAPUA", "IBIRATAIA", "IBITIARA", "IBITITA", "IBOTIRAMA", "ICHU", "IGAPORA", "IGRAPIUNA", "IGUAI", "ILHEUS", "INHAMBUPE", "IPECAETA", "IPIAU", "IPIRA", "IPUPIARA", "IRAJUBA", "IRAMAIA", "IRAQUARA", "IRARA", "IRECE", "ITABELA", "ITABERABA", "ITABUNA", "ITACARE", "ITAETE", "ITAGI", "ITAGIBA", "ITAGIMIRIM", "ITAGUACU DA BAHIA", "ITAJU DO COLONIA", "ITAJUIPE", "ITAMARAJU", "ITAMARI", "ITAMBE", "ITANAGRA", "ITANHEM", "ITAPARICA", "ITAPE", "ITAPEBI", "ITAPETINGA", "ITAPICURU", "ITAPITANGA", "ITAQUARA", "ITARANTIM", "ITATIM", "ITIRUCU", "ITIUBA", "ITORORO", "ITUACU", "ITUBERA", "IUIU", "JABORANDI", "JACARACI", "JACOBINA", "JAGUAQUARA", "JAGUARARI", "JAGUARIPE", "JANDAIRA", "JEQUIE", "JEREMOABO", "JIQUIRICA", "JITAUNA", "JOAO DOURADO", "JUAZEIRO", "JUCURUCU", "JUSSARA", "JUSSARI", "JUSSIAPE", "LAFAIETE COUTINHO", "LAGOA REAL", "LAJE", "LAJEDAO", "LAJEDINHO", "LAJEDO DO TABOCAL", "LAMARAO", "LAPAO", "LAURO DE FREITAS", "LENCOIS", "LICINIO DE ALMEIDA", "LIVRAMENTO DE NOSSA SENHORA", "LUIS EDUARDO MAGALHAES", "MACAJUBA", "MACARANI", "MACAUBAS", "MACURURE", "MADRE DE DEUS", "MAETINGA", "MAIQUINIQUE", "MAIRI", "MALHADA", "MALHADA DE PEDRAS", "MANOEL VITORINO", "MANSIDAO", "MARACAS", "MARAGOGIPE", "MARAU", "MARCIONILIO SOUZA", "MASCOTE", "MATA DE SAO JOAO", "MATINA", "MEDEIROS NETO", "MIGUEL CALMON", "MILAGRES", "MIRANGABA", "MIRANTE", "MONTE SANTO", "MORPARA", "MORRO DO CHAPEU", "MORTUGABA", "MUCUGE", "MUCURI", "MULUNGU DO MORRO", "MUNDO NOVO", "MUNIZ FERREIRA", "MUQUEM DE SAO FRANCISCO", "MURITIBA", "MUTUIPE", "NAZARE", "NILO PECANHA", "NORDESTINA", "NOVA CANAA", "NOVA FATIMA", "NOVA IBIA", "NOVA ITARANA", "NOVA REDENCAO", "NOVA SOURE", "NOVA VICOSA", "NOVO HORIZONTE", "NOVO TRIUNFO", "OLINDINA", "OLIVEIRA DOS BREJINHOS", "OURICANGAS", "OUROLANDIA", "PALMAS DE MONTE ALTO", "PALMEIRAS", "PARAMIRIM", "PARATINGA", "PARIPIRANGA", "PAU BRASIL", "PAULO AFONSO", "PE DE SERRA", "PEDRAO", "PEDRO ALEXANDRE", "PIATA", "PILAO ARCADO", "PINDAI", "PINDOBACU", "PINTADAS", "PIRAI DO NORTE", "PIRIPA", "PIRITIBA", "PLANALTINO", "PLANALTO", "POCOES", "POJUCA", "PONTO NOVO", "PORTO SEGURO", "POTIRAGUA", "PRADO", "PRESIDENTE DUTRA", "PRESIDENTE JANIO QUADROS", "PRESIDENTE TANCREDO NEVES", "QUEIMADAS", "QUIJINGUE", "QUIXABEIRA", "RAFAEL JAMBEIRO", "REMANSO", "RETIROLANDIA", "RIACHAO DAS NEVES", "RIACHAO DO JACUIPE", "RIACHO DE SANTANA", "RIBEIRA DO AMPARO", "RIBEIRA DO POMBAL", "RIBEIRAO DO LARGO", "RIO DE CONTAS", "RIO DO ANTONIO", "RIO DO PIRES", "RIO REAL", "RODELAS", "RUY BARBOSA", "SALINAS DA MARGARIDA", "SALVADOR", "SANTA BARBARA", "SANTA BRIGIDA", "SANTA CRUZ CABRALIA", "SANTA CRUZ DA VITORIA", "SANTA INES", "SANTA LUZIA", "SANTA MARIA DA VITORIA", "SANTA RITA DE CASSIA", "SANTA TERESINHA", "SANTALUZ", "SANTANA", "SANTANOPOLIS", "SANTO AMARO", "SANTO ANTONIO DE JESUS", "SANTO ESTEVAO", "SAO DESIDERIO", "SAO DOMINGOS", "SAO FELIPE", "SAO FELIX", "SAO FELIX DO CORIBE", "SAO FRANCISCO DO CONDE", "SAO GABRIEL", "SAO GONCALO DOS CAMPOS", "SAO JOSE DA VITORIA", "SAO JOSE DO JACUIPE", "SAO MIGUEL DAS MATAS", "SAO SEBASTIAO DO PASSE", "SAPEACU", "SATIRO DIAS", "SAUBARA", "SAUDE", "SEABRA", "SEBASTIAO LARANJEIRAS", "SENHOR DO BONFIM", "SENTO SE", "SERRA DO RAMALHO", "SERRA DOURADA", "SERRA PRETA", "SERRINHA", "SERROLANDIA", "SIMOES FILHO", "SITIO DO MATO", "SITIO DO QUINTO", "SOBRADINHO", "SOUTO SOARES", "TABOCAS DO BREJO VELHO", "TANHACU", "TANQUE NOVO", "TANQUINHO", "TAPEROA", "TAPIRAMUTA", "TEIXEIRA DE FREITAS", "TEODORO SAMPAIO", "TEOFILANDIA", "TEOLANDIA", "TERRA NOVA", "TREMEDAL", "TUCANO", "UAUA", "UBAIRA", "UBAITABA", "UBATA", "UIBAI", "UMBURANAS", "UNA", "URANDI", "URUCUCA", "UTINGA", "VALENCA", "VALENTE", "VARZEA DA ROCA", "VARZEA DO POCO", "VARZEA NOVA", "VARZEDO", "VERA CRUZ", "VEREDA", "VITORIA DA CONQUISTA", "WAGNER", "WANDERLEY", "WENCESLAU GUIMARAES", "XIQUE-XIQUE" });
            estadosCidade.Add("CE", new List<string>() { "CEARÁ", "ABAIARA", "ACARAPE", "ACARAU", "ACOPIARA", "AIUABA", "ALCANTARAS", "ALTANEIRA", "ALTO SANTO", "AMONTADA", "ANTONINA DO NORTE", "APUIARES", "AQUIRAZ", "ARACATI", "ARACOIABA", "ARARENDA", "ARARIPE", "ARATUBA", "ARNEIROZ", "ASSARE", "AURORA", "BAIXIO", "BANABUIU", "BARBALHA", "BARREIRA", "BARRO", "BARROQUINHA", "BATURITE", "BEBERIBE", "BELA CRUZ", "BOA VIAGEM", "BREJO SANTO", "CAMOCIM", "CAMPOS SALES", "CANINDE", "CAPISTRANO", "CARIDADE", "CARIRE", "CARIRIACU", "CARIUS", "CARNAUBAL", "CASCAVEL", "CATARINA", "CATUNDA", "CAUCAIA", "CEDRO", "CHAVAL", "CHORO", "CHOROZINHO", "COREAU", "CRATEUS", "CRATO", "CROATA", "CRUZ", "DEPUTADO IRAPUAN PINHEIRO", "ERERE", "EUSEBIO", "FARIAS BRITO", "FORQUILHA", "FORTALEZA", "FORTIM", "FRECHEIRINHA", "GENERAL SAMPAIO", "GRACA", "GRANJA", "GRANJEIRO", "GROAIRAS", "GUAIUBA", "GUARACIABA DO NORTE", "GUARAMIRANGA", "HIDROLANDIA", "HORIZONTE", "IBARETAMA", "IBIAPINA", "IBICUITINGA", "ICAPUI", "ICO", "IGUATU", "INDEPENDENCIA", "IPAPORANGA", "IPAUMIRIM", "IPU", "IPUEIRAS", "IRACEMA", "IRAUCUBA", "ITAICABA", "ITAITINGA", "ITAPAJE", "ITAPIPOCA", "ITAPIUNA", "ITAREMA", "ITATIRA", "JAGUARETAMA", "JAGUARIBARA", "JAGUARIBE", "JAGUARUANA", "JARDIM", "JATI", "JIJOCA DE JERICOAROARA", "JUAZEIRO DO NORTE", "JUCAS", "LAVRAS DA MANGABEIRA", "LIMOEIRO DO NORTE", "MADALENA", "MARACANAU", "MARANGUAPE", "MARCO", "MARTINOPOLE", "MASSAPE", "MAURITI", "MERUOCA", "MILAGRES", "MILHA", "MIRAIMA", "MISSAO VELHA", "MOMBACA", "MONSENHOR TABOSA", "MORADA NOVA", "MORAUJO", "MORRINHOS", "MUCAMBO", "MULUNGU", "NOVA OLINDA", "NOVA RUSSAS", "NOVO ORIENTE", "OCARA", "OROS", "PACAJUS", "PACATUBA", "PACOTI", "PACUJA", "PALHANO", "PALMACIA", "PARACURU", "PARAIPABA", "PARAMBU", "PARAMOTI", "PEDRA BRANCA", "PENAFORTE", "PENTECOSTE", "PEREIRO", "PINDORETAMA", "PIQUET CARNEIRO", "PIRES FERREIRA", "PORANGA", "PORTEIRAS", "POTENGI", "POTIRETAMA", "QUITERIANOPOLIS", "QUIXADA", "QUIXELO", "QUIXERAMOBIM", "QUIXERE", "REDENCAO", "RERIUTABA", "RUSSAS", "SABOEIRO", "SALITRE", "SANTA QUITERIA", "SANTANA DO ACARAU", "SANTANA DO CARIRI", "SAO BENEDITO", "SAO GONCALO DO AMARANTE", "SAO JOAO DO JAGUARIBE", "SAO LUIS DO CURU", "SENADOR POMPEU", "SENADOR SA", "SOBRAL", "SOLONOPOLE", "TABULEIRO DO NORTE", "TAMBORIL", "TARRAFAS", "TAUA", "TEJUCUOCA", "TIANGUA", "TRAIRI", "TURURU", "UBAJARA", "UMARI", "UMIRIM", "URUBURETAMA", "URUOCA", "VARJOTA", "VARZEA ALEGRE", "VICOSA DO CEARA" });
            estadosCidade.Add("DF", new List<string>() { "Distrito Federal", "AGUAS CLARAS", "ARNIQUEIRA", "BRASILIA", "BRAZLANDIA", "CANDANGOLANDIA", "CEILANDIA", "CRUZEIRO", "ESTRUTURAL", "FERCAL", "GAMA", "GUARA", "ITAPOA", "JARDIM BOTANICO", "LAGO NORTE", "LAGO SUL", "NUCLEO BANDEIRANTE", "OCTOGONAL", "PARANOA", "PARK WAY", "PLANALTINA", "PLANO PILOTO", "POR DO SOL", "RECANTO DAS EMAS", "RIACHO FUNDO II", "RIACHO FUNDO", "SAMAMBAIA", "SANTA MARIA", "SAO SEBASTIAO", "SIA", "SOBRADINHO II", "SOBRADINHO", "SOL NASCENTE", "SUDOESTE", "TAGUATINGA", "VARJAO", "VICENTE PIRES" });
            estadosCidade.Add("ES", new List<string>() { "AFONSO CLAUDIO", "AGUA DOCE DO NORTE", "AGUIA BRANCA", "ALEGRE", "ALFREDO CHAVES", "ALTO RIO NOVO", "ANCHIETA", "APIACA", "ARACRUZ", "ATILIO VIVACQUA", "BAIXO GUANDU", "BARRA DE SAO FRANCISCO", "BOA ESPERANCA", "BOM JESUS DO NORTE", "BREJETUBA", "CACHOEIRO DE ITAPEMIRIM", "CARIACICA", "CASTELO", "COLATINA", "CONCEICAO DA BARRA", "CONCEICAO DO CASTELO", "DIVINO DE SAO LOURENCO", "DOMINGOS MARTINS", "DORES DO RIO PRETO", "ECOPORANGA", "FUNDAO", "GOVERNADOR LINDENBERG", "GUACUI", "GUARAPARI", "IBATIBA", "IBIRACU", "IBITIRAMA", "ICONHA", "IRUPI", "ITAGUACU", "ITAPEMIRIM", "ITARANA", "IUNA", "JAGUARE", "JERONIMO MONTEIRO", "JOAO NEIVA", "LARANJA DA TERRA", "LINHARES", "MANTENOPOLIS", "MARATAIZES", "MARECHAL FLORIANO", "MARILANDIA", "MIMOSO DO SUL", "MONTANHA", "MUCURICI", "MUNIZ FREIRE", "MUQUI", "NOVA VENECIA", "PANCAS", "PEDRO CANARIO", "PINHEIROS", "PIUMA", "PONTO BELO", "PRESIDENTE KENNEDY", "RIO BANANAL", "RIO NOVO DO SUL", "SANTA LEOPOLDINA", "SANTA MARIA DE JETIBA", "SANTA TERESA", "SAO DOMINGOS DO NORTE", "SAO GABRIEL DA PALHA", "SAO JOSE DO CALCADO", "SAO MATEUS", "SAO ROQUE DO CANAA", "SERRA", "SOORETAMA", "VARGEM ALTA", "VENDA NOVA DO IMIGRANTE", "VIANA", "VILA PAVAO", "VILA VALERIO", "VILA VELHA", "VITORIA" });
            estadosCidade.Add("GO", new List<string>() { "GOIAS", "ABADIA DE GOIAS", "ABADIANIA", "ACREUNA", "ADELANDIA", "AGUA FRIA DE GOIAS", "AGUA LIMPA", "AGUAS LINDAS DE GOIAS", "ALEXANIA", "ALOANDIA", "ALTO HORIZONTE", "ALTO PARAISO DE GOIAS", "ALVORADA DO NORTE", "AMARALINA", "AMERICANO DO BRASIL", "AMORINOPOLIS", "ANAPOLIS", "ANHANGUERA", "ANICUNS", "APARECIDA DE GOIANIA", "APARECIDA DO RIO DOCE", "APORE", "ARACU", "ARAGARCAS", "ARAGOIANIA", "ARAGUAPAZ", "ARENOPOLIS", "ARUANA", "AURILANDIA", "AVELINOPOLIS", "BALIZA", "BARRO ALTO", "BELA VISTA DE GOIAS", "BOM JARDIM DE GOIAS", "BOM JESUS DE GOIAS", "BONFINOPOLIS", "BONOPOLIS", "BRAZABRANTES", "BRITANIA", "BURITI ALEGRE", "BURITI DE GOIAS", "BURITINOPOLIS", "CABECEIRAS", "CACHOEIRA ALTA", "CACHOEIRA DE GOIAS", "CACHOEIRA DOURADA", "CACU", "CAIAPONIA", "CALDAS NOVAS", "CALDAZINHA", "CAMPESTRE DE GOIAS", "CAMPINACU", "CAMPINORTE", "CAMPO ALEGRE DE GOIAS", "CAMPOS LIMPO DE GOIAS", "CAMPOS BELOS", "CAMPOS VERDES", "CARMO DO RIO VERDE", "CASTELANDIA", "CATALAO", "CATURAI", "CAVALCANTE", "CERES", "CEZARINA", "CHAPADAO DO CEU", "CIDADE OCIDENTAL", "COCALZINHO DE GOIAS", "COLINAS DO SUL", "CORREGO DO OURO", "CORUMBA DE GOIAS", "CORUMBAIBA", "CRISTALINA", "CRISTIANOPOLIS", "CRIXAS", "CROMINIA", "CUMARI", "DAMIANOPOLIS", "DAMOLANDIA", "DAVINOPOLIS", "DIORAMA", "DIVINOPOLIS DE GOIAS", "DOVERLANDIA", "EDEALINA", "EDEIA", "ESTRELA DO NORTE", "FAINA", "FAZENDA NOVA", "FIRMINOPOLIS", "FLORES DE GOIAS", "FORMOSA", "FORMOSO", "GAMELEIRA DE GOIAS", "GOIANAPOLIS", "GOIANDIRA", "GOIANESIA", "GOIANIA", "GOIANIRA", "GOIAS", "GOIATUBA", "GOUVELANDIA", "GUAPO", "GUARAITA", "GUARANI DE GOIAS", "GUARINOS", "HEITORAI", "HIDROLANDIA", "HIDROLINA", "IACIARA", "INACIOLANDIA", "INDIARA", "INHUMAS", "IPAMERI", "IPIRANGA DE GOIAS", "IPORA", "ISRAELANDIA", "ITABERAI", "ITAGUARI", "ITAGUARU", "ITAJA", "ITAPACI", "ITAPIRAPUA", "ITAPURANGA", "ITARUMA", "ITAUCU", "ITUMBIARA", "IVOLANDIA", "JANDAIA", "JARAGUA", "JATAI", "JAUPACI", "JESUPOLIS", "JOVIANIA", "JUSSARA", "LAGOA SANTA", "LEOPOLDO DE BULHOES", "LUZIANIA", "MAIRIPOTABA", "MAMBAI", "MARA ROSA", "MARZAGAO", "MATRINCHA", "MAURILANDIA", "MIMOSO DE GOIAS", "MINACU", "MINEIROS", "MOIPORA", "MONTE ALEGRE DE GOIAS", "MONTES CLAROS DE GOIAS", "MONTIVIDIU", "MONTIVIDIU DO NORTE", "MORRINHOS", "MORRO AGUDO DE GOIAS", "MOSSAMEDES", "MOZARLANDIA", "MUNDO NOVO", "MUTUNOPOLIS", "NAZARIO", "NEROPOLIS", "NIQUELANDIA", "NOVA AMERICA", "NOVA AURORA", "NOVA CRIXAS", "NOVA GLORIA", "NOVA IGUACU DE GOIAS", "NOVA ROMA", "NOVA VENEZA", "NOVO BRASIL", "NOVO GAMA", "NOVO PLANALTO", "ORIZONA", "OURO VERDE DE GOIAS", "OUVIDOR", "PADRE BERNARDO", "PALESTINA DE GOIAS", "PALMEIRAS DE GOIAS", "PALMELO", "PALMINOPOLIS", "PANAMA", "PARANAIGUARA", "PARAUNA", "PEROLANDIA", "PETROLINA DE GOIAS", "PILAR DE GOIAS", "PIRACANJUBA", "PIRANHAS", "PIRENOPOLIS", "PIRES DO RIO", "PLANALTINA", "PONTALINA", "PORANGATU", "PORTEIRAO", "PORTELANDIA", "POSSE", "PROFESSOR JAMIL", "QUIRINOPOLIS", "RIALMA", "RIANAPOLIS", "RIO QUENTE", "RIO VERDE", "RUBIATABA", "SANCLERLANDIA", "SANTA BARBARA DE GOIAS", "SANTA CRUZ DE GOIAS", "SANTA FE DE GOIAS", "SANTA HELENA DE GOIAS", "SANTA ISABEL", "SANTA RITA DO ARAGUAIA", "SANTA RITA DO NOVO DESTINO", "SANTA ROSA DE GOIAS", "SANTA TEREZA DE GOIAS", "SANTA TEREZINHA DE GOIAS", "SANTO ANTONIO DA BARRA", "SANTO ANTONIO DE GOIAS", "SANTO ANTONIO DO DESCOBERTO", "SAO DOMINGOS", "SAO FRANCISCO DE GOIAS", "SAO JOAO D'ALIANCA", "SAO JOAO DA PARAUNA", "SAO LUIS DE MONTES BELOS", "SAO LUIZ DO NORTE", "SAO MIGUEL DO ARAGUAIA", "SAO MIGUEL DO PASSA QUATRO", "SAO PATRICIO", "SAO SIMAO", "SENADOR CANEDO", "SERRANOPOLIS", "SILVANIA", "SIMOLANDIA", "SITIO D'ABADIA", "TAQUARAL DE GOIAS", "TERESINA DE GOIAS", "TEREZOPOLIS DE GOIAS", "TRES RANCHOS", "TRINDADE", "TROMBAS", "TURVANIA", "TURVELANDIA", "UIRAPURU", "URUACU", "URUANA", "URUTAI", "VALPARAISO DE GOIAS", "VARJAO", "VIANOPOLIS", "VICENTINOPOLIS", "VILA BOA", "VILA PROPICIO" });
            estadosCidade.Add("MA", new List<string>() { "MARANHAO", "ACAILANDIA", "AFONSO CUNHA", "AGUA DOCE DO MARANHAO", "ALCANTARA", "ALDEIAS ALTAS", "ALTAMIRA DO MARANHAO", "ALTO ALEGRE DO MARANHAO", "ALTO ALEGRE DO PINDARE", "ALTO PARNAIBA", "AMAPA DO MARANHAO", "AMARANTE DO MARANHAO", "ANAJATUBA", "ANAPURUS", "APICUM-ACU", "ARAGUANA", "ARAIOSES", "ARAME", "ARARI", "AXIXA", "BACABAL", "BACABEIRA", "BACURI", "BACURITUBA", "BALSAS", "BARAO DE GRAJAU", "BARRA DO CORDA", "BARREIRINHAS", "BELA VISTA DO MARANHAO", "BELAGUA", "BENEDITO LEITE", "BEQUIMAO", "BERNARDO DO MEARIM", "BOA VISTA DO GURUPI", "BOM JARDIM", "BOM JESUS DAS SELVAS", "BOM LUGAR", "BREJO", "BREJO DE AREIA", "BURITI", "BURITI BRAVO", "BURITICUPU", "BURITIRANA", "CACHOEIRA GRANDE", "CAJAPIO", "CAJARI", "CAMPESTRE DO MARANHAO", "CANDIDO MENDES", "CANTANHEDE", "CAPINZAL DO NORTE", "CAROLINA", "CARUTAPERA", "CAXIAS", "CEDRAL", "CENTRAL DO MARANHAO", "CENTRO DO GUILHERME", "CENTRO NOVO DO MARANHAO", "CHAPADINHA", "CIDELANDIA", "CODO", "COELHO NETO", "COLINAS", "CONCEICAO DO LAGO-ACU", "COROATA", "CURURUPU", "DAVINOPOLIS", "DOM PEDRO", "DUQUE BACELAR", "ESPERANTINOPOLIS", "ESTREITO", "FEIRA NOVA DO MARANHAO", "FERNANDO FALCAO", "FORMOSA DA SERRA NEGRA", "FORTALEZA DOS NOGUEIRAS", "FORTUNA", "GODOFREDO VIANA", "GONCALVES DIAS", "GOVERNADOR ARCHER", "GOVERNADOR EDISON LOBAO", "GOVERNADOR EUGENIO BARROS", "GOVERNADOR LUIZ ROCHA", "GOVERNADOR NEWTON BELLO", "GOVERNADOR NUNES FREIRE", "GRACA ARANHA", "GRAJAU", "GUIMARAES", "HUMBERTO DE CAMPOS", "ICATU", "IGARAPE DO MEIO", "IGARAPE GRANDE", "IMPERATRIZ", "ITAIPAVA DO GRAJAU", "ITAPECURU MIRIM", "ITINGA DO MARANHAO", "JATOBA", "JENIPAPO DOS VIEIRAS", "JOAO LISBOA", "JOSELANDIA", "JUNCO DO MARANHAO", "LAGO DA PEDRA", "LAGO DO JUNCO", "LAGO DOS RODRIGUES", "LAGO VERDE", "LAGOA DO MATO", "LAGOA GRANDE DO MARANHAO", "LAJEADO NOVO", "LIMA CAMPOS", "LORETO", "LUIS DOMINGUES", "MAGALHAES DE ALMEIDA", "MARACACUME", "MARAJA DO SENA", "MARANHAOZINHO", "MATA ROMA", "MATINHA", "MATOES", "MATOES DO NORTE", "MILAGRES DO MARANHAO", "MIRADOR", "MIRANDA DO NORTE", "MIRINZAL", "MONCAO", "MONTES ALTOS", "MORROS", "NINA RODRIGUES", "NOVA COLINAS", "NOVA IORQUE", "NOVA OLINDA DO MARANHAO", "OLHO D'AGUA DAS CUNHAS", "OLINDA NOVA DO MARANHAO", "PACO DO LUMIAR", "PALMEIRANDIA", "PARAIBANO", "PARNARAMA", "PASSAGEM FRANCA", "PASTOS BONS", "PAULINO NEVES", "PAULO RAMOS", "PEDREIRAS", "PEDRO DO ROSARIO", "PENALVA", "PERI MIRIM", "PERITORO", "PINDARE MIRIM", "PINHEIRO", "PIO XII", "PIRAPEMAS", "POCAO DE PEDRAS", "PORTO FRANCO", "PORTO RICO DO MARANHAO", "PRESIDENTE DUTRA", "PRESIDENTE JUSCELINO", "PRESIDENTE MEDICI", "PRESIDENTE SARNEY", "PRESIDENTE VARGAS", "PRIMEIRA CRUZ", "RAPOSA", "RIACHAO", "RIBAMAR FIQUENE", "ROSARIO", "SAMBAIBA", "SANTA FILOMENA DO MARANHAO", "SANTA HELENA", "SANTA INES", "SANTA LUZIA", "SANTA LUZIA DO PARUA", "SANTA QUITERIA DO MARANHAO", "SANTA RITA", "SANTANA DO MARANHAO", "SANTO AMARO DO MARANHAO", "SANTO ANTONIO DOS LOPES", "SAO BENEDITO DO RIO PRETO", "SAO BENTO", "SAO BERNARDO", "SAO DOMINGOS DO AZEITAO", "SAO DOMINGOS DO MARANHAO", "SAO FELIX DE BALSAS", "SAO FRANCISCO DO BREJAO", "SAO FRANCISCO DO MARANHAO", "SAO JOAO BATISTA", "SAO JOAO DO CARU", "SAO JOAO DO PARAISO", "SAO JOAO DO SOTER", "SAO JOAO DOS PATOS", "SAO JOSE DE RIBAMAR", "SAO JOSE DOS BASILIOS", "SAO LUIS", "SAO LUIS GONZAGA DO MARANHAO", "SAO MATEUS DO MARANHAO", "SAO PEDRO DA AGUA BRANCA", "SAO PEDRO DOS CRENTES", "SAO RAIMUNDO DAS MANGABEIRAS", "SAO RAIMUNDO DO DOCA BEZERRA", "SAO ROBERTO", "SAO VICENTE FERRER", "SATUBINHA", "SENADOR ALEXANDRE COSTA", "SENADOR LA ROCQUE", "SERRANO DO MARANHAO", "SITIO NOVO", "SUCUPIRA DO NORTE", "SUCUPIRA DO RIACHAO", "TASSO FRAGOSO", "TIMBIRAS", "TIMON", "TRIZIDELA DO VALE", "TUFILANDIA", "TUNTUM", "TURIACU", "TURILANDIA", "TUTOIA", "URBANO SANTOS", "VARGEM GRANDE", "VIANA", "VILA NOVA DOS MARTIRIOS", "VITORIA DO MEARIM", "VITORINO FREIRE", "ZE DOCA" });
            estadosCidade.Add("MG", new List<string>() { "MINAS GERAIS", "ABADIA DOS DOURADOS", "ABAETE", "ABRE CAMPO", "ACAIACA", "ACUCENA", "AGUA BOA", "AGUA COMPRIDA", "AGUANIL", "AGUAS FORMOSAS", "AGUAS VERMELHAS", "AIMORES", "AIURUOCA", "ALAGOA", "ALBERTINA", "ALEM PARAIBA", "ALFENAS", "ALFREDO VASCONCELOS", "ALMENARA", "ALPERCATA", "ALPINOPOLIS", "ALTEROSA", "ALTO CAPARAO", "ALTO JEQUITIBA", "ALTO RIO DOCE", "ALVARENGA", "ALVINOPOLIS", "ALVORADA DE MINAS", "AMPARO DO SERRA", "ANDRADAS", "ANDRELANDIA", "ANGELANDIA", "ANTONIO CARLOS", "ANTONIO DIAS", "ANTONIO PRADO DE MINAS", "ARACAI", "ARACITABA", "ARACUAI", "ARAGUARI", "ARANTINA", "ARAPONGA", "ARAPORA", "ARAPUA", "ARAUJOS", "ARAXA", "ARCEBURGO", "ARCOS", "AREADO", "ARGIRITA", "ARICANDUVA", "ARINOS", "ASTOLFO DUTRA", "ATALEIA", "AUGUSTO DE LIMA", "BAEPENDI", "BALDIM", "BAMBUI", "BANDEIRA", "BANDEIRA DO SUL", "BARAO DE COCAIS", "BARAO DE MONTE ALTO", "BARBACENA", "BARRA LONGA", "BARROSO", "BELA VISTA DE MINAS", "BELMIRO BRAGA", "BELO HORIZONTE", "BELO ORIENTE", "BELO VALE", "BERILO", "BERIZAL", "BERTOPOLIS", "BETIM", "BIAS FORTES", "BICAS", "BIQUINHAS", "BOA ESPERANCA", "BOCAINA DE MINAS", "BOCAIUVA", "BOM DESPACHO", "BOM JARDIM DE MINAS", "BOM JESUS DA PENHA", "BOM JESUS DO AMPARO", "BOM JESUS DO GALHO", "BOM REPOUSO", "BOM SUCESSO", "BONFIM", "BONFINOPOLIS DE MINAS", "BONITO DE MINAS", "BORDA DA MATA", "BOTELHOS", "BOTUMIRIM", "BRAS PIRES", "BRASILANDIA DE MINAS", "BRASILIA DE MINAS", "BRASOPOLIS", "BRAUNAS", "BRUMADINHO", "BUENO BRANDAO", "BUENOPOLIS", "BUGRE", "BURITIS", "BURITIZEIRO", "CABECEIRA GRANDE", "CABO VERDE", "CACHOEIRA DA PRATA", "CACHOEIRA DE MINAS", "CACHOEIRA DE PAJEU", "CACHOEIRA DOURADA", "CAETANOPOLIS", "CAETE", "CAIANA", "CAJURI", "CALDAS", "CAMACHO", "CAMANDUCAIA", "CAMBUI", "CAMBUQUIRA", "CAMPANARIO", "CAMPANHA", "CAMPESTRE", "CAMPINA VERDE", "CAMPO AZUL", "CAMPO BELO", "CAMPO DO MEIO", "CAMPO FLORIDO", "CAMPOS ALTOS", "CAMPOS GERAIS", "CANA VERDE", "CANAA", "CANAPOLIS", "CANDEIAS", "CANTAGALO", "CAPARAO", "CAPELA NOVA", "CAPELINHA", "CAPETINGA", "CAPIM BRANCO", "CAPINOPOLIS", "CAPITAO ANDRADE", "CAPITAO ENEAS", "CAPITOLIO", "CAPUTIRA", "CARAI", "CARANAIBA", "CARANDAI", "CARANGOLA", "CARATINGA", "CARBONITA", "CAREACU", "CARLOS CHAGAS", "CARMESIA", "CARMO DA CACHOEIRA", "CARMO DA MATA", "CARMO DE MINAS", "CARMO DO CAJURU", "CARMO DO PARANAIBA", "CARMO DO RIO CLARO", "CARMOPOLIS DE MINAS", "CARNEIRINHO", "CARRANCAS", "CARVALHOPOLIS", "CARVALHOS", "CASA GRANDE", "CASCALHO RICO", "CASSIA", "CATAGUASES", "CATAS ALTAS", "CATAS ALTAS DA NORUEGA", "CATUJI", "CATUTI", "CAXAMBU", "CEDRO DO ABAETE", "CENTRAL DE MINAS", "CENTRALINA", "CHACARA", "CHALE", "CHAPADA DO NORTE", "CHAPADA GAUCHA", "CHIADOR", "CIPOTANEA", "CLARAVAL", "CLARO DOS POCOES", "CLAUDIO", "COIMBRA", "COLUNA", "COMENDADOR GOMES", "COMERCINHO", "CONCEICAO DA APARECIDA", "CONCEICAO DA BARRA DE MINAS", "CONCEICAO DAS ALAGOAS", "CONCEICAO DAS PEDRAS", "CONCEICAO DE IPANEMA", "CONCEICAO DO MATO DENTRO", "CONCEICAO DO PARA", "CONCEICAO DO RIO VERDE", "CONCEICAO DOS OUROS", "CONEGO MARINHO", "CONFINS", "CONGONHAL", "CONGONHAS", "CONGONHAS DO NORTE", "CONQUISTA", "CONSELHEIRO LAFAIETE", "CONSELHEIRO PENA", "CONSOLACAO", "CONTAGEM", "COQUEIRAL", "CORACAO DE JESUS", "CORDISBURGO", "CORDISLANDIA", "CORINTO", "COROACI", "COROMANDEL", "CORONEL FABRICIANO", "CORONEL MURTA", "CORONEL PACHECO", "CORONEL XAVIER CHAVES", "CORREGO DANTA", "CORREGO DO BOM JESUS", "CORREGO FUNDO", "CORREGO NOVO", "COUTO DE MAGALHAES DE MINAS", "CRISOLITA", "CRISTAIS", "CRISTALIA", "CRISTIANO OTONI", "CRISTINA", "CRUCILANDIA", "CRUZEIRO DA FORTALEZA", "CRUZILIA", "CUPARAQUE", "CURRAL DE DENTRO", "CURVELO", "DATAS", "DELFIM MOREIRA", "DELFINOPOLIS", "DELTA", "DESCOBERTO", "DESTERRO DE ENTRE RIOS", "DESTERRO DO MELO", "DIAMANTINA", "DIOGO DE VASCONCELOS", "DIONISIO", "DIVINESIA", "DIVINO", "DIVINO DAS LARANJEIRAS", "DIVINOLANDIA DE MINAS", "DIVINOPOLIS", "DIVISA ALEGRE", "DIVISA NOVA", "DIVISOPOLIS", "DOM BOSCO", "DOM CAVATI", "DOM JOAQUIM", "DOM SILVERIO", "DOM VICOSO", "DONA EUZEBIA", "DORES DE CAMPOS", "DORES DE GUANHAES", "DORES DO INDAIA", "DORES DO TURVO", "DORESOPOLIS", "DOURADOQUARA", "DURANDE", "ELOI MENDES", "ENGENHEIRO CALDAS", "ENGENHEIRO NAVARRO", "ENTRE FOLHAS", "ENTRE RIOS DE MINAS", "ERVALIA", "ESMERALDAS", "ESPERA FELIZ", "ESPINOSA", "ESPIRITO SANTO DO DOURADO", "ESTIVA", "ESTRELA DALVA", "ESTRELA DO INDAIA", "ESTRELA DO SUL", "EUGENOPOLIS", "EWBANK DA CAMARA", "EXTREMA", "FAMA", "FARIA LEMOS", "FELICIO DOS SANTOS", "FELISBURGO", "FELIXLANDIA", "FERNANDES TOURINHO", "FERROS", "FERVEDOURO", "FLORESTAL", "FORMIGA", "FORMOSO", "FORTALEZA DE MINAS", "FORTUNA DE MINAS", "FRANCISCO BADARO", "FRANCISCO DUMONT", "FRANCISCO SA", "FRANCISCOPOLIS", "FREI GASPAR", "FREI INOCENCIO", "FREI LAGONEGRO", "FRONTEIRA", "FRONTEIRA DOS VALES", "FRUTA DE LEITE", "FRUTAL", "FUNILANDIA", "GALILEIA", "GAMELEIRAS", "GLAUCILANDIA", "GOIABEIRA", "GOIANA", "GONCALVES", "GONZAGA", "GOUVEIA", "GOVERNADOR VALADARES", "GRAO MOGOL", "GRUPIARA", "GUANHAES", "GUAPE", "GUARACIABA", "GUARACIAMA", "GUARANESIA", "GUARANI", "GUARARA", "GUARDA-MOR", "GUAXUPE", "GUIDOVAL", "GUIMARANIA", "GUIRICEMA", "GURINHATA", "HELIODORA", "IAPU", "IBERTIOGA", "IBIA", "IBIAI", "IBIRACATU", "IBIRACI", "IBIRITE", "IBITIURA DE MINAS", "IBITURUNA", "ICARAI DE MINAS", "IGARAPE", "IGARATINGA", "IGUATAMA", "IJACI", "ILICINEA", "IMBE DE MINAS", "INCONFIDENTES", "INDAIABIRA", "INDIANOPOLIS", "INGAI", "INHAPIM", "INHAUMA", "INIMUTABA", "IPABA", "IPANEMA", "IPATINGA", "IPIACU", "IPUIUNA", "IRAI DE MINAS", "ITABIRA", "ITABIRINHA DE MANTENA", "ITABIRITO", "ITACAMBIRA", "ITACARAMBI", "ITAGUARA", "ITAIPE", "ITAJUBA", "ITAMARANDIBA", "ITAMARATI DE MINAS", "ITAMBACURI", "ITAMBE DO MATO DENTRO", "ITAMOGI", "ITAMONTE", "ITANHANDU", "ITANHOMI", "ITAOBIM", "ITAPAGIPE", "ITAPECERICA", "ITAPEVA", "ITATIAIUCU", "ITAU DE MINAS", "ITAUNA", "ITAVERAVA", "ITINGA", "ITUETA", "ITUIUTABA", "ITUMIRIM", "ITURAMA", "ITUTINGA", "JABOTICATUBAS", "JACINTO", "JACUI", "JACUTINGA", "JAGUARACU", "JAIBA", "JAMPRUCA", "JANAUBA", "JANUARIA", "JAPARAIBA", "JAPONVAR", "JECEABA", "JENIPAPO DE MINAS", "JEQUERI", "JEQUITAI", "JEQUITIBA", "JEQUITINHONHA", "JESUANIA", "JOAIMA", "JOANESIA", "JOAO MONLEVADE", "JOAO PINHEIRO", "JOAQUIM FELICIO", "JORDANIA", "JOSE GONCALVES DE MINAS", "JOSE RAYDAN", "JOSENOPOLIS", "JUATUBA", "JUIZ DE FORA", "JURAMENTO", "JURUAIA", "JUVENILIA", "LADAINHA", "LAGAMAR", "LAGOA DA PRATA", "LAGOA DOS PATOS", "LAGOA DOURADA", "LAGOA FORMOSA", "LAGOA GRANDE", "LAGOA SANTA", "LAJINHA", "LAMBARI", "LAMIM", "LARANJAL", "LASSANCE", "LAVRAS", "LEANDRO FERREIRA", "LEME DO PRADO", "LEOPOLDINA", "LIBERDADE", "LIMA DUARTE", "LIMEIRA DO OESTE", "LONTRA", "LUISBURGO", "LUISLANDIA", "LUMINARIAS", "LUZ", "MACHACALIS", "MACHADO", "MADRE DE DEUS DE MINAS", "MALACACHETA", "MAMONAS", "MANGA", "MANHUACU", "MANHUMIRIM", "MANTENA", "MAR DE ESPANHA", "MARAVILHAS", "MARIA DA FE", "MARIANA", "MARILAC", "MARIO CAMPOS", "MARIPA DE MINAS", "MARLIERIA", "MARMELOPOLIS", "MARTINHO CAMPOS", "MARTINS SOARES", "MATA VERDE", "MATERLANDIA", "MATEUS LEME", "MATHIAS LOBATO", "MATIAS BARBOSA", "MATIAS CARDOSO", "MATIPO", "MATO VERDE", "MATOZINHOS", "MATUTINA", "MEDEIROS", "MEDINA", "MENDES PIMENTEL", "MERCES", "MESQUITA", "MINAS NOVAS", "MINDURI", "MIRABELA", "MIRADOURO", "MIRAI", "MIRAVANIA", "MOEDA", "MOEMA", "MONJOLOS", "MONSENHOR PAULO", "MONTALVANIA", "MONTE ALEGRE DE MINAS", "MONTE AZUL", "MONTE BELO", "MONTE CARMELO", "MONTE FORMOSO", "MONTE SANTO DE MINAS", "MONTE SIAO", "MONTES CLAROS", "MONTEZUMA", "MORADA NOVA DE MINAS", "MORRO DA GARCA", "MORRO DO PILAR", "MUNHOZ", "MURIAE", "MUTUM", "MUZAMBINHO", "NACIP RAYDAN", "NANUQUE", "NAQUE", "NATALANDIA", "NATERCIA", "NAZARENO", "NEPOMUCENO", "NINHEIRA", "NOVA BELEM", "NOVA ERA", "NOVA LIMA", "NOVA MODICA", "NOVA PONTE", "NOVA PORTEIRINHA", "NOVA RESENDE", "NOVA SERRANA", "NOVA UNIAO", "NOVO CRUZEIRO", "NOVO ORIENTE DE MINAS", "NOVORIZONTE", "OLARIA", "OLHOS-D'AGUA", "OLIMPIO NORONHA", "OLIVEIRA", "OLIVEIRA FORTES", "ONCA DE PITANGUI", "ORATORIOS", "ORIZANIA", "OURO BRANCO", "OURO FINO", "OURO PRETO", "OURO VERDE DE MINAS", "PADRE CARVALHO", "PADRE PARAISO", "PAI PEDRO", "PAINEIRAS", "PAINS", "PAIVA", "PALMA", "PALMOPOLIS", "PAPAGAIOS", "PARA DE MINAS", "PARACATU", "PARAGUACU", "PARAISOPOLIS", "PARAOPEBA", "PASSA QUATRO", "PASSA TEMPO", "PASSA-VINTE", "PASSABEM", "PASSOS", "PATIS", "PATOS DE MINAS", "PATROCINIO", "PATROCINIO DO MURIAE", "PAULA CANDIDO", "PAULISTAS", "PAVAO", "PECANHA", "PEDRA AZUL", "PEDRA BONITA", "PEDRA DO ANTA", "PEDRA DO INDAIA", "PEDRA DOURADA", "PEDRALVA", "PEDRAS DE MARIA DA CRUZ", "PEDRINOPOLIS", "PEDRO LEOPOLDO", "PEDRO TEIXEIRA", "PEQUERI", "PEQUI", "PERDIGAO", "PERDIZES", "PERDOES", "PERIQUITO", "PESCADOR", "PIAU", "PIEDADE DE CARATINGA", "PIEDADE DE PONTE NOVA", "PIEDADE DO RIO GRANDE", "PIEDADE DOS GERAIS", "PIMENTA", "PINGO-D'AGUA", "PINTOPOLIS", "PIRACEMA", "PIRAJUBA", "PIRANGA", "PIRANGUCU", "PIRANGUINHO", "PIRAPETINGA", "PIRAPORA", "PIRAUBA", "PITANGUI", "PIUMHI", "PLANURA", "POCO FUNDO", "POCOS DE CALDAS", "POCRANE", "POMPEU", "PONTE NOVA", "PONTO CHIQUE", "PONTO DOS VOLANTES", "PORTEIRINHA", "PORTO FIRME", "POTE", "POUSO ALEGRE", "POUSO ALTO", "PRADOS", "PRATA", "PRATAPOLIS", "PRATINHA", "PRESIDENTE BERNARDES", "PRESIDENTE JUSCELINO", "PRESIDENTE KUBITSCHEK", "PRESIDENTE OLEGARIO", "PRUDENTE DE MORAIS", "QUARTEL GERAL", "QUELUZITO", "RAPOSOS", "RAUL SOARES", "RECREIO", "REDUTO", "RESENDE COSTA", "RESPLENDOR", "RESSAQUINHA", "RIACHINHO", "RIACHO DOS MACHADOS", "RIBEIRAO DAS NEVES", "RIBEIRAO VERMELHO", "RIO ACIMA", "RIO CASCA", "RIO DO PRADO", "RIO DOCE", "RIO ESPERA", "RIO MANSO", "RIO NOVO", "RIO PARANAIBA", "RIO PARDO DE MINAS", "RIO PIRACICABA", "RIO POMBA", "RIO PRETO", "RIO VERMELHO", "RITAPOLIS", "ROCHEDO DE MINAS", "RODEIRO", "ROMARIA", "ROSARIO DA LIMEIRA", "RUBELITA", "RUBIM", "SABARA", "SABINOPOLIS", "SACRAMENTO", "SALINAS", "SALTO DA DIVISA", "SANTA BARBARA", "SANTA BARBARA DO LESTE", "SANTA BARBARA DO MONTE VERDE", "SANTA BARBARA DO TUGURIO", "SANTA CRUZ DE MINAS", "SANTA CRUZ DE SALINAS", "SANTA CRUZ DO ESCALVADO", "SANTA EFIGENIA DE MINAS", "SANTA FE DE MINAS", "SANTA HELENA DE MINAS", "SANTA JULIANA", "SANTA LUZIA", "SANTA MARGARIDA", "SANTA MARIA DE ITABIRA", "SANTA MARIA DO SALTO", "SANTA MARIA DO SUACUI", "SANTA RITA DE CALDAS", "SANTA RITA DE IBITIPOCA", "SANTA RITA DE JACUTINGA", "SANTA RITA DE MINAS", "SANTA RITA DO ITUETO", "SANTA RITA DO SAPUCAI", "SANTA ROSA DA SERRA", "SANTA VITORIA", "SANTANA DA VARGEM", "SANTANA DE CATAGUASES", "SANTANA DE PIRAPAMA", "SANTANA DO DESERTO", "SANTANA DO GARAMBEU", "SANTANA DO JACARE", "SANTANA DO MANHUACU", "SANTANA DO PARAISO", "SANTANA DO RIACHO", "SANTANA DOS MONTES", "SANTO ANTONIO DO AMPARO", "SANTO ANTONIO DO AVENTUREIRO", "SANTO ANTONIO DO GRAMA", "SANTO ANTONIO DO ITAMBE", "SANTO ANTONIO DO JACINTO", "SANTO ANTONIO DO MONTE", "SANTO ANTONIO DO RETIRO", "SANTO ANTONIO DO RIO ABAIXO", "SANTO HIPOLITO", "SANTOS DUMONT", "SAO BENTO ABADE", "SAO BRAS DO SUACUI", "SAO DOMINGOS DAS DORES", "SAO DOMINGOS DO PRATA", "SAO FELIX DE MINAS", "SAO FRANCISCO", "SAO FRANCISCO DE PAULA", "SAO FRANCISCO DE SALES", "SAO FRANCISCO DO GLORIA", "SAO GERALDO", "SAO GERALDO DA PIEDADE", "SAO GERALDO DO BAIXIO", "SAO GONCALO DO ABAETE", "SAO GONCALO DO PARA", "SAO GONCALO DO RIO ABAIXO", "SAO GONCALO DO RIO PRETO", "SAO GONCALO DO SAPUCAI", "SAO GOTARDO", "SAO JOAO BATISTA DO GLORIA", "SAO JOAO DA LAGOA", "SAO JOAO DA MATA", "SAO JOAO DA PONTE", "SAO JOAO DAS MISSOES", "SAO JOAO DEL REI", "SAO JOAO DO MANHUACU", "SAO JOAO DO MANTENINHA", "SAO JOAO DO ORIENTE", "SAO JOAO DO PACUI", "SAO JOAO DO PARAISO", "SAO JOAO EVANGELISTA", "SAO JOAO NEPOMUCENO", "SAO JOAQUIM DE BICAS", "SAO JOSE DA BARRA", "SAO JOSE DA LAPA", "SAO JOSE DA SAFIRA", "SAO JOSE DA VARGINHA", "SAO JOSE DO ALEGRE", "SAO JOSE DO DIVINO", "SAO JOSE DO GOIABAL", "SAO JOSE DO JACURI", "SAO JOSE DO MANTIMENTO", "SAO LOURENCO", "SAO MIGUEL DO ANTA", "SAO PEDRO DA UNIAO", "SAO PEDRO DO SUACUI", "SAO PEDRO DOS FERROS", "SAO ROMAO", "SAO ROQUE DE MINAS", "SAO SEBASTIAO DA BELA VISTA", "SAO SEBASTIAO DA VARGEM ALEGRE", "SAO SEBASTIAO DO ANTA", "SAO SEBASTIAO DO MARANHAO", "SAO SEBASTIAO DO OESTE", "SAO SEBASTIAO DO PARAISO", "SAO SEBASTIAO DO RIO PRETO", "SAO SEBASTIAO DO RIO VERDE", "SAO THOME DAS LETRAS", "SAO TIAGO", "SAO TOMAS DE AQUINO", "SAO VICENTE DE MINAS", "SAPUCAI-MIRIM", "SARDOA", "SARZEDO", "SEM-PEIXE", "SENADOR AMARAL", "SENADOR CORTES", "SENADOR FIRMINO", "SENADOR JOSE BENTO", "SENADOR MODESTINO GONCALVES", "SENHORA DE OLIVEIRA", "SENHORA DO PORTO", "SENHORA DOS REMEDIOS", "SERICITA", "SERITINGA", "SERRA AZUL DE MINAS", "SERRA DA SAUDADE", "SERRA DO SALITRE", "SERRA DOS AIMORES", "SERRANIA", "SERRANOPOLIS DE MINAS", "SERRANOS", "SERRO", "SETE LAGOAS", "SETUBINHA", "SILVEIRANIA", "SILVIANOPOLIS", "SIMAO PEREIRA", "SIMONESIA", "SOBRALIA", "SOLEDADE DE MINAS", "TABULEIRO", "TAIOBEIRAS", "TAPARUBA", "TAPIRA", "TAPIRAI", "TAQUARACU DE MINAS", "TARUMIRIM", "TEIXEIRAS", "TEOFILO OTONI", "TIMOTEO", "TIRADENTES", "TIROS", "TOCANTINS", "TOCOS DO MOJI", "TOLEDO", "TOMBOS", "TRES CORACOES", "TRES MARIAS", "TRES PONTAS", "TUMIRITINGA", "TUPACIGUARA", "TURMALINA", "TURVOLANDIA", "UBA", "UBAI", "UBAPORANGA", "UBERABA", "UBERLANDIA", "UMBURATIBA", "UNAI", "UNIAO DE MINAS", "URUANA DE MINAS", "URUCANIA", "URUCUIA", "VARGEM ALEGRE", "VARGEM BONITA", "VARGEM GRANDE DO RIO PARDO", "VARGINHA", "VARJAO DE MINAS", "VARZEA DA PALMA", "VARZELANDIA", "VAZANTE", "VERDELANDIA", "VEREDINHA", "VERISSIMO", "VERMELHO NOVO", "VESPASIANO", "VICOSA", "VIEIRAS", "VIRGEM DA LAPA", "VIRGINIA", "VIRGINOPOLIS", "VIRGOLANDIA", "VISCONDE DO RIO BRANCO", "VOLTA GRANDE", "WENCESLAU BRAZ" });
            estadosCidade.Add("MS", new List<string>() { "AGUA CLARA", "ALCINOPOLIS", "AMAMBAI", "ANASTACIO", "ANAURILANDIA", "ANGELICA", "ANTONIO JOAO", "APARECIDA DO TABOADO", "AQUIDAUANA", "ARAL MOREIRA", "BANDEIRANTES", "BATAGUASSU", "BATAIPORA", "BELA VISTA", "BODOQUENA", "BONITO", "BRASILANDIA", "CAARAPO", "CAMAPUA", "CAMPO GRANDE", "CARACOL", "CASSILANDIA", "CHAPADAO DO SUL", "CORGUINHO", "CORONEL SAPUCAIA", "CORUMBA", "COSTA RICA", "COXIM", "DEODAPOLIS", "DOIS IRMAOS DO BURITI", "DOURADINA", "DOURADOS", "ELDORADO", "FATIMA DO SUL", "GLORIA DE DOURADOS", "GUIA LOPES DA LAGUNA", "IGUATEMI", "INOCENCIA", "ITAPORA", "ITAQUIRAI", "IVINHEMA", "JAPORA", "JARAGUARI", "JARDIM", "JATEI", "JUTI", "LADARIO", "LAGUNA CARAPA", "MARACAJU", "MIRANDA", "MUNDO NOVO", "NAVIRAI", "NIOAQUE", "NOVA ALVORADA DO SUL", "NOVA ANDRADINA", "NOVO HORIZONTE DO SUL", "PARANAIBA", "PARANHOS", "PEDRO GOMES", "PONTA PORA", "PORTO MURTINHO", "RIBAS DO RIO PARDO", "RIO BRILHANTE", "RIO NEGRO", "RIO VERDE DE MATO GROSSO", "ROCHEDO", "SANTA RITA DO PARDO", "SAO GABRIEL DO OESTE", "SELVIRIA", "SETE QUEDAS", "SIDROLANDIA", "SONORA", "TACURU", "TAQUARUSSU", "TERENOS", "TRES LAGOAS", "VICENTINA" });
            estadosCidade.Add("MT", new List<string>() { "MATO GROSSO", "ACORIZAL", "AGUA BOA", "ALTA FLORESTA", "ALTO ARAGUAIA", "ALTO BOA VISTA", "ALTO GARCAS", "ALTO PARAGUAI", "ALTO TAQUARI", "APIACAS", "ARAGUAIANA", "ARAGUAINHA", "ARAPUTANGA", "ARENAPOLIS", "ARIPUANA", "BARAO DE MELGACO", "BARRA DO BUGRES", "BARRA DO GARCAS", "BOM JESUS DO ARAGUAIA", "BRASNORTE", "CACERES", "CAMPINAPOLIS", "CAMPO NOVO DO PARECIS", "CAMPO VERDE", "CAMPOS DE JULIO", "CANABRAVA DO NORTE", "CANARANA", "CARLINDA", "CASTANHEIRA", "CHAPADA DOS GUIMARAES", "CLAUDIA", "COCALINHO", "COLIDER", "COLNIZA", "COMODORO", "CONFRESA", "CONQUISTA D'OESTE", "COTRIGUACU", "CURVELANDIA", "CUIABA", "DENISE", "DIAMANTINO", "DOM AQUINO", "FELIZ NATAL", "FIGUEIROPOLIS D'OESTE", "GAUCHA DO NORTE", "GENERAL CARNEIRO", "GLORIA D'OESTE", "GUARANTA DO NORTE", "GUIRATINGA", "INDIAVAI", "ITAUBA", "ITIQUIRA", "JACIARA", "JANGADA", "JAURU", "JUARA", "JUINA", "JURUENA", "JUSCIMEIRA", "LAMBARI D'OESTE", "LUCAS DO RIO VERDE", "LUCIARA", "MARCELANDIA", "MATUPA", "MIRASSOL D'OESTE", "NOBRES", "NORTELANDIA", "NOSSA SENHORA DO LIVRAMENTO", "NOVA BANDEIRANTES", "NOVA BRASILANDIA", "NOVA CANAA DO NORTE", "NOVA GUARITA", "NOVA LACERDA", "NOVA MARILANDIA", "NOVA MARINGA", "NOVA MONTE VERDE", "NOVA MUTUM", "NOVA NAZARE", "NOVA OLIMPIA", "NOVA SANTA HELENA", "NOVA UBIRATA", "NOVA XAVANTINA", "NOVO HORIZONTE DO NORTE", "NOVO MUNDO", "NOVO SANTO ANTONIO", "NOVO SAO JOAQUIM", "PARANAITA", "PARANATINGA", "PEDRA PRETA", "PEIXOTO DE AZEVEDO", "PLANALTO DA SERRA", "POCONE", "PONTAL DO ARAGUAIA", "PONTE BRANCA", "PONTES E LACERDA", "PORTO ALEGRE DO NORTE", "PORTO DOS GAUCHOS", "PORTO ESPERIDIAO", "PORTO ESTRELA", "POXOREO", "PRIMAVERA DO LESTE", "QUERENCIA", "RESERVA DO CABACAL", "RIBEIRAO CASCALHEIRA", "RIBEIRAOZINHO", "RIO BRANCO", "RONDOLANDIA", "RONDONOPOLIS", "ROSARIO OESTE", "SALTO DO CEU", "SANTA CARMEM", "SANTA CRUZ DO XINGU", "SANTA RITA DO TRIVELATO", "SANTA TEREZINHA", "SANTO AFONSO", "SANTO ANTONIO DO LESTE", "SANTO ANTONIO DO LEVERGER", "SAO FELIX DO ARAGUAIA", "SAO JOSE DO POVO", "SAO JOSE DO RIO CLARO", "SAO JOSE DO XINGU", "SAO JOSE DOS QUATRO MARCOS", "SAO PEDRO DA CIPA", "SAPEZAL", "SERRA NOVA DOURADA", "SINOP", "SORRISO", "TABAPORA", "TANGARA DA SERRA", "TAPURAH", "TERRA NOVA DO NORTE", "TESOURO", "TORIXOREU", "UNIAO DO SUL", "VALE DE SAO DOMINGOS", "VARZEA GRANDE", "VERA", "VILA BELA DA SANTISSIMA TRINDADE", "VILA RICA" });
            estadosCidade.Add("PA", new List<string>() { "PARA", "ABAETETUBA", "ABEL FIGUEIREDO", "ACARA", "AFUA", "AGUA AZUL DO NORTE", "ALENQUER", "ALMEIRIM", "ALTAMIRA", "ANAJAS", "ANANINDEUA", "ANAPU", "AUGUSTO CORREA", "AURORA DO PARA", "AVEIRO", "BAGRE", "BAIAO", "BANNACH", "BARCARENA", "BELEM", "BELTERRA", "BENEVIDES", "BOM JESUS DO TOCANTINS", "BONITO", "BRAGANCA", "BRASIL NOVO", "BREJO GRANDE DO ARAGUAIA", "BREU BRANCO", "BREVES", "BUJARU", "CACHOEIRA DO ARARI", "CACHOEIRA DO PIRIA", "CAMETA", "CANAA DOS CARAJAS", "CAPANEMA", "CAPITAO POCO", "CASTANHAL", "CHAVES", "COLARES", "CONCEICAO DO ARAGUAIA", "CONCORDIA DO PARA", "CUMARU DO NORTE", "CURIONOPOLIS", "CURRALINHO", "CURUA", "CURUCA", "DOM ELISEU", "ELDORADO DOS CARAJAS", "FARO", "FLORESTA DO ARAGUAIA", "GARRAFAO DO NORTE", "GOIANESIA DO PARA", "GURUPA", "IGARAPE-ACU", "IGARAPE-MIRI", "INHANGAPI", "IPIXUNA DO PARA", "IRITUIA", "ITAITUBA", "ITUPIRANGA", "JACAREACANGA", "JACUNDA", "JURUTI", "LIMOEIRO DO AJURU", "MAE DO RIO", "MAGALHAES BARATA", "MARABA", "MARACANA", "MARAPANIM", "MARITUBA", "MEDICILANDIA", "MELGACO", "MOCAJUBA", "MOJU", "MONTE ALEGRE", "MUANA", "NOVA ESPERANCA DO PIRIA", "NOVA IPIXUNA", "NOVA TIMBOTEUA", "NOVO PROGRESSO", "NOVO REPARTIMENTO", "OBIDOS", "OEIRAS DO PARA", "ORIXIMINA", "OUREM", "OURILANDIA DO NORTE", "PACAJA", "PALESTINA DO PARA", "PARAGOMINAS", "PARAUAPEBAS", "PAU D'ARCO", "PEIXE-BOI", "PICARRA", "PLACAS", "PONTA DE PEDRAS", "PORTEL", "PORTO DE MOZ", "PRAINHA", "PRIMAVERA", "QUATIPURU", "REDENCAO", "RIO MARIA", "RONDON DO PARA", "RUROPOLIS", "SALINOPOLIS", "SALVATERRA", "SANTA BARBARA DO PARA", "SANTA CRUZ DO ARARI", "SANTA ISABEL DO PARA", "SANTA LUZIA DO PARA", "SANTA MARIA DAS BARREIRAS", "SANTA MARIA DO PARA", "SANTANA DO ARAGUAIA", "SANTAREM", "SANTAREM NOVO", "SANTO ANTONIO DO TAUA", "SAO CAETANO DE ODIVELA", "SAO DOMINGOS DO ARAGUAIA", "SAO DOMINGOS DO CAPIM", "SAO FELIX DO XINGU", "SAO FRANCISCO DO PARA", "SAO GERALDO DO ARAGUAIA", "SAO JOAO DA PONTA", "SAO JOAO DE PIRABAS", "SAO JOAO DO ARAGUAIA", "SAO MIGUEL DO GUAMA", "SAO SEBASTIAO DA BOA VISTA", "SAPUCAIA", "SENADOR JOSE PORFIRIO", "SOURE", "TAILANDIA", "TERRA ALTA", "TERRA SANTA", "TOME-ACU", "TRACUATEUA", "TRAIRAO", "TUCUMA", "TUCURUI", "ULIANOPOLIS", "URUARA", "VIGIA", "VISEU", "VITORIA DO XINGU", "XINGUARA" });
            estadosCidade.Add("PB", new List<string>() { "PARAIBA", "AGUA BRANCA", "AGUIAR", "ALAGOA GRANDE", "ALAGOA NOVA", "ALAGOINHA", "ALCANTIL", "ALGODAO DE JANDAIRA", "ALHANDRA", "AMPARO", "APARECIDA", "ARACAGI", "ARARA", "ARARUNA", "AREIA", "AREIA DE BARAUNAS", "AREIAL", "AROEIRAS", "ASSUNCAO", "BAIA DA TRAICAO", "BANANEIRAS", "BARAUNA", "BARRA DE SANTA ROSA", "BARRA DE SANTANA", "BARRA DE SAO MIGUEL", "BAYEUX", "BELEM", "BELEM DO BREJO DO CRUZ", "BERNARDINO BATISTA", "BOA VENTURA", "BOA VISTA", "BOM JESUS", "BOM SUCESSO", "BONITO DE SANTA FE", "BOQUEIRAO", "BORBOREMA", "BREJO DO CRUZ", "BREJO DOS SANTOS", "CAAPORA", "CABACEIRAS", "CABEDELO", "CACHOEIRA DOS INDIOS", "CACIMBA DE AREIA", "CACIMBA DE DENTRO", "CACIMBAS", "CAICARA", "CAJAZEIRAS", "CAJAZEIRINHAS", "CALDAS BRANDAO", "CAMALAU", "CAMPINA GRANDE", "CAMPO DE SANTANA", "CAPIM", "CARAUBAS", "CARRAPATEIRA", "CASSERENGUE", "CATINGUEIRA", "CATOLE DO ROCHA", "CATURITE", "CONCEICAO", "CONDADO", "CONDE", "CONGO", "COREMAS", "COXIXOLA", "CRUZ DO ESPIRITO SANTO", "CUBATI", "CUITE", "CUITE DE MAMANGUAPE", "CUITEGI", "CURRAL DE CIMA", "CURRAL VELHO", "DAMIAO", "DESTERRO", "DIAMANTE", "DONA INES", "DUAS ESTRADAS", "EMAS", "ESPERANCA", "FAGUNDES", "FREI MARTINHO", "GADO BRAVO", "GUARABIRA", "GURINHEM", "GURJAO", "IBIARA", "IGARACY", "IMACULADA", "INGA", "ITABAIANA", "ITAPORANGA", "ITAPOROROCA", "ITATUBA", "JACARAU", "JERICO", "JOAO PESSOA", "JUAREZ TAVORA", "JUAZEIRINHO", "JUNCO DO SERIDO", "JURIPIRANGA", "JURU", "LAGOA", "LAGOA DE DENTRO", "LAGOA SECA", "LASTRO", "LIVRAMENTO", "LOGRADOURO", "LUCENA", "MAE D'AGUA", "MALTA", "MAMANGUAPE", "MANAIRA", "MARCACAO", "MARI", "MARIZOPOLIS", "MASSARANDUBA", "MATARACA", "MATINHAS", "MATO GROSSO", "MATUREIA", "MOGEIRO", "MONTADAS", "MONTE HOREBE", "MONTEIRO", "MULUNGU", "NATUBA", "NAZAREZINHO", "NOVA FLORESTA", "NOVA OLINDA", "NOVA PALMEIRA", "OLHO D'AGUA", "OLIVEDOS", "OURO VELHO", "PARARI", "PASSAGEM", "PATOS", "PAULISTA", "PEDRA BRANCA", "PEDRA LAVRADA", "PEDRAS DE FOGO", "PEDRO REGIS", "PIANCO", "PICUI", "PILAR", "PILOES", "PILOEZINHOS", "PIRPIRITUBA", "PITIMBU", "POCINHOS", "POCO DANTAS", "POCO DE JOSE DE MOURA", "POMBAL", "PRATA", "PRINCESA ISABEL", "PUXINANA", "QUEIMADAS", "QUIXABA", "REMIGIO", "RIACHAO", "RIACHAO DO BACAMARTE", "RIACHAO DO POCO", "RIACHO DE SANTO ANTONIO", "RIACHO DOS CAVALOS", "RIO TINTO", "SALGADINHO", "SALGADO DE SAO FELIX", "SANTA CECILIA", "SANTA CRUZ", "SANTA HELENA", "SANTA INES", "SANTA LUZIA", "SANTA RITA", "SANTA TERESINHA", "SANTANA DE MANGUEIRA", "SANTANA DOS GARROTES", "SANTAREM", "SANTO ANDRE", "SAO BENTINHO", "SAO BENTO", "SAO DOMINGOS DE POMBAL", "SAO DOMINGOS DO CARIRI", "SAO FRANCISCO", "SAO JOAO DO CARIRI", "SAO JOAO DO RIO DO PEIXE", "SAO JOAO DO TIGRE", "SAO JOSE DA LAGOA TAPADA", "SAO JOSE DE CAIANA", "SAO JOSE DE ESPINHARAS", "SAO JOSE DE PIRANHAS", "SAO JOSE DE PRINCESA", "SAO JOSE DO BONFIM", "SAO JOSE DO BREJO DO CRUZ", "SAO JOSE DO SABUGI", "SAO JOSE DOS CORDEIROS", "SAO JOSE DOS RAMOS", "SAO MAMEDE", "SAO MIGUEL DE TAIPU", "SAO SEBASTIAO DE LAGOA DE ROCA", "SAO SEBASTIAO DO UMBUZEIRO", "SAPE", "SERIDO", "SERRA BRANCA", "SERRA DA RAIZ", "SERRA GRANDE", "SERRA REDONDA", "SERRARIA", "SERTAOZINHO", "SOBRADO", "SOLANEA", "SOLEDADE", "SOSSEGO", "SOUSA", "SUME", "TAPEROA", "TAVARES", "TEIXEIRA", "TENORIO", "TRIUNFO", "UIRAUNA", "UMBUZEIRO", "VARZEA", "VIEIROPOLIS", "VISTA SERRANA", "ZABELE" });
            estadosCidade.Add("PE", new List<string>() { "PERNAMBUCO", "ABREU E LIMA", "AFOGADOS DA INGAZEIRA", "AFRANIO", "AGRESTINA", "AGUA PRETA", "AGUAS BELAS", "ALAGOINHA", "ALIANCA", "ALTINHO", "AMARAJI", "ANGELIM", "ARACOIABA", "ARARIPINA", "ARCOVERDE", "BARRA DE GUABIRABA", "BARREIROS", "BELEM DE MARIA", "BELEM DE SAO FRANCISCO", "BELO JARDIM", "BETANIA", "BEZERROS", "BODOCO", "BOM CONSELHO", "BOM JARDIM", "BONITO", "BREJAO", "BREJINHO", "BREJO DA MADRE DE DEUS", "BUENOS AIRES", "BUIQUE", "CABO DE SANTO AGOSTINHO", "CABROBO", "CACHOEIRINHA", "CAETES", "CALCADO", "CALUMBI", "CAMARAGIBE", "CAMOCIM DE SAO FELIX", "CAMUTANGA", "CANHOTINHO", "CAPOEIRAS", "CARNAIBA", "CARNAUBEIRA DA PENHA", "CARPINA", "CARUARU", "CASINHAS", "CATENDE", "CEDRO", "CHA DE ALEGRIA", "CHA GRANDE", "CONDADO", "CORRENTES", "CORTES", "CUMARU", "CUPIRA", "CUSTODIA", "DORMENTES", "ESCADA", "EXU", "FEIRA NOVA", "FERNANDO DE NORONHA", "FERREIROS", "FLORES", "FLORESTA", "FREI MIGUELINHO", "GAMELEIRA", "GARANHUNS", "GLORIA DO GOITA", "GOIANA", "GRANITO", "GRAVATA", "IATI", "IBIMIRIM", "IBIRAJUBA", "IGARASSU", "IGUARACI", "INAJA", "INGAZEIRA", "IPOJUCA", "IPUBI", "ITACURUBA", "ITAIBA", "ITAMARACA", "ITAMBE", "ITAPETIM", "ITAPISSUMA", "ITAQUITINGA", "JABOATAO DOS GUARARAPES", "JAQUEIRA", "JATAUBA", "JATOBA", "JOAO ALFREDO", "JOAQUIM NABUCO", "JUCATI", "JUPI", "JUREMA", "LAGOA DO CARRO", "LAGOA DO ITAENGA", "LAGOA DO OURO", "LAGOA DOS GATOS", "LAGOA GRANDE", "LAJEDO", "LIMOEIRO", "MACAPARANA", "MACHADOS", "MANARI", "MARAIAL", "MIRANDIBA", "MOREILANDIA", "MORENO", "NAZARE DA MATA", "OLINDA", "OROBO", "OROCO", "OURICURI", "PALMARES", "PALMEIRINA", "PANELAS", "PARANATAMA", "PARNAMIRIM", "PASSIRA", "PAUDALHO", "PAULISTA", "PEDRA", "PESQUEIRA", "PETROLANDIA", "PETROLINA", "POCAO", "POMBOS", "PRIMAVERA", "QUIPAPA", "QUIXABA", "RECIFE", "RIACHO DAS ALMAS", "RIBEIRAO", "RIO FORMOSO", "SAIRE", "SALGADINHO", "SALGUEIRO", "SALOA", "SANHARO", "SANTA CRUZ", "SANTA CRUZ DA BAIXA VERDE", "SANTA CRUZ DO CAPIBARIBE", "SANTA FILOMENA", "SANTA MARIA DA BOA VISTA", "SANTA MARIA DO CAMBUCA", "SANTA TEREZINHA", "SAO BENEDITO DO SUL", "SAO BENTO DO UNA", "SAO CAITANO", "SAO JOAO", "SAO JOAQUIM DO MONTE", "SAO JOSE DA COROA GRANDE", "SAO JOSE DO BELMONTE", "SAO JOSE DO EGITO", "SAO LOURENCO DA MATA", "SAO VICENTE FERRER", "SERRA TALHADA", "SERRITA", "SERTANIA", "SIRINHAEM", "SOLIDAO", "SURUBIM", "TABIRA", "TACAIMBO", "TACARATU", "TAMANDARE", "TAQUARITINGA DO NORTE", "TEREZINHA", "TERRA NOVA", "TIMBAUBA", "TORITAMA", "TRACUNHAEM", "TRINDADE", "TRIUNFO", "TUPANATINGA", "TUPARETAMA", "VENTUROSA", "VERDEJANTE", "VERTENTE DO LERIO", "VERTENTES", "VICENCIA", "VITORIA DE SANTO ANTAO", "XEXEU" });
            estadosCidade.Add("PI", new List<string>() { "Piauí", "ACAUA", "AGRICOLANDIA", "AGUA BRANCA", "ALAGOINHA DO PIAUI", "ALEGRETE DO PIAUI", "ALTO LONGA", "ALTOS", "ALVORADA DO GURGUEIA", "AMARANTE", "ANGICAL DO PIAUI", "ANISIO DE ABREU", "ANTONIO ALMEIDA", "AROAZES", "ARRAIAL", "ASSUNCAO DO PIAUI", "AVELINO LOPES", "BAIXA GRANDE DO RIBEIRO", "BARRA D'ALCANTARA", "BARRAS", "BARREIRAS DO PIAUI", "BARRO DURO", "BATALHA", "BELA VISTA DO PIAUI", "BELEM DO PIAUI", "BENEDITINOS", "BERTOLINIA", "BETANIA DO PIAUI", "BOA HORA", "BOCAINA", "BOM JESUS", "BOM PRINCIPIO DO PIAUI", "BONFIM DO PIAUI", "BOQUEIRAO DO PIAUI", "BRASILEIRA", "BREJO DO PIAUI", "BURITI DOS LOPES", "BURITI DOS MONTES", "CABECEIRAS DO PIAUI", "CAJAZEIRAS DO PIAUI", "CAJUEIRO DA PRAIA", "CALDEIRAO GRANDE DO PIAUI", "CAMPINAS DO PIAUI", "CAMPO ALEGRE DO FIDALGO", "CAMPO GRANDE DO PIAUI", "CAMPO LARGO DO PIAUI", "CAMPO MAIOR", "CANAVIEIRA", "CANTO DO BURITI", "CAPITAO DE CAMPOS", "CAPITAO GERVASIO OLIVEIRA", "CARACOL", "CARAUBAS DO PIAUI", "CARIDADE DO PIAUI", "CASTELO DO PIAUI", "CAXINGO", "COCAL", "COCAL DE TELHA", "COCAL DOS ALVES", "COIVARAS", "COLONIA DO GURGUEIA", "COLONIA DO PIAUI", "CONCEICAO DO CANINDE", "CORONEL JOSE DIAS", "CORRENTE", "CRISTALANDIA DO PIAUI", "CRISTINO CASTRO", "CURIMATA", "CURRAIS", "CURRAL NOVO DO PIAUI", "CURRALINHOS", "DEMERVAL LOBAO", "DIRCEU ARCOVERDE", "DOM EXPEDITO LOPES", "DOM INOCENCIO", "DOMINGOS MOURAO", "ELESBAO VELOSO", "ELISEU MARTINS", "ESPERANTINA", "FARTURA DO PIAUI", "FLORES DO PIAUI", "FLORESTA DO PIAUI", "FLORIANO", "FRANCINOPOLIS", "FRANCISCO AYRES", "FRANCISCO MACEDO", "FRANCISCO SANTOS", "FRONTEIRAS", "GEMINIANO", "GILBUES", "GUADALUPE", "GUARIBAS", "HUGO NAPOLEAO", "ILHA GRANDE", "INHUMA", "IPIRANGA DO PIAUI", "ISAIAS COELHO", "ITAINOPOLIS", "ITAUEIRA", "JACOBINA DO PIAUI", "JAICOS", "JARDIM DO MULATO", "JATOBA DO PIAUI", "JERUMENHA", "JOAO COSTA", "JOAQUIM PIRES", "JOCA MARQUES", "JOSE DE FREITAS", "JUAZEIRO DO PIAUI", "JULIO BORGES", "JUREMA", "LAGOA ALEGRE", "LAGOA DE SAO FRANCISCO", "LAGOA DO BARRO DO PIAUI", "LAGOA DO PIAUI", "LAGOA DO SITIO", "LAGOINHA DO PIAUI", "LANDRI SALES", "LUIS CORREIA", "LUZILANDIA", "MADEIRO", "MANOEL EMIDIO", "MARCOLANDIA", "MARCOS PARENTE", "MASSAPE DO PIAUI", "MATIAS OLIMPIO", "MIGUEL ALVES", "MIGUEL LEAO", "MILTON BRANDAO", "MONSENHOR GIL", "MONSENHOR HIPOLITO", "MONTE ALEGRE DO PIAUI", "MORRO CABECA NO TEMPO", "MORRO DO CHAPEU DO PIAUI", "MURICI DOS PORTELAS", "NAZARE DO PIAUI", "NOSSA SENHORA DE NAZARE", "NOSSA SENHORA DOS REMEDIOS", "NOVA SANTA RITA", "NOVO ORIENTE DO PIAUI", "NOVO SANTO ANTONIO", "OEIRAS", "OLHO D'AGUA DO PIAUI", "PADRE MARCOS", "PAES LANDIM", "PAJEU DO PIAUI", "PALMEIRA DO PIAUI", "PALMEIRAIS", "PAQUETA", "PARNAGUA", "PARNAIBA", "PASSAGEM FRANCA DO PIAUI", "PATOS DO PIAUI", "PAU D'ARCO DO PIAUI", "PAULISTANA", "PAVUSSU", "PEDRO II", "PEDRO LAURENTINO", "PICOS", "PIMENTEIRAS", "PIO IX", "PIRACURUCA", "PIRIPIRI", "PORTO", "PORTO ALEGRE DO PIAUI", "PRATA DO PIAUI", "QUEIMADA NOVA", "REDENCAO DO GURGUEIA", "REGENERACAO", "RIACHO FRIO", "RIBEIRA DO PIAUI", "RIBEIRO GONCALVES", "RIO GRANDE DO PIAUI", "SANTA CRUZ DO PIAUI", "SANTA CRUZ DOS MILAGRES", "SANTA FILOMENA", "SANTA LUZ", "SANTA ROSA DO PIAUI", "SANTANA DO PIAUI", "SANTO ANTONIO DE LISBOA", "SANTO ANTONIO DOS MILAGRES", "SANTO INACIO DO PIAUI", "SAO BRAZ DO PIAUI", "SAO FELIX DO PIAUI", "SAO FRANCISCO DE ASSIS DO PIAUI", "SAO FRANCISCO DO PIAUI", "SAO GONCALO DO GURGUEIA", "SAO GONCALO DO PIAUI", "SAO JOAO DA CANABRAVA", "SAO JOAO DA FRONTEIRA", "SAO JOAO DA SERRA", "SAO JOAO DA VARJOTA", "SAO JOAO DO ARRAIAL", "SAO JOAO DO PIAUI", "SAO JOSE DO DIVINO", "SAO JOSE DO PEIXE", "SAO JOSE DO PIAUI", "SAO JULIAO", "SAO LOURENCO DO PIAUI", "SAO LUIS DO PIAUI", "SAO MIGUEL DA BAIXA GRANDE", "SAO MIGUEL DO FIDALGO", "SAO MIGUEL DO TAPUIO", "SAO PEDRO DO PIAUI", "SAO RAIMUNDO NONATO", "SEBASTIAO BARROS", "SEBASTIAO LEAL", "SIGEFREDO PACHECO", "SIMOES", "SIMPLICIO MENDES", "SOCORRO DO PIAUI", "SUSSUAPARA", "TAMBORIL DO PIAUI", "TANQUE DO PIAUI", "TERESINA", "UNIAO", "URUCUI", "VALENCA DO PIAUI", "VARZEA BRANCA", "VARZEA GRANDE", "VERA MENDES", "VILA NOVA DO PIAUI", "WALL FERRAZ" });
            estadosCidade.Add("PR", new List<string>() { "ABATIA", "ADRIANOPOLIS", "AGUDOS DO SUL", "ALMIRANTE TAMANDARE", "ALTAMIRA DO PARANA", "ALTO PARANA", "ALTO PIQUIRI", "ALTONIA", "ALVORADA DO SUL", "AMAPORA", "AMPERE", "ANAHY", "ANDIRA", "ANGULO", "ANTONINA", "ANTONIO OLINTO", "APUCARANA", "ARAPONGAS", "ARAPOTI", "ARAPUA", "ARARUNA", "ARAUCARIA", "ARIRANHA DO IVAI", "ASSAI", "ASSIS CHATEAUBRIAND", "ASTORGA", "ATALAIA", "BALSA NOVA", "BANDEIRANTES", "BARBOSA FERRAZ", "BARRA DO JACARE", "BARRACAO", "BELA VISTA DA CAROBA", "BELA VISTA DO PARAISO", "BITURUNA", "BOA ESPERANCA", "BOA ESPERANCA DO IGUACU", "BOA VENTURA DE SAO ROQUE", "BOA VISTA DA APARECIDA", "BOCAIUVA DO SUL", "BOM JESUS DO SUL", "BOM SUCESSO", "BOM SUCESSO DO SUL", "BORRAZOPOLIS", "BRAGANEY", "BRASILANDIA DO SUL", "CAFEARA", "CAFELANDIA", "CAFEZAL DO SUL", "CALIFORNIA", "CAMBARA", "CAMBE", "CAMBIRA", "CAMPINA DA LAGOA", "CAMPINA DO SIMAO", "CAMPINA GRANDE DO SUL", "CAMPO BONITO", "CAMPO DO TENENTE", "CAMPO LARGO", "CAMPO MAGRO", "CAMPO MOURAO", "CANDIDO DE ABREU", "CANDOI", "CANTAGALO", "CAPANEMA", "CAPITAO LEONIDAS MARQUES", "CARAMBEI", "CARLOPOLIS", "CASCAVEL", "CASTRO", "CATANDUVAS", "CENTENARIO DO SUL", "CERRO AZUL", "CEU AZUL", "CHOPINZINHO", "CIANORTE", "CIDADE GAUCHA", "CLEVELANDIA", "COLOMBO", "COLORADO", "CONGONHINHAS", "CONSELHEIRO MAIRINCK", "CONTENDA", "CORBELIA", "CORNELIO PROCOPIO", "CORONEL DOMINGOS SOARES", "CORONEL VIVIDA", "CORUMBATAI DO SUL", "CRUZ MACHADO", "CRUZEIRO DO IGUACU", "CRUZEIRO DO OESTE", "CRUZEIRO DO SUL", "CRUZMALTINA", "CURITIBA", "CURIUVA", "DIAMANTE D'OESTE", "DIAMANTE DO NORTE", "DIAMANTE DO SUL", "DOIS VIZINHOS", "DOURADINA", "DOUTOR CAMARGO", "DOUTOR ULYSSES", "ENEAS MARQUES", "ENGENHEIRO BELTRAO", "ENTRE RIOS DO OESTE", "ESPERANCA NOVA", "ESPIGAO ALTO DO IGUACU", "FAROL", "FAXINAL", "FAZENDA RIO GRANDE", "FENIX", "FERNANDES PINHEIRO", "FIGUEIRA", "FLOR DA SERRA DO SUL", "FLORAI", "FLORESTA", "FLORESTOPOLIS", "FLORIDA", "FORMOSA DO OESTE", "FOZ DO IGUACU", "FOZ DO JORDAO", "FRANCISCO ALVES", "FRANCISCO BELTRAO", "GENERAL CARNEIRO", "GODOY MOREIRA", "GOIOERE", "GOIOXIM", "GRANDES RIOS", "GUAIRA", "GUAIRACA", "GUAMIRANGA", "GUAPIRAMA", "GUAPOREMA", "GUARACI", "GUARANIACU", "GUARAPUAVA", "GUARAQUECABA", "GUARATUBA", "HONORIO SERPA", "IBAITI", "IBEMA", "IBIPORA", "ICARAIMA", "IGUARACU", "IGUATU", "IMBAU", "IMBITUVA", "INACIO MARTINS", "INAJA", "INDIANOPOLIS", "IPIRANGA", "IPORA", "IRACEMA DO OESTE", "IRATI", "IRETAMA", "ITAGUAJE", "ITAIPULANDIA", "ITAMBARACA", "ITAMBE", "ITAPEJARA D'OESTE", "ITAPERUCU", "ITAUNA DO SUL", "IVAI", "IVAIPORA", "IVATE", "IVATUBA", "JABOTI", "JACAREZINHO", "JAGUAPITA", "JAGUARIAIVA", "JANDAIA DO SUL", "JANIOPOLIS", "JAPIRA", "JAPURA", "JARDIM ALEGRE", "JARDIM OLINDA", "JATAIZINHO", "JESUITAS", "JOAQUIM TAVORA", "JUNDIAI DO SUL", "JURANDA", "JUSSARA", "KALORE", "LAPA", "LARANJAL", "LARANJEIRAS DO SUL", "LEOPOLIS", "LIDIANOPOLIS", "LINDOESTE", "LOANDA", "LOBATO", "LONDRINA", "LUIZIANA", "LUNARDELLI", "LUPIONOPOLIS", "MALLET", "MAMBORE", "MANDAGUACU", "MANDAGUARI", "MANDIRITUBA", "MANFRINOPOLIS", "MANGUEIRINHA", "MANOEL RIBAS", "MARECHAL CANDIDO RONDON", "MARIA HELENA", "MARIALVA", "MARILANDIA DO SUL", "MARILENA", "MARILUZ", "MARINGA", "MARIOPOLIS", "MARIPA", "MARMELEIRO", "MARQUINHO", "MARUMBI", "MATELANDIA", "MATINHOS", "MATO RICO", "MAUA DA SERRA", "MEDIANEIRA", "MERCEDES", "MIRADOR", "MIRASELVA", "MISSAL", "MOREIRA SALES", "MORRETES", "MUNHOZ DE MELO", "NOSSA SENHORA DAS GRACAS", "NOVA ALIANCA DO IVAI", "NOVA AMERICA DA COLINA", "NOVA AURORA", "NOVA CANTU", "NOVA ESPERANCA", "NOVA ESPERANCA DO SUDOESTE", "NOVA FATIMA", "NOVA LARANJEIRAS", "NOVA LONDRINA", "NOVA OLIMPIA", "NOVA PRATA DO IGUACU", "NOVA SANTA BARBARA", "NOVA SANTA ROSA", "NOVA TEBAS", "NOVO ITACOLOMI", "ORTIGUEIRA", "OURIZONA", "OURO VERDE DO OESTE", "PAICANDU", "PALMAS", "PALMEIRA", "PALMITAL", "PALOTINA", "PARAISO DO NORTE", "PARANACITY", "PARANAGUA", "PARANAPOEMA", "PARANAVAI", "PATO BRAGADO", "PATO BRANCO", "PAULA FREITAS", "PAULO FRONTIN", "PEABIRU", "PEROBAL", "PEROLA", "PEROLA D'OESTE", "PIEN", "PINHAIS", "PINHAL DE SAO BENTO", "PINHALAO", "PINHAO", "PIRAI DO SUL", "PIRAQUARA", "PITANGA", "PITANGUEIRAS", "PLANALTINA DO PARANA", "PLANALTO", "PONTA GROSSA", "PONTAL DO PARANA", "PORECATU", "PORTO AMAZONAS", "PORTO BARREIRO", "PORTO RICO", "PORTO VITORIA", "PRADO FERREIRA", "PRANCHITA", "PRESIDENTE CASTELO BRANCO", "PRIMEIRO DE MAIO", "PRUDENTOPOLIS", "QUARTO CENTENARIO", "QUATIGUA", "QUATRO BARRAS", "QUATRO PONTES", "QUEDAS DO IGUACU", "QUERENCIA DO NORTE", "QUINTA DO SOL", "QUITANDINHA", "RAMILANDIA", "RANCHO ALEGRE", "RANCHO ALEGRE D'OESTE", "REALEZA", "REBOUCAS", "RENASCENCA", "RESERVA", "RESERVA DO IGUACU", "RIBEIRAO CLARO", "RIBEIRAO DO PINHAL", "RIO AZUL", "RIO BOM", "RIO BONITO DO IGUACU", "RIO BRANCO DO IVAI", "RIO BRANCO DO SUL", "RIO NEGRO", "ROLANDIA", "RONCADOR", "RONDON", "ROSARIO DO IVAI", "SABAUDIA", "SALGADO FILHO", "SALTO DO ITARARE", "SALTO DO LONTRA", "SANTA AMELIA", "SANTA CECILIA DO PAVAO", "SANTA CRUZ MONTE CASTELO", "SANTA FE", "SANTA HELENA", "SANTA INES", "SANTA ISABEL DO IVAI", "SANTA IZABEL DO OESTE", "SANTA LUCIA", "SANTA MARIA DO OESTE", "SANTA MARIANA", "SANTA MONICA", "SANTA TEREZA DO OESTE", "SANTA TEREZINHA DE ITAIPU", "SANTANA DO ITARARE", "SANTO ANTONIO DA PLATINA", "SANTO ANTONIO DO CAIUA", "SANTO ANTONIO DO PARAISO", "SANTO ANTONIO DO SUDOESTE", "SANTO INACIO", "SAO CARLOS DO IVAI", "SAO JERONIMO DA SERRA", "SAO JOAO", "SAO JOAO DO CAIUA", "SAO JOAO DO IVAI", "SAO JOAO DO TRIUNFO", "SAO JORGE D'OESTE", "SAO JORGE DO IVAI", "SAO JORGE DO PATROCINIO", "SAO JOSE DA BOA VISTA", "SAO JOSE DAS PALMEIRAS", "SAO JOSE DOS PINHAIS", "SAO MANOEL DO PARANA", "SAO MATEUS DO SUL", "SAO MIGUEL DO IGUACU", "SAO PEDRO DO IGUACU", "SAO PEDRO DO IVAI", "SAO PEDRO DO PARANA", "SAO SEBASTIAO DA AMOREIRA", "SAO TOME", "SAPOPEMA", "SARANDI", "SAUDADE DO IGUACU", "SENGES", "SERRANOPOLIS DO IGUACU", "SERTANEJA", "SERTANOPOLIS", "SIQUEIRA CAMPOS", "SULINA", "TAMARANA", "TAMBOARA", "TAPEJARA", "TAPIRA", "TEIXEIRA SOARES", "TELEMACO BORBA", "TERRA BOA", "TERRA RICA", "TERRA ROXA", "TIBAGI", "TIJUCAS DO SUL", "TOLEDO", "TOMAZINA", "TRES BARRAS DO PARANA", "TUNAS DO PARANA", "TUNEIRAS DO OESTE", "TUPASSI", "TURVO", "UBIRATA", "UMUARAMA", "UNIAO DA VITORIA", "UNIFLOR", "URAI", "VENTANIA", "VERA CRUZ DO OESTE", "VERE", "VILA ALTA", "VIRMOND", "VITORINO", "WENCESLAU BRAZ", "XAMBRE" });
            estadosCidade.Add("RJ", new List<string>() { "Rio de Janeiro", "ANGRA DOS REIS", "APERIBE", "ARARUAMA", "AREAL", "ARMACAO DE BUZIOS", "ARRAIAL DO CABO", "BARRA DO PIRAI", "BARRA MANSA", "BELFORD ROXO", "BOM JARDIM", "BOM JESUS DO ITABAPOANA", "CABO FRIO", "CACHOEIRAS DE MACACU", "CAMBUCI", "CAMPOS DOS GOYTACAZES", "CANTAGALO", "CARAPEBUS", "CARDOSO MOREIRA", "CARMO", "CASIMIRO DE ABREU", "COMENDADOR LEVY GASPARIAN", "CONCEICAO DE MACABU", "CORDEIRO", "DUAS BARRAS", "DUQUE DE CAXIAS", "ENGENHEIRO PAULO DE FRONTIN", "GUAPIMIRIM", "IGUABA GRANDE", "ITABORAI", "ITAGUAI", "ITALVA", "ITAOCARA", "ITAPERUNA", "ITATIAIA", "JAPERI", "LAJE DO MURIAE", "MACAE", "MACUCO", "MAGE", "MANGARATIBA", "MARICA", "MENDES", "MESQUITA", "MIGUEL PEREIRA", "MIRACEMA", "NATIVIDADE", "NILOPOLIS", "NITEROI", "NOVA FRIBURGO", "NOVA IGUACU", "PARACAMBI", "PARAIBA DO SUL", "PARATI", "PATY DO ALFERES", "PETROPOLIS", "PINHEIRAL", "PIRAI", "PORCIUNCULA", "PORTO REAL", "QUATIS", "QUEIMADOS", "QUISSAMA", "RESENDE", "RIO BONITO", "RIO CLARO", "RIO DAS FLORES", "RIO DAS OSTRAS", "RIO DE JANEIRO", "SANTA MARIA MADALENA", "SANTO ANTONIO DE PADUA", "SAO FIDELIS", "SAO FRANCISCO DE ITABAPOANA", "SAO GONCALO", "SAO JOAO DA BARRA", "SAO JOAO DE MERITI", "SAO JOSE DE UBA", "SAO JOSE DO VALE DO RIO PRETO", "SAO PEDRO DA ALDEIA", "SAO SEBASTIAO DO ALTO", "SAPUCAIA", "SAQUAREMA", "SEROPEDICA", "SILVA JARDIM", "SUMIDOURO", "TANGUA", "TERESOPOLIS", "TRAJANO DE MORAIS", "TRES RIOS", "VALENCA", "VARRE-SAI", "VASSOURAS", "VOLTA REDONDA" });
            estadosCidade.Add("RN", new List<string>() { "RIO GRANDE DO NORTE", "ACARI", "ACU", "AFONSO BEZERRA", "AGUA NOVA", "ALEXANDRIA", "ALMINO AFONSO", "ALTO DO RODRIGUES", "ANGICOS", "ANTONIO MARTINS", "APODI", "AREIA BRANCA", "ARES", "AUGUSTO SEVERO", "BAIA FORMOSA", "BARAUNA", "BARCELONA", "BENTO FERNANDES", "BODO", "BOM JESUS", "BREJINHO", "CAICARA DO NORTE", "CAICARA DO RIO DO VENTO", "CAICO", "CAMPO REDONDO", "CANGUARETAMA", "CARAUBAS", "CARNAUBA DOS DANTAS", "CARNAUBAIS", "CEARA-MIRIM", "CERRO CORA", "CORONEL EZEQUIEL", "CORONEL JOAO PESSOA", "CRUZETA", "CURRAIS NOVOS", "DOUTOR SEVERIANO", "ENCANTO", "EQUADOR", "ESPIRITO SANTO", "EXTREMOZ", "FELIPE GUERRA", "FERNANDO PEDROZA", "FLORANIA", "FRANCISCO DANTAS", "FRUTUOSO GOMES", "GALINHOS", "GOIANINHA", "GOVERNADOR DIX-SEPT ROSADO", "GROSSOS", "GUAMARE", "IELMO MARINHO", "IPANGUACU", "IPUEIRA", "ITAJA", "ITAU", "JACANA", "JANDAIRA", "JANDUIS", "JANUARIO CICCO", "JAPI", "JARDIM DE ANGICOS", "JARDIM DE PIRANHAS", "JARDIM DO SERIDO", "JOAO CAMARA", "JOAO DIAS", "JOSE DA PENHA", "JUCURUTU", "JUNDIA", "LAGOA D'ANTA", "LAGOA DE PEDRAS", "LAGOA DE VELHOS", "LAGOA NOVA", "LAGOA SALGADA", "LAJES", "LAJES PINTADAS", "LUCRECIA", "LUIS GOMES", "MACAIBA", "MACAU", "MAJOR SALES", "MARCELINO VIEIRA", "MARTINS", "MAXARANGUAPE", "MESSIAS TARGINO", "MONTANHAS", "MONTE ALEGRE", "MONTE DAS GAMELEIRAS", "MOSSORO", "NATAL", "NISIA FLORESTA", "NOVA CRUZ", "OLHO-D'AGUA DO BORGES", "OURO BRANCO", "PARANA", "PARAU", "PARAZINHO", "PARELHAS", "PARNAMIRIM", "PASSA E FICA", "PASSAGEM", "PATU", "PAU DOS FERROS", "PEDRA GRANDE", "PEDRA PRETA", "PEDRO AVELINO", "PEDRO VELHO", "PENDENCIAS", "PILOES", "POCO BRANCO", "PORTALEGRE", "PORTO DO MANGUE", "PRESIDENTE JUSCELINO", "PUREZA", "RAFAEL FERNANDES", "RAFAEL GODEIRO", "RIACHO DA CRUZ", "RIACHO DE SANTANA", "RIACHUELO", "RIO DO FOGO", "RODOLFO FERNANDES", "RUY BARBOSA", "SANTA CRUZ", "SANTA MARIA", "SANTANA DO MATOS", "SANTANA DO SERIDO", "SANTO ANTONIO", "SAO BENTO DO NORTE", "SAO BENTO DO TRAIRI", "SAO FERNANDO", "SAO FRANCISCO DO OESTE", "SAO GONCALO DO AMARANTE", "SAO JOAO DO SABUGI", "SAO JOSE DE MIPIBU", "SAO JOSE DO CAMPESTRE", "SAO JOSE DO SERIDO", "SAO MIGUEL", "SAO MIGUEL DE TOUROS", "SAO PAULO DO POTENGI", "SAO PEDRO", "SAO RAFAEL", "SAO TOME", "SAO VICENTE", "SENADOR ELOI DE SOUZA", "SENADOR GEORGINO AVELINO", "SERRA DE SAO BENTO", "SERRA DO MEL", "SERRA NEGRA DO NORTE", "SERRINHA", "SERRINHA DOS PINTOS", "SEVERIANO MELO", "SITIO NOVO", "TABOLEIRO GRANDE", "TAIPU", "TANGARA", "TENENTE ANANIAS", "TENENTE LAURENTINO CRUZ", "TIBAU", "TIBAU DO SUL", "TIMBAUBA DOS BATISTAS", "TOUROS", "TRIUNFO POTIGUAR", "UMARIZAL", "UPANEMA", "VARZEA", "VENHA-VER", "VERA CRUZ", "VICOSA", "VILA FLOR" });
            estadosCidade.Add("RO", new List<string>() { "RONDONIA", "ALTA FLORESTA D'OESTE", "ALTO ALEGRE DO PARECIS", "ALTO PARAISO", "ALVORADA D'OESTE", "ARIQUEMES", "BURITIS", "CABIXI", "CACAULANDIA", "CACOAL", "CAMPO NOVO DE RONDONIA", "CANDEIAS DO JAMARI", "CASTANHEIRAS", "CEREJEIRAS", "CHUPINGUAIA", "COLORADO DO OESTE", "CORUMBIARA", "COSTA MARQUES", "CUJUBIM", "ESPIGAO D'OESTE", "GOVERNADOR JORGE TEIXEIRA", "GUAJARA-MIRIM", "ITAPUA DO OESTE", "JARU", "JI-PARANA", "MACHADINHO D'OESTE", "MINISTRO ANDREAZZA", "MIRANTE DA SERRA", "MONTE NEGRO", "NOVA BRASILANDIA D'OESTE", "NOVA MAMORE", "NOVA UNIAO", "NOVO HORIZONTE DO OESTE", "OURO PRETO DO OESTE", "PARECIS", "PIMENTA BUENO", "PIMENTEIRAS DO OESTE", "PORTO VELHO", "PRESIDENTE MEDICI", "PRIMAVERA DE RONDONIA", "RIO CRESPO", "ROLIM DE MOURA", "SANTA LUZIA D'OESTE", "SAO FELIPE D'OESTE", "SAO FRANCISCO DO GUAPORE", "SAO MIGUEL DO GUAPORE", "SERINGUEIRAS", "TEIXEIROPOLIS", "THEOBROMA", "URUPA", "VALE DO ANARI", "VALE DO PARAISO", "VILHENA" });
            estadosCidade.Add("RR", new List<string>() { "RORAIMA", "ALTO ALEGRE", "AMAJARI", "BOA VISTA", "BONFIM", "CANTA", "CARACARAI", "CAROEBE", "IRACEMA", "MUCAJAI", "NORMANDIA", "PACARAIMA", "RORAINOPOLIS", "SAO JOAO DA BALIZA", "SAO LUIZ", "UIRAMUTA" });
            estadosCidade.Add("RS", new List<string>() { "RIO GRANDE DO SUL", "ACEGUA", "AGUA SANTA", "AGUDO", "AJURICABA", "ALECRIM", "ALEGRETE", "ALEGRIA", "ALMIRANTE TAMANDARE DO SUL", "ALPESTRE", "ALTO ALEGRE", "ALTO FELIZ", "ALVORADA", "AMARAL FERRADOR", "AMETISTA DO SUL", "ANDRE DA ROCHA", "ANTA GORDA", "ANTONIO PRADO", "ARAMBARE", "ARARICA", "ARATIBA", "ARROIO DO MEIO", "ARROIO DO PADRE", "ARROIO DO SAL", "ARROIO DO TIGRE", "ARROIO DOS RATOS", "ARROIO GRANDE", "ARVOREZINHA", "AUGUSTO PESTANA", "AUREA", "BAGE", "BALNEARIO PINHAL", "BARAO", "BARAO DE COTEGIPE", "BARAO DO TRIUNFO", "BARRA DO GUARITA", "BARRA DO QUARAI", "BARRA DO RIBEIRO", "BARRA DO RIO AZUL", "BARRA FUNDA", "BARRACAO", "BARROS CASSAL", "BENJAMIN CONSTAN DO SUL", "BENTO GONCALVES", "BOA VISTA DAS MISSOES", "BOA VISTA DO BURICA", "BOA VISTA DO CADEADO", "BOA VISTA DO INCRA", "BOA VISTA DO SUL", "BOM JESUS", "BOM PRINCIPIO", "BOM PROGRESSO", "BOM RETIRO DO SUL", "BOQUEIRAO DO LEAO", "BOSSOROCA", "BOZANO", "BRAGA", "BROCHIER", "BUTIA", "CACAPAVA DO SUL", "CACEQUI", "CACHOEIRA DO SUL", "CACHOEIRINHA", "CACIQUE DOBLE", "CAIBATE", "CAICARA", "CAMAQUA", "CAMARGO", "CAMBARA DO SUL", "CAMPESTRE DA SERRA", "CAMPINA DAS MISSOES", "CAMPINAS DO SUL", "CAMPO BOM", "CAMPO NOVO", "CAMPOS BORGES", "CANDELARIA", "CANDIDO GODOI", "CANDIOTA", "CANELA", "CANGUCU", "CANOAS", "CANUDOS DO VALE", "CAPAO BONITO DO SUL", "CAPAO DA CANOA", "CAPAO DO CIPO", "CAPAO DO LEAO", "CAPELA DE SANTANA", "CAPITAO", "CAPIVARI DO SUL", "CARAA", "CARAZINHO", "CARLOS BARBOSA", "CARLOS GOMES", "CASCA", "CASEIROS", "CATUIPE", "CAXIAS DO SUL", "CENTENARIO", "CERRITO", "CERRO BRANCO", "CERRO GRANDE", "CERRO GRANDE DO SUL", "CERRO LARGO", "CHAPADA", "CHARQUEADAS", "CHARRUA", "CHIAPETA", "CHUI", "CHUVISCA", "CIDREIRA", "CIRIACO", "COLINAS", "COLORADO", "CONDOR", "CONSTANTINA", "COQUEIRO BAIXO", "COQUEIROS DO SUL", "CORONEL BARROS", "CORONEL BICACO", "CORONEL PILAR", "COTIPORA", "COXILHA", "CRISSIUMAL", "CRISTAL", "CRISTAL DO SUL", "CRUZ ALTA", "CRUZALTENSE", "CRUZEIRO DO SUL", "DAVID CANABARRO", "DERRUBADAS", "DEZESSEIS DE NOVEMBRO", "DILERMANDO DE AGUIAR", "DOIS IRMAOS", "DOIS IRMAOS DAS MISSOES", "DOIS LAJEADOS", "DOM FELICIANO", "DOM PEDRITO", "DOM PEDRO DE ALCANTARA", "DONA FRANCISCA", "DOUTOR MAURICIO CARDOSO", "DOUTOR RICARDO", "ELDORADO DO SUL", "ENCANTADO", "ENCRUZILHADA DO SUL", "ENGENHO VELHO", "ENTRE RIOS DO SUL", "ENTRE-IJUIS", "EREBANGO", "ERECHIM", "ERNESTINA", "ERVAL GRANDE", "ERVAL SECO", "ESMERALDA", "ESPERANCA DO SUL", "ESPUMOSO", "ESTACAO", "ESTANCIA VELHA", "ESTEIO", "ESTRELA", "ESTRELA VELHA", "EUGENIO DE CASTRO", "FAGUNDES VARELA", "FARROUPILHA", "FAXINAL DO SOTURNO", "FAXINALZINHO", "FAZENDA VILANOVA", "FELIZ", "FLORES DA CUNHA", "FLORIANO PEIXOTO", "FONTOURA XAVIER", "FORMIGUEIRO", "FORQUETINHA", "FORTALEZA DOS VALOS", "FREDERICO WESTPHALEN", "GARIBALDI", "GARRUCHOS", "GAURAMA", "GENERAL CAMARA", "GENTIL", "GETULIO VARGAS", "GIRUA", "GLORINHA", "GRAMADO", "GRAMADO DOS LOUREIROS", "GRAMADO XAVIER", "GRAVATAI", "GUABIJU", "GUAIBA", "GUAPORE", "GUARANI DAS MISSOES", "HARMONIA", "HERVAL", "HERVEIRAS", "HORIZONTINA", "HULHA NEGRA", "HUMAITA", "IBARAMA", "IBIACA", "IBIRAIARAS", "IBIRAPUITA", "IBIRUBA", "IGREJINHA", "IJUI", "ILOPOLIS", "IMBE", "IMIGRANTE", "INDEPENDENCIA", "INHACORA", "IPE", "IPIRANGA DO SUL", "IRAI", "ITAARA", "ITACURUBI", "ITAPUCA", "ITAQUI", "ITATI", "ITATIBA DO SUL", "IVORA", "IVOTI", "JABOTICABA", "JACUIZINHO", "JACUTINGA", "JAGUARAO", "JAGUARI", "JAQUIRANA", "JARI", "JOIA", "JULIO DE CASTILHOS", "LAGOA BONITA DO SUL", "LAGOA DOS TRES CANTOS", "LAGOA VERMELHA", "LAGOAO", "LAJEADO", "LAJEADO DO BUGRE", "LAVRAS DO SUL", "LIBERATO SALZANO", "LINDOLFO COLLOR", "LINHA NOVA", "MACAMBARA", "MACHADINHO", "MAMPITUBA", "MANOEL VIANA", "MAQUINE", "MARATA", "MARAU", "MARCELINO RAMOS", "MARIANA PIMENTEL", "MARIANO MORO", "MARQUES DE SOUZA", "MATA", "MATO CASTELHANO", "MATO LEITAO", "MATO QUEIMADO", "MAXIMILIANO DE ALMEIDA", "MINAS DO LEAO", "MIRAGUAI", "MONTAURI", "MONTE ALEGRE DOS CAMPOS", "MONTE BELO DO SUL", "MONTENEGRO", "MORMACO", "MORRINHOS DO SUL", "MORRO REDONDO", "MORRO REUTER", "MOSTARDAS", "MUCUM", "MUITOS CAPOES", "MULITERNO", "NAO-ME-TOQUE", "NICOLAU VERGUEIRO", "NONOAI", "NOVA ALVORADA", "NOVA ARACA", "NOVA BASSANO", "NOVA BOA VISTA", "NOVA BRESCIA", "NOVA CANDELARIA", "NOVA ESPERANCA DO SUL", "NOVA HARTZ", "NOVA PADUA", "NOVA PALMA", "NOVA PETROPOLIS", "NOVA PRATA", "NOVA RAMADA", "NOVA ROMA DO SUL", "NOVA SANTA RITA", "NOVO BARREIRO", "NOVO CABRAIS", "NOVO HAMBURGO", "NOVO MACHADO", "NOVO TIRADENTES", "NOVO XINGU", "OSORIO", "PAIM FILHO", "PALMARES DO SUL", "PALMEIRA DAS MISSOES", "PALMITINHO", "PANAMBI", "PANTANO GRANDE", "PARAI", "PARAISO DO SUL", "PARECI NOVO", "PAROBE", "PASSA SETE", "PASSO DO SOBRADO", "PASSO FUNDO", "PAULO BENTO", "PAVERAMA", "PEDRAS ALTAS", "PEDRO OSORIO", "PEJUCARA", "PELOTAS", "PICADA CAFE", "PINHAL", "PINHAL DA SERRA", "PINHAL GRANDE", "PINHEIRINHO DO VALE", "PINHEIRO MACHADO", "PIRAPO", "PIRATINI", "PLANALTO", "POCO DAS ANTAS", "PONTAO", "PONTE PRETA", "PORTAO", "PORTO ALEGRE", "PORTO LUCENA", "PORTO MAUA", "PORTO VERA CRUZ", "PORTO XAVIER", "POUSO NOVO", "PRESIDENTE LUCENA", "PROGRESSO", "PROTASIO ALVES", "PUTINGA", "QUARAI", "QUATRO IRMAOS", "QUEVEDOS", "QUINZE DE NOVEMBRO", "REDENTORA", "RELVADO", "RESTINGA SECA", "RIO DOS INDIOS", "RIO GRANDE", "RIO PARDO", "RIOZINHO", "ROCA SALES", "RODEIO BONITO", "ROLADOR", "ROLANTE", "RONDA ALTA", "RONDINHA", "ROQUE GONZALES", "ROSARIO DO SUL", "SAGRADA FAMILIA", "SALDANHA MARINHO", "SALTO DO JACUI", "SALVADOR DAS MISSOES", "SALVADOR DO SUL", "SANANDUVA", "SANTA BARBARA DO SUL", "SANTA CECILIA DO SUL", "SANTA CLARA DO SUL", "SANTA CRUZ DO SUL", "SANTA MARGARIDA DO SUL", "SANTA MARIA", "SANTA MARIA DO HERVAL", "SANTA ROSA", "SANTA TEREZA", "SANTA VITORIA DO PALMAR", "SANTANA DA BOA VISTA", "SANTANA DO LIVRAMENTO", "SANTIAGO", "SANTO ANGELO", "SANTO ANTONIO DA PATRULHA", "SANTO ANTONIO DAS MISSOES", "SANTO ANTONIO DO PALMA", "SANTO ANTONIO DO PLANALTO", "SANTO AUGUSTO", "SANTO CRISTO", "SANTO EXPEDITO DO SUL", "SAO BORJA", "SAO DOMINGOS DO SUL", "SAO FRANCISCO DE ASSIS", "SAO FRANCISCO DE PAULA", "SAO GABRIEL", "SAO JERONIMO", "SAO JOAO DA URTIGA", "SAO JOAO DO POLESINE", "SAO JORGE", "SAO JOSE DAS MISSOES", "SAO JOSE DO HERVAL", "SAO JOSE DO HORTENCIO", "SAO JOSE DO INHACORA", "SAO JOSE DO NORTE", "SAO JOSE DO OURO", "SAO JOSE DO SUL", "SAO JOSE DOS AUSENTES", "SAO LEOPOLDO", "SAO LOURENCO DO SUL", "SAO LUIZ GONZAGA", "SAO MARCOS", "SAO MARTINHO", "SAO MARTINHO DA SERRA", "SAO MIGUEL DAS MISSOES", "SAO NICOLAU", "SAO PAULO DAS MISSOES", "SAO PEDRO DA SERRA", "SAO PEDRO DAS MISSOES", "SAO PEDRO DO BUTIA", "SAO PEDRO DO SUL", "SAO SEBASTIAO DO CAI", "SAO SEPE", "SAO VALENTIM", "SAO VALENTIM DO SUL", "SAO VALERIO DO SUL", "SAO VENDELINO", "SAO VICENTE DO SUL", "SAPIRANGA", "SAPUCAIA DO SUL", "SARANDI", "SEBERI", "SEDE NOVA", "SEGREDO", "SELBACH", "SENADOR SALGADO FILHO", "SENTINELA DO SUL", "SERAFINA CORREA", "SERIO", "SERTAO", "SERTAO SANTANA", "SETE DE SETEMBRO", "SEVERIANO DE ALMEIDA", "SILVEIRA MARTINS", "SINIMBU", "SOBRADINHO", "SOLEDADE", "TABAI", "TAPEJARA", "TAPERA", "TAPES", "TAQUARA", "TAQUARI", "TAQUARUCU DO SUL", "TAVARES", "TENENTE PORTELA", "TERRA DE AREIA", "TEUTONIA", "TIO HUGO", "TIRADENTES DO SUL", "TOROPI", "TORRES", "TRAMANDAI", "TRAVESSEIRO", "TRES ARROIOS", "TRES CACHOEIRAS", "TRES COROAS", "TRES DE MAIO", "TRES FORQUILHAS", "TRES PALMEIRAS", "TRES PASSOS", "TRINDADE DO SUL", "TRIUNFO", "TUCUNDUVA", "TUNAS", "TUPANCI DO SUL", "TUPANCIRETA", "TUPANDI", "TUPARENDI", "TURUCU", "UBIRETAMA", "UNIAO DA SERRA", "UNISTALDA", "URUGUAIANA", "VACARIA", "VALE DO SOL", "VALE REAL", "VALE VERDE", "VANINI", "VENANCIO AIRES", "VERA CRUZ", "VERANOPOLIS", "VESPASIANO CORREA", "VIADUTOS", "VIAMAO", "VICENTE DUTRA", "VICTOR GRAEFF", "VILA FLORES", "VILA LANGARO", "VILA MARIA", "VILA NOVA DO SUL", "VISTA ALEGRE", "VISTA ALEGRE DO PRATA", "VISTA GAUCHA", "VITORIA DAS MISSOES", "WESTFALIA", "XANGRI-LA" });
            estadosCidade.Add("SC", new List<string>() { "SANTA CATARINA", "ABDON BATISTA", "ABELARDO LUZ", "AGROLANDIA", "AGRONOMICA", "AGUA DOCE", "AGUAS DE CHAPECO", "AGUAS FRIAS", "AGUAS MORNAS", "ALFREDO WAGNER", "ALTO BELA VISTA", "ANCHIETA", "ANGELINA", "ANITA GARIBALDI", "ANITAPOLIS", "ANTONIO CARLOS", "APIUNA", "ARABUTA", "ARAQUARI", "ARARANGUA", "ARMAZEM", "ARROIO TRINTA", "ARVOREDO", "ASCURRA", "ATALANTA", "AURORA", "BALNEARIO ARROIO DO SILVA", "BALNEARIO BARRA DO SUL", "BALNEARIO CAMBORIU", "BALNEARIO GAIVOTA", "BANDEIRANTE", "BARRA BONITA", "BARRA VELHA", "BELA VISTA DO TOLDO", "BELMONTE", "BENEDITO NOVO", "BIGUACU", "BLUMENAU", "BOCAINA DO SUL", "BOM JARDIM DA SERRA", "BOM JESUS", "BOM JESUS DO OESTE", "BOM RETIRO", "BOMBINHAS", "BOTUVERA", "BRACO DO NORTE", "BRACO DO TROMBUDO", "BRUNOPOLIS", "BRUSQUE", "CACADOR", "CAIBI", "CALMON", "CAMBORIU", "CAMPO ALEGRE", "CAMPO BELO DO SUL", "CAMPO ERE", "CAMPOS NOVOS", "CANELINHA", "CANOINHAS", "CAPAO ALTO", "CAPINZAL", "CAPIVARI DE BAIXO", "CATANDUVAS", "CAXAMBU DO SUL", "CELSO RAMOS", "CERRO NEGRO", "CHAPADAO DO LAGEADO", "CHAPECO", "COCAL DO SUL", "CONCORDIA", "CORDILHEIRA ALTA", "CORONEL FREITAS", "CORONEL MARTINS", "CORREIA PINTO", "CORUPA", "CRICIUMA", "CUNHA PORA", "CUNHATAI", "CURITIBANOS", "DESCANSO", "DIONISIO CERQUEIRA", "DONA EMMA", "DOUTOR PEDRINHO", "ENTRE RIOS", "ERMO", "ERVAL VELHO", "FAXINAL DOS GUEDES", "FLOR DO SERTAO", "FLORIANOPOLIS", "FORMOSA DO SUL", "FORQUILHINHA", "FRAIBURGO", "FREI ROGERIO", "GALVAO", "GAROPABA", "GARUVA", "GASPAR", "GOVERNADOR CELSO RAMOS", "GRAO PARA", "GRAVATAL", "GUABIRUBA", "GUARACIABA", "GUARAMIRIM", "GUARUJA DO SUL", "GUATAMBU", "HERVAL D'OESTE", "IBIAM", "IBICARE", "IBIRAMA", "ICARA", "ILHOTA", "IMARUI", "IMBITUBA", "IMBUIA", "INDAIAL", "IOMERE", "IPIRA", "IPORA DO OESTE", "IPUACU", "IPUMIRIM", "IRACEMINHA", "IRANI", "IRATI", "IRINEOPOLIS", "ITA", "ITAIOPOLIS", "ITAJAI", "ITAPEMA", "ITAPIRANGA", "ITAPOA", "ITUPORANGA", "JABORA", "JACINTO MACHADO", "JAGUARUNA", "JARAGUA DO SUL", "JARDINOPOLIS", "JOACABA", "JOINVILLE", "JOSE BOITEUX", "JUPIA", "LACERDOPOLIS", "LAGES", "LAGUNA", "LAJEADO GRANDE", "LAURENTINO", "LAURO MULLER", "LEBON REGIS", "LEOBERTO LEAL", "LINDOIA DO SUL", "LONTRAS", "LUIZ ALVES", "LUZERNA", "MACIEIRA", "MAFRA", "MAJOR GERCINO", "MAJOR VIEIRA", "MARACAJA", "MARAVILHA", "MAREMA", "MASSARANDUBA", "MATOS COSTA", "MELEIRO", "MIRIM DOCE", "MODELO", "MONDAI", "MONTE CARLO", "MONTE CASTELO", "MORRO DA FUMACA", "MORRO GRANDE", "NAVEGANTES", "NOVA ERECHIM", "NOVA ITABERABA", "NOVA TRENTO", "NOVA VENEZA", "NOVO HORIZONTE", "ORLEANS", "OTACILIO COSTA", "OURO", "OURO VERDE", "PAIAL", "PAINEL", "PALHOCA", "PALMA SOLA", "PALMEIRA", "PALMITOS", "PAPANDUVA", "PARAISO", "PASSO DE TORRES", "PASSOS MAIA", "PAULO LOPES", "PEDRAS GRANDES", "PENHA", "PERITIBA", "PETROLANDIA", "PICARRAS", "PINHALZINHO", "PINHEIRO PRETO", "PIRATUBA", "PLANALTO ALEGRE", "POMERODE", "PONTE ALTA", "PONTE ALTA DO NORTE", "PONTE SERRADA", "PORTO BELO", "PORTO UNIAO", "POUSO REDONDO", "PRAIA GRANDE", "PRESIDENTE CASTELO BRANCO", "PRESIDENTE GETULIO", "PRESIDENTE NEREU", "PRINCESA", "QUILOMBO", "RANCHO QUEIMADO", "RIO DAS ANTAS", "RIO DO CAMPO", "RIO DO OESTE", "RIO DO SUL", "RIO DOS CEDROS", "RIO FORTUNA", "RIO NEGRINHO", "RIO RUFINO", "RIQUEZA", "RODEIO", "ROMELANDIA", "SALETE", "SALTINHO", "SALTO VELOSO", "SANGAO", "SANTA CECILIA", "SANTA HELENA", "SANTA ROSA DE LIMA", "SANTA ROSA DO SUL", "SANTA TEREZINHA", "SANTA TEREZINHA DO PROGRESSO", "SANTIAGO DO SUL", "SANTO AMARO DA IMPERATRIZ", "SAO BENTO DO SUL", "SAO BERNARDINO", "SAO BONIFACIO", "SAO CARLOS", "SAO CRISTOVAO DO SUL", "SAO DOMINGOS", "SAO FRANCISCO DO SUL", "SAO JOAO BATISTA", "SAO JOAO DO ITAPERIU", "SAO JOAO DO OESTE", "SAO JOAO DO SUL", "SAO JOAQUIM", "SAO JOSE", "SAO JOSE DO CEDRO", "SAO JOSE DO CERRITO", "SAO LOURENCO DO OESTE", "SAO LUDGERO", "SAO MARTINHO", "SAO MIGUEL DA BOA VISTA", "SAO MIGUEL DO OESTE", "SAO PEDRO DE ALCANTARA", "SAUDADES", "SCHROEDER", "SEARA", "SERRA ALTA", "SIDEROPOLIS", "SOMBRIO", "SUL BRASIL", "TAIO", "TANGARA", "TIGRINHOS", "TIJUCAS", "TIMBE DO SUL", "TIMBO", "TIMBO GRANDE", "TRES BARRAS", "TREVISO", "TREZE DE MAIO", "TREZE TILIAS", "TROMBUDO CENTRAL", "TUBARAO", "TUNAPOLIS", "TURVO", "UNIAO DO OESTE", "URUBICI", "URUPEMA", "URUSSANGA", "VARGEAO", "VARGEM", "VARGEM BONITA", "VIDAL RAMOS", "VIDEIRA", "VITOR MEIRELES", "WITMARSUM", "XANXERE", "XAVANTINA", "XAXIM", "ZORTEA" });
            estadosCidade.Add("SE", new List<string>() { "SERGIPE", "AMPARO DE SAO FRANCISCO", "AQUIDABA", "ARACAJU", "ARAUA", "AREIA BRANCA", "BARRA DOS COQUEIROS", "BOQUIM", "BREJO GRANDE", "CAMPO DO BRITO", "CANHOBA", "CANINDE DE SAO FRANCISCO", "CAPELA", "CARIRA", "CARMOPOLIS", "CEDRO DE SAO JOAO", "CRISTINAPOLIS", "CUMBE", "DIVINA PASTORA", "ESTANCIA", "FEIRA NOVA", "FREI PAULO", "GARARU", "GENERAL MAYNARD", "GRACHO CARDOSO", "ILHA DAS FLORES", "INDIAROBA", "ITABAIANA", "ITABAIANINHA", "ITABI", "ITAPORANGA D'AJUDA", "JAPARATUBA", "JAPOATA", "LAGARTO", "LARANJEIRAS", "MACAMBIRA", "MALHADA DOS BOIS", "MALHADOR", "MARUIM", "MOITA BONITA", "MONTE ALEGRE DE SERGIPE", "MURIBECA", "NEOPOLIS", "NOSSA SENHORA APARECIDA", "NOSSA SENHORA DA GLORIA", "NOSSA SENHORA DAS DORES", "NOSSA SENHORA DE LOURDES", "NOSSA SENHORA DO SOCORRO", "PACATUBA", "PEDRA MOLE", "PEDRINHAS", "PINHAO", "PIRAMBU", "POCO REDONDO", "POCO VERDE", "PORTO DA FOLHA", "PROPRIA", "RIACHAO DO DANTAS", "RIACHUELO", "RIBEIROPOLIS", "ROSARIO DO CATETE", "SALGADO", "SANTA LUZIA DO ITANHY", "SANTA ROSA DE LIMA", "SANTANA DO SAO FRANCISCO", "SANTO AMARO DAS BROTAS", "SAO CRISTOVAO", "SAO DOMINGOS", "SAO FRANCISCO", "SAO MIGUEL DO ALEIXO", "SIMAO DIAS", "SIRIRI", "TELHA", "TOBIAS BARRETO", "TOMAR DO GERU", "UMBAUBA" });
            estadosCidade.Add("SP", new List<string>() { "SAO PAULO", "ADAMANTINA", "ADOLFO", "AGUAI", "AGUAS DA PRATA", "AGUAS DE LINDOIA", "AGUAS DE SANTA BARBARA", "AGUAS DE SAO PEDRO", "AGUDOS", "ALAMBARI", "ALFREDO MARCONDES", "ALTAIR", "ALTINOPOLIS", "ALTO ALEGRE", "ALUMINIO", "ALVARES FLORENCE", "ALVARES MACHADO", "ALVARO DE CARVALHO", "ALVINLANDIA", "AMERICANA", "AMERICO BRASILIENSE", "AMERICO DE CAMPOS", "AMPARO", "ANALANDIA", "ANDRADINA", "ANGATUBA", "ANHEMBI", "ANHUMAS", "APARECIDA", "APARECIDA D'OESTE", "APIAI", "ARACARIGUAMA", "ARACATUBA", "ARACOIABA DA SERRA", "ARAMINA", "ARANDU", "ARAPEI", "ARARAQUARA", "ARARAS", "ARCO-IRIS", "AREALVA", "AREIAS", "AREIOPOLIS", "ARIRANHA", "ARTUR NOGUEIRA", "ARUJA", "ASPASIA", "ASSIS", "ATIBAIA", "AURIFLAMA", "AVAI", "AVANHANDAVA", "AVARE", "BADY BASSITT", "BALBINOS", "BALSAMO", "BANANAL", "BARAO DE ANTONINA", "BARBOSA", "BARIRI", "BARRA BONITA", "BARRA DO CHAPEU", "BARRA DO TURVO", "BARRETOS", "BARRINHA", "BARUERI", "BASTOS", "BATATAIS", "BAURU", "BEBEDOURO", "BENTO DE ABREU", "BERNARDINO DE CAMPOS", "BERTIOGA", "BILAC", "BIRIGUI", "BIRITIBA-MIRIM", "BOA ESPERANCA DO SUL", "BOCAINA", "BOFETE", "BOITUVA", "BOM JESUS DOS PERDOES", "BOM SUCESSO DE ITARARE", "BORA", "BORACEIA", "BORBOREMA", "BOREBI", "BOTUCATU", "BRAGANCA PAULISTA", "BRAUNA", "BREJO ALEGRE", "BRODOWSKI", "BROTAS", "BURI", "BURITAMA", "BURITIZAL", "CABRALIA PAULISTA", "CABREUVA", "CACAPAVA", "CACHOEIRA PAULISTA", "CACONDE", "CAFELANDIA", "CAIABU", "CAIEIRAS", "CAIUA", "CAJAMAR", "CAJATI", "CAJOBI", "CAJURU", "CAMPINA DO MONTE ALEGRE", "CAMPINAS", "CAMPO LIMPO PAULISTA", "CAMPOS DO JORDAO", "CAMPOS NOVOS PAULISTA", "CANANEIA", "CANAS", "CANDIDO MOTA", "CANDIDO RODRIGUES", "CANITAR", "CAPAO BONITO", "CAPELA DO ALTO", "CAPIVARI", "CARAGUATATUBA", "CARAPICUIBA", "CARDOSO", "CASA BRANCA", "CASSIA DOS COQUEIROS", "CASTILHO", "CATANDUVA", "CATIGUA", "CEDRAL", "CERQUEIRA CESAR", "CERQUILHO", "CESARIO LANGE", "CHARQUEADA", "CHAVANTES", "CLEMENTINA", "COLINA", "COLOMBIA", "CONCHAL", "CONCHAS", "CORDEIROPOLIS", "COROADOS", "CORONEL MACEDO", "CORUMBATAI", "COSMOPOLIS", "COSMORAMA", "COTIA", "CRAVINHOS", "CRISTAIS PAULISTA", "CRUZALIA", "CRUZEIRO", "CUBATAO", "CUNHA", "DESCALVADO", "DIADEMA", "DIRCE REIS", "DIVINOLANDIA", "DOBRADA", "DOIS CORREGOS", "DOLCINOPOLIS", "DOURADO", "DRACENA", "DUARTINA", "DUMONT", "ECHAPORA", "ELDORADO", "ELIAS FAUSTO", "ELISIARIO", "EMBAUBA", "EMBU", "EMBU-GUACU", "EMILIANOPOLIS", "ENGENHEIRO COELHO", "ESPIRITO SANTO DO PINHAL", "ESPIRITO SANTO DO TURVO", "ESTIVA GERBI", "ESTRELA D'OESTE", "ESTRELA DO NORTE", "EUCLIDES DA CUNHA PAULISTA", "FARTURA", "FERNANDO PRESTES", "FERNANDOPOLIS", "FERNAO", "FERRAZ DE VASCONCELOS", "FLORA RICA", "FLOREAL", "FLORINIA", "FLORIDA PAULISTA", "FRANCA", "FRANCISCO MORATO", "FRANCO DA ROCHA", "GABRIEL MONTEIRO", "GALIA", "GARCA", "GASTAO VIDIGAL", "GAVIAO PEIXOTO", "GENERAL SALGADO", "GETULINA", "GLICERIO", "GUAICARA", "GUAIMBE", "GUAIRA", "GUAPIACU", "GUAPIARA", "GUARA", "GUARACAI", "GUARACI", "GUARANI D'OESTE", "GUARANTA", "GUARARAPES", "GUARAREMA", "GUARATINGUETA", "GUAREI", "GUARIBA", "GUARUJA", "GUARULHOS", "GUATAPARA", "GUZOLANDIA", "HERCULANDIA", "HOLAMBRA", "HORTOLANDIA", "IACANGA", "IACRI", "IARAS", "IBATE", "IBIRA", "IBIRAREMA", "IBITINGA", "IBIUNA", "ICEM", "IEPE", "IGARACU DO TIETE", "IGARAPAVA", "IGARATA", "IGUAPE", "ILHA COMPRIDA", "ILHA SOLTEIRA", "ILHABELA", "INDAIATUBA", "INDIANA", "INDIAPORA", "INUBIA PAULISTA", "IPAUCU", "IPERO", "IPEUNA", "IPIGUA", "IPORANGA", "IPUA", "IRACEMAPOLIS", "IRAPUA", "IRAPURU", "ITABERA", "ITAI", "ITAJOBI", "ITAJU", "ITANHAEM", "ITAOCA", "ITAPECERICA DA SERRA", "ITAPETININGA", "ITAPEVA", "ITAPEVI", "ITAPIRA", "ITAPIRAPUA PAULISTA", "ITAPOLIS", "ITAPORANGA", "ITAPUI", "ITAPURA", "ITAQUAQUECETUBA", "ITARARE", "ITARIRI", "ITATIBA", "ITATINGA", "ITIRAPINA", "ITIRAPUA", "ITOBI", "ITU", "ITUPEVA", "ITUVERAVA", "JABORANDI", "JABOTICABAL", "JACAREI", "JACI", "JACUPIRANGA", "JAGUARIUNA", "JALES", "JAMBEIRO", "JANDIRA", "JARDINOPOLIS", "JARINU", "JAU", "JERIQUARA", "JOANOPOLIS", "JOAO RAMALHO", "JOSE BONIFACIO", "JULIO MESQUITA", "JUMIRIM", "JUNDIAI", "JUNQUEIROPOLIS", "JUQUIA", "JUQUITIBA", "LAGOINHA", "LARANJAL PAULISTA", "LAVINIA", "LAVRINHAS", "LEME", "LENCOIS PAULISTA", "LIMEIRA", "LINDOIA", "LINS", "LORENA", "LOURDES", "LOUVEIRA", "LUCELIA", "LUCIANOPOLIS", "LUIS ANTONIO", "LUIZIANIA", "LUPERCIO", "LUTECIA", "MACATUBA", "MACAUBAL", "MACEDONIA", "MAGDA", "MAIRINQUE", "MAIRIPORA", "MANDURI", "MARABA PAULISTA", "MARACAI", "MARAPOAMA", "MARIAPOLIS", "MARILIA", "MARINOPOLIS", "MARTINOPOLIS", "MATAO", "MAUA", "MENDONCA", "MERIDIANO", "MESOPOLIS", "MIGUELOPOLIS", "MINEIROS DO TIETE", "MIRA ESTRELA", "MIRACATU", "MIRANDOPOLIS", "MIRANTE DO PARANAPANEMA", "MIRASSOL", "MIRASSOLANDIA", "MOCOCA", "MOGI DAS CRUZES", "MOGI-GUACU", "MOGI-MIRIM", "MOMBUCA", "MONCOES", "MONGAGUA", "MONTE ALEGRE DO SUL", "MONTE ALTO", "MONTE APRAZIVEL", "MONTE AZUL PAULISTA", "MONTE CASTELO", "MONTE MOR", "MONTEIRO LOBATO", "MORRO AGUDO", "MORUNGABA", "MOTUCA", "MURUTINGA DO SUL", "NANTES", "NARANDIBA", "NATIVIDADE DA SERRA", "NAZARE PAULISTA", "NEVES PAULISTA", "NHANDEARA", "NIPOA", "NOVA ALIANCA", "NOVA CAMPINA", "NOVA CANAA PAULISTA", "NOVA CASTILHO", "NOVA EUROPA", "NOVA GRANADA", "NOVA GUATAPORANGA", "NOVA INDEPENDENCIA", "NOVA LUZITANIA", "NOVA ODESSA", "NOVAIS", "NOVO HORIZONTE", "NUPORANGA", "OCAUCU", "OLEO", "OLIMPIA", "ONDA VERDE", "ORIENTE", "ORINDIUVA", "ORLANDIA", "OSASCO", "OSCAR BRESSANE", "OSVALDO CRUZ", "OURINHOS", "OURO VERDE", "OUROESTE", "PACAEMBU", "PALESTINA", "PALMARES PAULISTA", "PALMEIRA D'OESTE", "PALMITAL", "PANORAMA", "PARAGUACU PAULISTA", "PARAIBUNA", "PARAISO", "PARANAPANEMA", "PARANAPUA", "PARAPUA", "PARDINHO", "PARIQUERA-ACU", "PARISI", "PATROCINIO PAULISTA", "PAULICEIA", "PAULINIA", "PAULISTANIA", "PAULO DE FARIA", "PEDERNEIRAS", "PEDRA BELA", "PEDRANOPOLIS", "PEDREGULHO", "PEDREIRA", "PEDRINHAS PAULISTA", "PEDRO DE TOLEDO", "PENAPOLIS", "PEREIRA BARRETO", "PEREIRAS", "PERUIBE", "PIACATU", "PIEDADE", "PILAR DO SUL", "PINDAMONHANGABA", "PINDORAMA", "PINHALZINHO", "PIQUEROBI", "PIQUETE", "PIRACAIA", "PIRACICABA", "PIRAJU", "PIRAJUI", "PIRANGI", "PIRAPORA DO BOM JESUS", "PIRAPOZINHO", "PIRASSUNUNGA", "PIRATININGA", "PITANGUEIRAS", "PLANALTO", "PLATINA", "POA", "POLONI", "POMPEIA", "PONGAI", "PONTAL", "PONTALINDA", "PONTES GESTAL", "POPULINA", "PORANGABA", "PORTO FELIZ", "PORTO FERREIRA", "POTIM", "POTIRENDABA", "PRACINHA", "PRADOPOLIS", "PRAIA GRANDE", "PRATANIA", "PRESIDENTE ALVES", "PRESIDENTE BERNARDES", "PRESIDENTE EPITACIO", "PRESIDENTE PRUDENTE", "PRESIDENTE VENCESLAU", "PROMISSAO", "QUADRA", "QUATA", "QUEIROZ", "QUELUZ", "QUINTANA", "RAFARD", "RANCHARIA", "REDENCAO DA SERRA", "REGENTE FEIJO", "REGINOPOLIS", "REGISTRO", "RESTINGA", "RIBEIRA", "RIBEIRAO BONITO", "RIBEIRAO BRANCO", "RIBEIRAO CORRENTE", "RIBEIRAO DO SUL", "RIBEIRAO DOS INDIOS", "RIBEIRAO GRANDE", "RIBEIRAO PIRES", "RIBEIRAO PRETO", "RIFAINA", "RINCAO", "RINOPOLIS", "RIO CLARO", "RIO DAS PEDRAS", "RIO GRANDE DA SERRA", "RIOLANDIA", "RIVERSUL", "ROSANA", "ROSEIRA", "RUBIACEA", "RUBINEIA", "SABINO", "SAGRES", "SALES", "SALES OLIVEIRA", "SALESOPOLIS", "SALMOURAO", "SALTINHO", "SALTO", "SALTO DE PIRAPORA", "SALTO GRANDE", "SANDOVALINA", "SANTA ADELIA", "SANTA ALBERTINA", "SANTA BARBARA D'OESTE", "SANTA BRANCA", "SANTA CLARA D'OESTE", "SANTA CRUZ DA CONCEICAO", "SANTA CRUZ DA ESPERANCA", "SANTA CRUZ DAS PALMEIRAS", "SANTA CRUZ DO RIO PARDO", "SANTA ERNESTINA", "SANTA FE DO SUL", "SANTA GERTRUDES", "SANTA ISABEL", "SANTA LUCIA", "SANTA MARIA DA SERRA", "SANTA MERCEDES", "SANTA RITA D'OESTE", "SANTA RITA DO PASSA QUATRO", "SANTA ROSA DE VITERBO", "SANTA SALETE", "SANTANA DA PONTE PENSA", "SANTANA DE PARNAIBA", "SANTO ANASTACIO", "SANTO ANDRE", "SANTO ANTONIO DA ALEGRIA", "SANTO ANTONIO DE POSSE", "SANTO ANTONIO DO ARACANGUA", "SANTO ANTONIO DO JARDIM", "SANTO ANTONIO DO PINHAL", "SANTO EXPEDITO", "SANTOPOLIS DO AGUAPEI", "SANTOS", "SAO BENTO DO SAPUCAI", "SAO BERNARDO DO CAMPO", "SAO CAETANO DO SUL", "SAO CARLOS", "SAO FRANCISCO", "SAO JOAO DA BOA VISTA", "SAO JOAO DAS DUAS PONTES", "SAO JOAO DE IRACEMA", "SAO JOAO DO PAU D'ALHO", "SAO JOAQUIM DA BARRA", "SAO JOSE DA BELA VISTA", "SAO JOSE DO BARREIRO", "SAO JOSE DO RIO PARDO", "SAO JOSE DO RIO PRETO", "SAO JOSE DOS CAMPOS", "SAO LOURENCO DA SERRA", "SAO LUIS DO PARAITINGA", "SAO MANUEL", "SAO MIGUEL ARCANJO", "SAO PAULO", "SAO PEDRO", "SAO PEDRO DO TURVO", "SAO ROQUE", "SAO SEBASTIAO", "SAO SEBASTIAO DA GRAMA", "SAO SIMAO", "SAO VICENTE", "SARAPUI", "SARUTAIA", "SEBASTIANOPOLIS DO SUL", "SERRA AZUL", "SERRA NEGRA", "SERRANA", "SERTAOZINHO", "SETE BARRAS", "SEVERINIA", "SILVEIRAS", "SOCORRO", "SOROCABA", "SUD MENNUCCI", "SUMARE", "SUZANAPOLIS", "SUZANO", "TABAPUA", "TABATINGA", "TABOAO DA SERRA", "TACIBA", "TAGUAI", "TAIACU", "TAIUVA", "TAMBAU", "TANABI", "TAPIRAI", "TAPIRATIBA", "TAQUARAL", "TAQUARITINGA", "TAQUARITUBA", "TAQUARIVAI", "TARABAI", "TARUMA", "TATUI", "TAUBATE", "TEJUPA", "TEODORO SAMPAIO", "TERRA ROXA", "TIETE", "TIMBURI", "TORRE DE PEDRA", "TORRINHA", "TRABIJU", "TREMEMBE", "TRES FRONTEIRAS", "TUIUTI", "TUPA", "TUPI PAULISTA", "TURIUBA", "TURMALINA", "UBARANA", "UBATUBA", "UBIRAJARA", "UCHOA", "UNIAO PAULISTA", "URANIA", "URU", "URUPES", "VALENTIM GENTIL", "VALINHOS", "VALPARAISO", "VARGEM", "VARGEM GRANDE DO SUL", "VARGEM GRANDE PAULISTA", "VARZEA PAULISTA", "VERA CRUZ", "VINHEDO", "VIRADOURO", "VISTA ALEGRE DO ALTO", "VITORIA BRASIL", "VOTORANTIM", "VOTUPORANGA", "ZACARIAS" });
            estadosCidade.Add("TO", new List<string>() { "TOCANTINS", "ABREULANDIA", "AGUIARNOPOLIS", "ALIANCA DO TOCANTINS", "ALMAS", "ALVORADA", "ANANAS", "ANGICO", "APARECIDA DO RIO NEGRO", "ARAGOMINAS", "ARAGUACEMA", "ARAGUACU", "ARAGUAINA", "ARAGUANA", "ARAGUATINS", "ARAPOEMA", "ARRAIAS", "AUGUSTINOPOLIS", "AURORA DO TOCANTINS", "AXIXA DO TOCANTINS", "BABACULANDIA", "BANDEIRANTES DO TOCANTINS", "BARRA DO OURO", "BARROLANDIA", "BERNARDO SAYAO", "BOM JESUS DO TOCANTINS", "BRASILANDIA DO TOCANTINS", "BREJINHO DE NAZARE", "BURITI DO TOCANTINS", "CACHOEIRINHA", "CAMPOS LINDOS", "CARIRI DO TOCANTINS", "CARMOLANDIA", "CARRASCO BONITO", "CASEARA", "CENTENARIO", "CHAPADA DA NATIVIDADE", "CHAPADA DE AREIA", "COLINAS DO TOCANTINS", "COLMEIA", "COMBINADO", "CONCEICAO DO TOCANTINS", "COUTO MAGALHAES", "CRISTALANDIA", "CRIXAS DO TOCANTINS", "DARCINOPOLIS", "DIANOPOLIS", "DIVINOPOLIS DO TOCANTINS", "DOIS IRMAOS DO TOCANTINS", "DUERE", "ESPERANTINA", "FATIMA", "FIGUEIROPOLIS", "FILADELFIA", "FORMOSO DO ARAGUAIA", "FORTALEZA DO TABOCAO", "GOIANORTE", "GOIATINS", "GUARAI", "GURUPI", "IPUEIRAS", "ITACAJA", "ITAGUATINS", "ITAPIRATINS", "ITAPORA DO TOCANTINS", "JAU DO TOCANTINS", "JUARINA", "LAGOA DA CONFUSAO", "LAGOA DO TOCANTINS", "LAJEADO", "LAVANDEIRA", "LIZARDA", "LUZINOPOLIS", "MARIANOPOLIS DO TOCANTINS", "MATEIROS", "MAURILANDIA DO TOCANTINS", "MIRACEMA DO TOCANTINS", "MIRANORTE", "MONTE DO CARMO", "MONTE SANTO DO TOCANTINS", "MURICILANDIA", "NATIVIDADE", "NAZARE", "NOVA OLINDA", "NOVA ROSALANDIA", "NOVO ACORDO", "NOVO ALEGRE", "NOVO JARDIM", "OLIVEIRA DE FATIMA", "PALMAS", "PALMEIRANTE", "PALMEIRAS DO TOCANTINS", "PALMEIROPOLIS", "PARAISO DO TOCANTINS", "PARANA", "PAU D'ARCO", "PEDRO AFONSO", "PEIXE", "PEQUIZEIRO", "PINDORAMA DO TOCANTINS", "PIRAQUE", "PIUM", "PONTE ALTA DO BOM JESUS", "PONTE ALTA DO TOCANTINS", "PORTO ALEGRE DO TOCANTINS", "PORTO NACIONAL", "PRAIA NORTE", "PRESIDENTE KENNEDY", "PUGMIL", "RECURSOLANDIA", "RIACHINHO", "RIO DA CONCEICAO", "RIO DOS BOIS", "RIO SONO", "SAMPAIO", "SANDOLANDIA", "SANTA FE DO ARAGUAIA", "SANTA MARIA DO TOCANTINS", "SANTA RITA DO TOCANTINS", "SANTA ROSA DO TOCANTINS", "SANTA TEREZA DO TOCANTINS", "SANTA TEREZINHA DO TOCANTINS", "SAO BENTO DO TOCANTINS", "SAO FELIX DO TOCANTINS", "SAO MIGUEL DO TOCANTINS", "SAO SALVADOR DO TOCANTINS", "SAO SEBASTIAO DO TOCANTINS", "SAO VALERIO", "SILVANOPOLIS", "SITIO NOVO DO TOCANTINS", "SUCUPIRA", "TAGUATINGA", "TAIPAS DO TOCANTINS", "TALISMA", "TOCANTINIA", "TOCANTINOPOLIS", "TUPIRAMA", "TUPIRATINS", "WANDERLANDIA", "XAMBIOA" });
            #endregion
        }

        #region Busca Cidade
        public string buscaCidade(string texto, string stringEstado = "")
        {
            string regex = @"((?![á-ú])\W|^)cidade(\W|$)";
            List<string> cidadesDesc = new List<string>();
            List<string> aux = new List<string>();
            List<string> verMaiores = new List<string>();

            texto = RemoveAcentuacao(texto);
            texto = texto.Trim();

            string str = "";

            #region Percorrendo para ver se achou mais de uma cidade
            foreach (string cidade in cidades)
            {
                regex = regex.Replace("cidade", cidade);
                if (Regex.IsMatch(texto, regex, RegexOptions.IgnoreCase))
                {
                    cidadesDesc.Add(cidade);
                }
                regex = @"((?![á-ú])\W|^)cidade(\W|$)";
            }
            #endregion

            #region Colocando um toUpper Para comparar com Estado
            foreach (string cidade in cidadesDesc)
            {
                aux.Add(cidade.ToUpper());
            }
            #endregion

            #region Retira estado
            if (aux.Count > 1)
            {
                foreach (string estado in estados)
                {
                    if (aux.Count > 1)
                    {
                        if (aux.Contains(estado))
                        {
                            aux.Remove(estado);
                        }
                    }
                }
            }
            #endregion

            #region indicando a String a ser percorrida
            foreach (string index in aux)
            {
                str = str + " " + index;
            }
            #endregion

            #region Percorrendo a lista
            foreach (string txt in cidades)
            {
                regex = regex.Replace("cidade", txt);
                if (Regex.IsMatch(str, regex, RegexOptions.IgnoreCase))
                {
                    verMaiores.Add(txt);
                }
                regex = @"((?![á-ú])\W|^)cidade(\W|$)";
            }
            #endregion

            #region Qual se Aproxima mais
            string auxiliar = "";
            if (verMaiores != null && verMaiores.Count > 0)
            {
                foreach (string index in verMaiores)
                {
                    if (auxiliar.Length < index.Length)
                    {
                        auxiliar = index;
                    }
                }
                if (ContainsInsensitive(auxiliar, "Sao Jose"))
                {
                    if (ContainsInsensitive(texto, "SC"))
                    {
                        return "SAO JOSE/SC";
                    }
                }
                else if (ContainsInsensitive(auxiliar, "Joao Pessoa"))
                {
                    if (ContainsInsensitive(texto, "PB"))
                    {
                        return "JOÃO PESSOA/PB";
                    }
                }
                if (string.IsNullOrEmpty(stringEstado))
                    return RetornaCidade(auxiliar);
                else
                    return RetornaCidadeEstado(auxiliar, stringEstado);
            }
            #endregion


            if (cidadesDesc.Count > 0)
            {
                if (ContainsInsensitive(cidadesDesc[0].Trim(), "Sao Jose"))
                {
                    if (ContainsInsensitive(texto, "SC"))
                    {
                        return "SAO JOSE/SC";
                    }
                }
                else if (ContainsInsensitive(cidadesDesc[0].Trim(), "Joao Pessoa"))
                {
                    if (ContainsInsensitive(texto, "PB"))
                    {
                        return "JOÃO PESSOA/PB";
                    }
                }
                if (string.IsNullOrEmpty(stringEstado))
                    return RetornaCidade(cidadesDesc[0].Trim());
                else
                    return RetornaCidadeEstado(cidadesDesc[0].Trim(), stringEstado);
            }

            foreach (var sigla in SiglaEstados)
            {
                string rgSigla = @"\s" + sigla.Key + @"\s";
                if (Regex.IsMatch(texto, rgSigla, RegexOptions.IgnoreCase) || texto.Equals(sigla.Key))
                    return $"{sigla.Value.ToUpper()}/{sigla.Key}";

            }

            return "";
        }

        #endregion

        #region RemoveAcentuacao
        private string RemoveAcentuacao(string texto)
        {
            if (string.IsNullOrEmpty(texto))
                return string.Empty;

            var s = texto.Normalize(NormalizationForm.FormD);
            var sb = new StringBuilder();
            foreach (var t in s)
            {
                var uc = CharUnicodeInfo.GetUnicodeCategory(t);
                if (uc != UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(t);
                }
            }

            return sb.ToString();
        }

        #endregion

        #region Método Contains Insensetive
        private bool ContainsInsensitive(string source, string search)
        {
            return (new CultureInfo("pt-BR").CompareInfo).IndexOf(source, search, CompareOptions.IgnoreCase | CompareOptions.IgnoreNonSpace) >= 0;
        }
        #endregion

        #region Retorna cidade
        private string RetornaCidade(string cidade)
        {
            cidade = RemoveAcentuacao(cidade);
            cidade = cidade.ToUpper();
            cidade = cidade.Trim();
            if (cidade == "FARIA LIMA" || cidade == "DUTRA")
            {
                cidade = "SAO PAULO";
            }
            if (cidade == "ST" || cidade == "ST. BARBARA D’OESTE" || cidade == "SANTA BARBARA D OESTE" || cidade == "SANTA BARBARA DO OESTE" || cidade == "SANTA BARBARA DOESTE")
            {
                cidade = "SANTA BARBARA D'OESTE";
            }

            #region Capitais/Estados
            if (cidade == "SANTA CATARINA")
                cidade = "FLORIANOPOLIS";
            if (cidade == "ACRE")
                cidade = "RIO BRANCO";
            if (cidade == "ALAGOAS")
                cidade = "MACEIO";
            if (cidade == "AMAPA")
                cidade = "MACAPA";
            if (cidade == "AMAZONAS")
                cidade = "MANAUS";
            if (cidade == "BAHIA")
                cidade = "SALVADOR";
            if (cidade == "CEARA")
                cidade = "FORTALEZA";
            if (cidade == "ESPIRITO SANTO")
                cidade = "VITORIA";
            if (cidade == "GOIAS")
                cidade = "GOIANIA";
            if (cidade == "MARANHAO")
                cidade = "SAO LUIS";
            if (cidade == "MATO GROSSO")
                cidade = "CUIBA";
            if (cidade == "MATO GROSSO DO SUL")
                cidade = "CAMPO GRANDE";
            if (cidade == "MINAS GERAIS")
                cidade = "BELO HORIZONTE";
            //if (cidade == "PARA")
            //    cidade = "BELEM";
            if (cidade == "PARAIBA")
                cidade = "JOAO PESSOA";
            if (cidade == "PARANA")
                cidade = "CURITIBA";
            if (cidade == "PERNAMBUCO")
                cidade = "RECIFE";
            if (cidade == "RIO GRANDE DO NORTE")
                cidade = "NATAL";
            if (cidade == "RIO GRANDE DO SUL")
                cidade = "PORTO ALEGRE";
            if (cidade == "RONDONIA")
                cidade = "PORTO VELHO";
            if (cidade == "SERGIPE")
                cidade = "ARACAJU";
            if (cidade == "TOCANTINS")
                cidade = "PALMAS";
            #endregion

            switch (cidade)
            {
                case "ACRE":
                case "ACRELANDIA":
                case "ASSIS BRASIL":
                case "BRASILEIA":
                case "BUJARI":
                case "CAPIXABA":
                case "CRUZEIRO DO SUL":
                case "EPITACIOLANDIA":
                case "FEIJO":
                case "JORDAO":
                case "MANCIO LIMA":
                case "MANOEL URBANO":
                case "MARECHAL THAUMATURGO":
                case "PLACIDO DE CASTRO":
                case "PORTO ACRE":
                case "PORTO WALTER":
                case "RIO BRANCO":
                case "RODRIGUES ALVES":
                case "SANTA ROSA DO PURUS":
                case "SENA MADUREIRA":
                case "SENADOR GUIOMARD":
                case "TARAUACA":
                case "XAPURI":

                    return cidade + "/AC";

                case "ALAGOAS":
                case "AGUA BRANCA":
                case "ANADIA":
                case "ARAPIRACA":
                case "ATALAIA":
                case "BARRA DE SANTO ANTONIO":
                case "BARRA DE SAO MIGUEL":
                case "BATALHA":
                case "BELEM":
                case "BELO MONTE":
                case "BOCA DA MATA":
                case "BRANQUINHA":
                case "CACIMBINHAS":
                case "CAJUEIRO":
                case "CAMPESTRE":
                case "CAMPO ALEGRE":
                case "CAMPO GRANDE":
                case "CANAPI":
                case "CAPELA":
                case "CARNEIROS":
                case "CHA PRETA":
                case "COITE DO NOIA":
                case "COLONIA LEOPOLDINA":
                case "COQUEIRO SECO":
                case "CORURIPE":
                case "CRAIBAS":
                case "DELMIRO GOUVEIA":
                case "DOIS RIACHOS":
                case "ESTRELA DE ALAGOAS":
                case "FEIRA GRANDE":
                case "FELIZ DESERTO":
                case "FLEXEIRAS":
                case "GIRAU DO PONCIANO":
                case "IBATEGUARA":
                case "IGACI":
                case "IGREJA NOVA":
                case "INHAPI":
                case "JACARE DOS HOMENS":
                case "JACUIPE":
                case "JAPARATINGA":
                case "JARAMATAIA":
                case "JEQUIA DA PRAIA":
                case "JOAQUIM GOMES":
                case "JUNDIA":
                case "JUNQUEIRO":
                case "LAGOA DA CANOA":
                case "LIMOEIRO DE ANADIA":
                case "MACEIO":
                case "MAJOR ISIDORO":
                case "MAR VERMELHO":
                case "MARAGOGI":
                case "MARAVILHA":
                case "MARECHAL DEODORO":
                case "MARIBONDO":
                case "MATA GRANDE":
                case "MATRIZ DE CAMARAGIBE":
                case "MESSIAS":
                case "MINADOR DO NEGRAO":
                case "MONTEIROPOLIS":
                case "MURICI":
                case "NOVO LINO":
                case "OLHO D'AGUA DAS FLORES":
                case "OLHO D'AGUA DO CASADO":
                case "OLHO D'AGUA GRANDE":
                case "OLIVENCA":
                case "OURO BRANCO":
                case "PALESTINA":
                case "PALMEIRA DOS INDIOS":
                case "PAO DE ACUCAR":
                case "PARICONHA":
                case "PARIPUEIRA":
                case "PASSO DE CAMARAGIBE":
                case "PAULO JACINTO":
                case "PENEDO":
                case "PIACABUCU":
                case "PILAR":
                case "PINDOBA":
                case "PIRANHAS":
                case "POCO DAS TRINCHEIRAS":
                case "PORTO CALVO":
                case "PORTO DE PEDRAS":
                case "PORTO REAL DO COLEGIO":
                case "QUEBRANGULO":
                case "RIO LARGO":
                case "ROTEIRO":
                case "SANTA LUZIA DO NORTE":
                case "SANTANA DO IPANEMA":
                case "SANTANA DO MUNDAU":
                case "SAO BRAS":
                case "SAO JOSE DA LAJE":
                case "SAO JOSE DA TAPERA":
                case "SAO LUIS DO QUITUNDE":
                case "SAO MIGUEL DOS CAMPOS":
                case "SAO MIGUEL DOS MILAGRES":
                case "SAO SEBASTIAO":
                case "SATUBA":
                case "SENADOR RUI PALMEIRA":
                case "TANQUE D'ARCA":
                case "TAQUARANA":
                case "TEOTONIO VILELA":
                case "TRAIPU":
                case "UNIAO DOS PALMARES":
                case "VICOSA":

                    return cidade + "/AL";

                case "AMAZONAS":
                case "ALVARAES":
                case "AMATURA":
                case "ANAMA":
                case "ANORI":
                case "APUI":
                case "ATALAIA DO NORTE":
                case "AUTAZES":
                case "BARCELOS":
                case "BARREIRINHA":
                case "BENJAMIN CONSTANT":
                case "BERURI":
                case "BOA VISTA DO RAMOS":
                case "BOCA DO ACRE":
                case "BORBA":
                case "CAAPIRANGA":
                case "CANUTAMA":
                case "CARAUARI":
                case "CAREIRO":
                case "CAREIRO DA VARZEA":
                case "COARI":
                case "CODAJAS":
                case "EIRUNEPE":
                case "ENVIRA":
                case "FONTE BOA":
                case "GUAJARA":
                case "HUMAITA":
                case "IPIXUNA":
                case "IRANDUBA":
                case "ITACOATIARA":
                case "ITAMARATI":
                case "ITAPIRANGA":
                case "JAPURA":
                case "JURUA":
                case "JUTAI":
                case "LABREA":
                case "MANACAPURU":
                case "MANAQUIRI":
                case "MANAUS":
                case "MANICORE":
                case "MARAA":
                case "MAUES":
                case "NHAMUNDA":
                case "NOVA OLINDA DO NORTE":
                case "NOVO AIRAO":
                case "NOVO ARIPUANA":
                case "PARINTINS":
                case "PAUINI":
                case "PRESIDENTE FIGUEIREDO":
                case "RIO PRETO DA EVA":
                case "SANTA ISABEL DO RIO NEGRO":
                case "SANTO ANTONIO DO ICA":
                case "SAO GABRIEL DA CACHOEIRA":
                case "SAO PAULO DE OLIVENCA":
                case "SAO SEBASTIAO DO UATUMA":
                case "SILVES":
                case "TABATINGA":
                case "TAPAUA":
                case "TEFE":
                case "TONANTINS":
                case "UARINI":
                case "URUCARA":
                case "URUCURITUBA":

                    return cidade + "/AM";

                case "AMAPA":
                case "CALCOENE":
                case "CUTIAS":
                case "FERREIRA GOMES":
                case "ITAUBAL":
                case "LARANJAL DO JARI":
                case "MACAPA":
                case "MAZAGAO":
                case "OIAPOQUE":
                case "PEDRA BRANCA DO AMAPARI":
                case "PORTO GRANDE":
                case "PRACUUBA":
                case "SANTANA":
                case "SERRA DO NAVIO":
                case "TARTARUGALZINHO":
                case "VITORIA DO JARI":

                    return cidade + "/AP";

                case "BAHIA":
                case "ABAIRA":
                case "ABARE":
                case "ACAJUTIBA":
                case "ADUSTINA":
                case "AGUA FRIA":
                case "AIQUARA":
                case "ALAGOINHAS":
                case "ALCOBACA":
                case "ALMADINA":
                case "AMARGOSA":
                case "AMELIA RODRIGUES":
                case "AMERICA DOURADA":
                case "ANAGE":
                case "ANDARAI":
                case "ANDORINHA":
                case "ANGICAL":
                case "ANGUERA":
                case "ANTAS":
                case "ANTONIO CARDOSO":
                case "ANTONIO GONCALVES":
                case "APORA":
                case "APUAREMA":
                case "ARACAS":
                case "ARACATU":
                case "ARACI":
                case "ARAMARI":
                case "ARATACA":
                case "ARATUIPE":
                case "AURELINO LEAL":
                case "BAIANOPOLIS":
                case "BAIXA GRANDE":
                case "BANZAE":
                case "BARRA":
                case "BARRA DA ESTIVA":
                case "BARRA DO CHOCA":
                case "BARRA DO MENDES":
                case "BARRA DO ROCHA":
                case "BARREIRAS":
                case "BARRO ALTO":
                case "BARROCAS":
                case "BARRO PRETO":
                case "BELMONTE":
                case "BELO CAMPO":
                case "BIRITINGA":
                case "BOA NOVA":
                case "BOA VISTA DO TUPIM":
                case "BOM JESUS DA LAPA":
                case "BOM JESUS DA SERRA":
                case "BONINAL":
                case "BONITO":
                case "BOQUIRA":
                case "BOTUPORA":
                case "BREJOES":
                case "BREJOLANDIA":
                case "BROTAS DE MACAUBAS":
                case "BRUMADO":
                case "BUERAREMA":
                case "BURITIRAMA":
                case "CAATIBA":
                case "CABACEIRAS DO PARAGUACU":
                case "CACHOEIRA":
                case "CACULE":
                case "CAEM":
                case "CAETANOS":
                case "CAETITE":
                case "CAFARNAUM":
                case "CAIRU":
                case "CALDEIRAO GRANDE":
                case "CAMACAN":
                case "CAMACARI":
                case "CAMAMU":
                case "CAMPO ALEGRE DE LOURDES":
                case "CAMPO FORMOSO":
                case "CANAPOLIS":
                case "CANARANA":
                case "CANAVIEIRAS":
                case "CANDEAL":
                case "CANDEIAS":
                case "CANDIBA":
                case "CANDIDO SALES":
                case "CANSANCAO":
                case "CANUDOS":
                case "CAPELA DO ALTO ALEGRE":
                case "CAPIM GROSSO":
                case "CARAIBAS":
                case "CARAVELAS":
                case "CARDEAL DA SILVA":
                case "CARINHANHA":
                case "CASA NOVA":
                case "CASTRO ALVES":
                case "CATOLANDIA":
                case "CATU":
                case "CATURAMA":
                case "CENTRAL":
                case "CHORROCHO":
                case "CICERO DANTAS":
                case "CIPO":
                case "COARACI":
                case "COCOS":
                case "CONCEICAO DA FEIRA":
                case "CONCEICAO DO ALMEIDA":
                case "CONCEICAO DO COITE":
                case "CONCEICAO DO JACUIPE":
                case "CONDE":
                case "CONDEUBA":
                case "CONTENDAS DO SINCORA":
                case "CORACAO DE MARIA":
                case "CORDEIROS":
                case "CORIBE":
                case "CORONEL JOAO SA":
                case "CORRENTINA":
                case "COTEGIPE":
                case "CRAVOLANDIA":
                case "CRISOPOLIS":
                case "CRISTOPOLIS":
                case "CRUZ DAS ALMAS":
                case "CURACA":
                case "DARIO MEIRA":
                case "DIAS D'AVILA":
                case "DOM BASILIO":
                case "DOM MACEDO COSTA":
                case "ELISIO MEDRADO":
                case "ENCRUZILHADA":
                case "ENTRE RIOS":
                case "ERICO CARDOSO":
                case "ESPLANADA":
                case "EUCLIDES DA CUNHA":
                case "EUNAPOLIS":
                case "FATIMA":
                case "FEIRA DA MATA":
                case "FEIRA DE SANTANA":
                case "FILADELFIA":
                case "FIRMINO ALVES":
                case "FLORESTA AZUL":
                case "FORMOSA DO RIO PRETO":
                case "GANDU":
                case "GAVIAO":
                case "GENTIO DO OURO":
                case "GLORIA":
                case "GONGOGI":
                case "GOVERNADOR MANGABEIRA":
                case "GUAJERU":
                case "GUANAMBI":
                case "GUARATINGA":
                case "HELIOPOLIS":
                case "IACU":
                case "IBIASSUCE":
                case "IBICARAI":
                case "IBICOARA":
                case "IBICUI":
                case "IBIPEBA":
                case "IBIPITANGA":
                case "IBIQUERA":
                case "IBIRAPITANGA":
                case "IBIRAPUA":
                case "IBIRATAIA":
                case "IBITIARA":
                case "IBITITA":
                case "IBOTIRAMA":
                case "ICHU":
                case "IGAPORA":
                case "IGRAPIUNA":
                case "IGUAI":
                case "ILHEUS":
                case "INHAMBUPE":
                case "IPECAETA":
                case "IPIAU":
                case "IPIRA":
                case "IPUPIARA":
                case "IRAJUBA":
                case "IRAMAIA":
                case "IRAQUARA":
                case "IRARA":
                case "IRECE":
                case "ITABELA":
                case "ITABERABA":
                case "ITABUNA":
                case "ITACARE":
                case "ITAETE":
                case "ITAGI":
                case "ITAGIBA":
                case "ITAGIMIRIM":
                case "ITAGUACU DA BAHIA":
                case "ITAJU DO COLONIA":
                case "ITAJUIPE":
                case "ITAMARAJU":
                case "ITAMARI":
                case "ITAMBE":
                case "ITANAGRA":
                case "ITANHEM":
                case "ITAPARICA":
                case "ITAPE":
                case "ITAPEBI":
                case "ITAPETINGA":
                case "ITAPICURU":
                case "ITAPITANGA":
                case "ITAQUARA":
                case "ITARANTIM":
                case "ITATIM":
                case "ITIRUCU":
                case "ITIUBA":
                case "ITORORO":
                case "ITUACU":
                case "ITUBERA":
                case "IUIU":
                case "JABORANDI":
                case "JACARACI":
                case "JACOBINA":
                case "JAGUAQUARA":
                case "JAGUARARI":
                case "JAGUARIPE":
                case "JANDAIRA":
                case "JEQUIE":
                case "JEREMOABO":
                case "JIQUIRICA":
                case "JITAUNA":
                case "JOAO DOURADO":
                case "JUAZEIRO":
                case "JUCURUCU":
                case "JUSSARA":
                case "JUSSARI":
                case "JUSSIAPE":
                case "LAFAIETE COUTINHO":
                case "LAGOA REAL":
                case "LAJE":
                case "LAJEDAO":
                case "LAJEDINHO":
                case "LAJEDO DO TABOCAL":
                case "LAMARAO":
                case "LAPAO":
                case "LAURO DE FREITAS":
                case "LENCOIS":
                case "LICINIO DE ALMEIDA":
                case "LIVRAMENTO DE NOSSA SENHORA":
                case "LUIS EDUARDO MAGALHAES":
                case "MACAJUBA":
                case "MACARANI":
                case "MACAUBAS":
                case "MACURURE":
                case "MADRE DE DEUS":
                case "MAETINGA":
                case "MAIQUINIQUE":
                case "MAIRI":
                case "MALHADA":
                case "MALHADA DE PEDRAS":
                case "MANOEL VITORINO":
                case "MANSIDAO":
                case "MARACAS":
                case "MARAGOGIPE":
                case "MARAU":
                case "MARCIONILIO SOUZA":
                case "MASCOTE":
                case "MATA DE SAO JOAO":
                case "MATINA":
                case "MEDEIROS NETO":
                case "MIGUEL CALMON":
                case "MILAGRES":
                case "MIRANGABA":
                case "MIRANTE":
                case "MONTE SANTO":
                case "MORPARA":
                case "MORRO DO CHAPEU":
                case "MORTUGABA":
                case "MUCUGE":
                case "MUCURI":
                case "MULUNGU DO MORRO":
                case "MUNDO NOVO":
                case "MUNIZ FERREIRA":
                case "MUQUEM DE SAO FRANCISCO":
                case "MURITIBA":
                case "MUTUIPE":
                case "NAZARE":
                case "NILO PECANHA":
                case "NORDESTINA":
                case "NOVA CANAA":
                case "NOVA FATIMA":
                case "NOVA IBIA":
                case "NOVA ITARANA":
                case "NOVA REDENCAO":
                case "NOVA SOURE":
                case "NOVA VICOSA":
                case "NOVO HORIZONTE":
                case "NOVO TRIUNFO":
                case "OLINDINA":
                case "OLIVEIRA DOS BREJINHOS":
                case "OURICANGAS":
                case "OUROLANDIA":
                case "PALMAS DE MONTE ALTO":
                case "PALMEIRAS":
                case "PARAMIRIM":
                case "PARATINGA":
                case "PARIPIRANGA":
                case "PAU BRASIL":
                case "PAULO AFONSO":
                case "PE DE SERRA":
                case "PEDRAO":
                case "PEDRO ALEXANDRE":
                case "PIATA":
                case "PILAO ARCADO":
                case "PINDAI":
                case "PINDOBACU":
                case "PINTADAS":
                case "PIRAI DO NORTE":
                case "PIRIPA":
                case "PIRITIBA":
                case "PLANALTINO":
                case "PLANALTO":
                case "POCOES":
                case "POJUCA":
                case "PONTO NOVO":
                case "PORTO SEGURO":
                case "POTIRAGUA":
                case "PRADO":
                case "PRESIDENTE DUTRA":
                case "PRESIDENTE JANIO QUADROS":
                case "PRESIDENTE TANCREDO NEVES":
                case "QUEIMADAS":
                case "QUIJINGUE":
                case "QUIXABEIRA":
                case "RAFAEL JAMBEIRO":
                case "REMANSO":
                case "RETIROLANDIA":
                case "RIACHAO DAS NEVES":
                case "RIACHAO DO JACUIPE":
                case "RIACHO DE SANTANA":
                case "RIBEIRA DO AMPARO":
                case "RIBEIRA DO POMBAL":
                case "RIBEIRAO DO LARGO":
                case "RIO DE CONTAS":
                case "RIO DO ANTONIO":
                case "RIO DO PIRES":
                case "RIO REAL":
                case "RODELAS":
                case "RUY BARBOSA":
                case "SALINAS DA MARGARIDA":
                case "SALVADOR":
                case "SANTA BARBARA":
                case "SANTA BRIGIDA":
                case "SANTA CRUZ CABRALIA":
                case "SANTA CRUZ DA VITORIA":
                case "SANTA INES":
                case "SANTA LUZIA":
                case "SANTA MARIA DA VITORIA":
                case "SANTA RITA DE CASSIA":
                case "SANTA TERESINHA":
                case "SANTALUZ":
                //case "SANTANA":
                case "SANTANOPOLIS":
                case "SANTO AMARO":
                case "SANTO ANTONIO DE JESUS":
                case "SANTO ESTEVAO":
                case "SAO DESIDERIO":
                case "SAO DOMINGOS":
                case "SAO FELIPE":
                case "SAO FELIX":
                case "SAO FELIX DO CORIBE":
                case "SAO FRANCISCO DO CONDE":
                case "SAO GABRIEL":
                case "SAO GONCALO DOS CAMPOS":
                case "SAO JOSE DA VITORIA":
                case "SAO JOSE DO JACUIPE":
                case "SAO MIGUEL DAS MATAS":
                case "SAO SEBASTIAO DO PASSE":
                case "SAPEACU":
                case "SATIRO DIAS":
                case "SAUBARA":
                case "SAUDE":
                case "SEABRA":
                case "SEBASTIAO LARANJEIRAS":
                case "SENHOR DO BONFIM":
                case "SENTO SE":
                case "SERRA DO RAMALHO":
                case "SERRA DOURADA":
                case "SERRA PRETA":
                case "SERRINHA":
                case "SERROLANDIA":
                case "SIMOES FILHO":
                case "SITIO DO MATO":
                case "SITIO DO QUINTO":
                case "SOBRADINHO":
                case "SOUTO SOARES":
                case "TABOCAS DO BREJO VELHO":
                case "TANHACU":
                case "TANQUE NOVO":
                case "TANQUINHO":
                case "TAPEROA":
                case "TAPIRAMUTA":
                case "TEIXEIRA DE FREITAS":
                case "TEODORO SAMPAIO":
                case "TEOFILANDIA":
                case "TEOLANDIA":
                case "TERRA NOVA":
                case "TREMEDAL":
                case "TUCANO":
                case "UAUA":
                case "UBAIRA":
                case "UBAITABA":
                case "UBATA":
                case "UIBAI":
                case "UMBURANAS":
                case "UNA":
                case "URANDI":
                case "URUCUCA":
                case "UTINGA":
                case "VALENCA":
                case "VALENTE":
                case "VARZEA DA ROCA":
                case "VARZEA DO POCO":
                case "VARZEA NOVA":
                case "VARZEDO":
                case "VERA CRUZ":
                case "VEREDA":
                case "VITORIA DA CONQUISTA":
                case "WAGNER":
                case "WANDERLEY":
                case "WENCESLAU GUIMARAES":
                case "XIQUE-XIQUE":

                    return cidade + "/BA";

                case "CEARÁ":
                case "ABAIARA":
                case "ACARAPE":
                case "ACARAU":
                case "ACOPIARA":
                case "AIUABA":
                case "ALCANTARAS":
                case "ALTANEIRA":
                case "ALTO SANTO":
                case "AMONTADA":
                case "ANTONINA DO NORTE":
                case "APUIARES":
                case "AQUIRAZ":
                case "ARACATI":
                case "ARACOIABA":
                case "ARARENDA":
                case "ARARIPE":
                case "ARATUBA":
                case "ARNEIROZ":
                case "ASSARE":
                case "AURORA":
                case "BAIXIO":
                case "BANABUIU":
                case "BARBALHA":
                case "BARREIRA":
                case "BARRO":
                case "BARROQUINHA":
                case "BATURITE":
                case "BEBERIBE":
                case "BELA CRUZ":
                case "BOA VIAGEM":
                case "BREJO SANTO":
                case "CAMOCIM":
                case "CAMPOS SALES":
                case "CANINDE":
                case "CAPISTRANO":
                case "CARIDADE":
                case "CARIRE":
                case "CARIRIACU":
                case "CARIUS":
                case "CARNAUBAL":
                case "CASCAVEL":
                case "CATARINA":
                case "CATUNDA":
                case "CAUCAIA":
                case "CEDRO":
                case "CHAVAL":
                case "CHORO":
                case "CHOROZINHO":
                case "COREAU":
                case "CRATEUS":
                case "CRATO":
                case "CROATA":
                case "CRUZ":
                case "DEPUTADO IRAPUAN PINHEIRO":
                case "ERERE":
                case "EUSEBIO":
                case "FARIAS BRITO":
                case "FORQUILHA":
                case "FORTALEZA":
                case "FORTIM":
                case "FRECHEIRINHA":
                case "GENERAL SAMPAIO":
                case "GRACA":
                case "GRANJA":
                case "GRANJEIRO":
                case "GROAIRAS":
                case "GUAIUBA":
                case "GUARACIABA DO NORTE":
                case "GUARAMIRANGA":
                case "HIDROLANDIA":
                case "HORIZONTE":
                case "IBARETAMA":
                case "IBIAPINA":
                case "IBICUITINGA":
                case "ICAPUI":
                case "ICO":
                case "IGUATU":
                case "INDEPENDENCIA":
                case "IPAPORANGA":
                case "IPAUMIRIM":
                case "IPU":
                case "IPUEIRAS":
                case "IRACEMA":
                case "IRAUCUBA":
                case "ITAICABA":
                case "ITAITINGA":
                case "ITAPAJE":
                case "ITAPIPOCA":
                case "ITAPIUNA":
                case "ITAREMA":
                case "ITATIRA":
                case "JAGUARETAMA":
                case "JAGUARIBARA":
                case "JAGUARIBE":
                case "JAGUARUANA":
                case "JARDIM":
                case "JATI":
                case "JIJOCA DE JERICOAROARA":
                case "JUAZEIRO DO NORTE":
                case "JUCAS":
                case "LAVRAS DA MANGABEIRA":
                case "LIMOEIRO DO NORTE":
                case "MADALENA":
                case "MARACANAU":
                case "MARANGUAPE":
                case "MARCO":
                case "MARTINOPOLE":
                case "MASSAPE":
                case "MAURITI":
                case "MERUOCA":
                //case "MILAGRES":
                case "MILHA":
                case "MIRAIMA":
                case "MISSAO VELHA":
                case "MOMBACA":
                case "MONSENHOR TABOSA":
                case "MORADA NOVA":
                case "MORAUJO":
                case "MORRINHOS":
                case "MUCAMBO":
                case "MULUNGU":
                case "NOVA OLINDA":
                case "NOVA RUSSAS":
                case "NOVO ORIENTE":
                case "OCARA":
                case "OROS":
                case "PACAJUS":
                case "PACATUBA":
                case "PACOTI":
                case "PACUJA":
                case "PALHANO":
                case "PALMACIA":
                case "PARACURU":
                case "PARAIPABA":
                case "PARAMBU":
                case "PARAMOTI":
                case "PEDRA BRANCA":
                case "PENAFORTE":
                case "PENTECOSTE":
                case "PEREIRO":
                case "PINDORETAMA":
                case "PIQUET CARNEIRO":
                case "PIRES FERREIRA":
                case "PORANGA":
                case "PORTEIRAS":
                case "POTENGI":
                case "POTIRETAMA":
                case "QUITERIANOPOLIS":
                case "QUIXADA":
                case "QUIXELO":
                case "QUIXERAMOBIM":
                case "QUIXERE":
                case "REDENCAO":
                case "RERIUTABA":
                case "RUSSAS":
                case "SABOEIRO":
                case "SALITRE":
                case "SANTA QUITERIA":
                case "SANTANA DO ACARAU":
                case "SANTANA DO CARIRI":
                case "SAO BENEDITO":
                case "SAO GONCALO DO AMARANTE":
                case "SAO JOAO DO JAGUARIBE":
                case "SAO LUIS DO CURU":
                case "SENADOR POMPEU":
                case "SENADOR SA":
                case "SOBRAL":
                case "SOLONOPOLE":
                case "TABULEIRO DO NORTE":
                case "TAMBORIL":
                case "TARRAFAS":
                case "TAUA":
                case "TEJUCUOCA":
                case "TIANGUA":
                case "TRAIRI":
                case "TURURU":
                case "UBAJARA":
                case "UMARI":
                case "UMIRIM":
                case "URUBURETAMA":
                case "URUOCA":
                case "VARJOTA":
                case "VARZEA ALEGRE":
                case "VICOSA DO CEARA":

                    return cidade + "/CE";

                case "AGUAS CLARAS":
                case "ARNIQUEIRA":
                case "BRASILIA":
                case "BRAZLANDIA":
                case "CANDANGOLANDIA":
                case "CEILANDIA":
                case "CRUZEIRO":
                case "ESTRUTURAL":
                case "FERCAL":
                case "GAMA":
                case "GUARA":
                case "ITAPOA":
                case "JARDIM BOTANICO":
                case "LAGO NORTE":
                case "LAGO SUL":
                case "NUCLEO BANDEIRANTE":
                case "OCTOGONAL":
                case "PARANOA":
                case "PARK WAY":
                case "PLANALTINA":
                case "PLANO PILOTO":
                case "POR DO SOL":
                case "RECANTO DAS EMAS":
                case "RIACHO FUNDO II":
                case "RIACHO FUNDO":
                case "SAMAMBAIA":
                case "SANTA MARIA":
                //case "SAO SEBASTIAO":
                case "SIA":
                case "SOBRADINHO II":
                //case "SOBRADINHO":
                case "SOL NASCENTE":
                case "SUDOESTE":
                case "TAGUATINGA":
                case "VARJAO":
                case "VICENTE PIRES":

                    return cidade + "/DF";

                case "AFONSO CLAUDIO":
                case "AGUA DOCE DO NORTE":
                case "AGUIA BRANCA":
                case "ALEGRE":
                case "ALFREDO CHAVES":
                case "ALTO RIO NOVO":
                case "ANCHIETA":
                case "APIACA":
                case "ARACRUZ":
                case "ATILIO VIVACQUA":
                case "BAIXO GUANDU":
                case "BARRA DE SAO FRANCISCO":
                case "BOA ESPERANCA":
                case "BOM JESUS DO NORTE":
                case "BREJETUBA":
                case "CACHOEIRO DE ITAPEMIRIM":
                case "CARIACICA":
                case "CASTELO":
                case "COLATINA":
                case "CONCEICAO DA BARRA":
                case "CONCEICAO DO CASTELO":
                case "DIVINO DE SAO LOURENCO":
                case "DOMINGOS MARTINS":
                case "DORES DO RIO PRETO":
                case "ECOPORANGA":
                case "FUNDAO":
                case "GOVERNADOR LINDENBERG":
                case "GUACUI":
                case "GUARAPARI":
                case "IBATIBA":
                case "IBIRACU":
                case "IBITIRAMA":
                case "ICONHA":
                case "IRUPI":
                case "ITAGUACU":
                case "ITAPEMIRIM":
                case "ITARANA":
                case "IUNA":
                case "JAGUARE":
                case "JERONIMO MONTEIRO":
                case "JOAO NEIVA":
                case "LARANJA DA TERRA":
                case "LINHARES":
                case "MANTENOPOLIS":
                case "MARATAIZES":
                case "MARECHAL FLORIANO":
                case "MARILANDIA":
                case "MIMOSO DO SUL":
                case "MONTANHA":
                case "MUCURICI":
                case "MUNIZ FREIRE":
                case "MUQUI":
                case "NOVA VENECIA":
                case "PANCAS":
                case "PEDRO CANARIO":
                case "PINHEIROS":
                case "PIUMA":
                case "PONTO BELO":
                case "PRESIDENTE KENNEDY":
                case "RIO BANANAL":
                case "RIO NOVO DO SUL":
                case "SANTA LEOPOLDINA":
                case "SANTA MARIA DE JETIBA":
                case "SANTA TERESA":
                case "SAO DOMINGOS DO NORTE":
                case "SAO GABRIEL DA PALHA":
                case "SAO JOSE DO CALCADO":
                case "SAO MATEUS":
                case "SAO ROQUE DO CANAA":
                case "SERRA":
                case "SOORETAMA":
                case "VARGEM ALTA":
                case "VENDA NOVA DO IMIGRANTE":
                case "VIANA":
                case "VILA PAVAO":
                case "VILA VALERIO":
                case "VILA VELHA":
                case "VITORIA":

                    return cidade + "/ES";

                case "GOIAS":
                case "ABADIA DE GOIAS":
                case "ABADIANIA":
                case "ACREUNA":
                case "ADELANDIA":
                case "AGUA FRIA DE GOIAS":
                case "AGUA LIMPA":
                case "AGUAS LINDAS DE GOIAS":
                case "ALEXANIA":
                case "ALOANDIA":
                case "ALTO HORIZONTE":
                case "ALTO PARAISO DE GOIAS":
                case "ALVORADA DO NORTE":
                case "AMARALINA":
                case "AMERICANO DO BRASIL":
                case "AMORINOPOLIS":
                case "ANAPOLIS":
                case "ANHANGUERA":
                case "ANICUNS":
                case "APARECIDA DE GOIANIA":
                case "APARECIDA DO RIO DOCE":
                case "APORE":
                case "ARACU":
                case "ARAGARCAS":
                case "ARAGOIANIA":
                case "ARAGUAPAZ":
                case "ARENOPOLIS":
                case "ARUANA":
                case "AURILANDIA":
                case "AVELINOPOLIS":
                case "BALIZA":
                //case "BARRO ALTO":
                case "BELA VISTA DE GOIAS":
                case "BOM JARDIM DE GOIAS":
                case "BOM JESUS DE GOIAS":
                case "BONFINOPOLIS":
                case "BONOPOLIS":
                case "BRAZABRANTES":
                case "BRITANIA":
                case "BURITI ALEGRE":
                case "BURITI DE GOIAS":
                case "BURITINOPOLIS":
                case "CABECEIRAS":
                case "CACHOEIRA ALTA":
                case "CACHOEIRA DE GOIAS":
                case "CACHOEIRA DOURADA":
                case "CACU":
                case "CAIAPONIA":
                case "CALDAS NOVAS":
                case "CALDAZINHA":
                case "CAMPESTRE DE GOIAS":
                case "CAMPINACU":
                case "CAMPINORTE":
                case "CAMPO ALEGRE DE GOIAS":
                case "CAMPOS LIMPO DE GOIAS":
                case "CAMPOS BELOS":
                case "CAMPOS VERDES":
                case "CARMO DO RIO VERDE":
                case "CASTELANDIA":
                case "CATALAO":
                case "CATURAI":
                case "CAVALCANTE":
                case "CERES":
                case "CEZARINA":
                case "CHAPADAO DO CEU":
                case "CIDADE OCIDENTAL":
                case "COCALZINHO DE GOIAS":
                case "COLINAS DO SUL":
                case "CORREGO DO OURO":
                case "CORUMBA DE GOIAS":
                case "CORUMBAIBA":
                case "CRISTALINA":
                case "CRISTIANOPOLIS":
                case "CRIXAS":
                case "CROMINIA":
                case "CUMARI":
                case "DAMIANOPOLIS":
                case "DAMOLANDIA":
                case "DAVINOPOLIS":
                case "DIORAMA":
                case "DIVINOPOLIS DE GOIAS":
                case "DOVERLANDIA":
                case "EDEALINA":
                case "EDEIA":
                case "ESTRELA DO NORTE":
                case "FAINA":
                case "FAZENDA NOVA":
                case "FIRMINOPOLIS":
                case "FLORES DE GOIAS":
                case "FORMOSA":
                case "FORMOSO":
                case "GAMELEIRA DE GOIAS":
                case "GOIANAPOLIS":
                case "GOIANDIRA":
                case "GOIANESIA":
                case "GOIANIA":
                case "GOIANIRA":
                //case "GOIAS":
                case "GOIATUBA":
                case "GOUVELANDIA":
                case "GUAPO":
                case "GUARAITA":
                case "GUARANI DE GOIAS":
                case "GUARINOS":
                case "HEITORAI":
                //case "HIDROLANDIA":
                case "HIDROLINA":
                case "IACIARA":
                case "INACIOLANDIA":
                case "INDIARA":
                case "INHUMAS":
                case "IPAMERI":
                case "IPIRANGA DE GOIAS":
                case "IPORA":
                case "ISRAELANDIA":
                case "ITABERAI":
                case "ITAGUARI":
                case "ITAGUARU":
                case "ITAJA":
                case "ITAPACI":
                case "ITAPIRAPUA":
                case "ITAPURANGA":
                case "ITARUMA":
                case "ITAUCU":
                case "ITUMBIARA":
                case "IVOLANDIA":
                case "JANDAIA":
                case "JARAGUA":
                case "JATAI":
                case "JAUPACI":
                case "JESUPOLIS":
                case "JOVIANIA":
                //case "JUSSARA":
                case "LAGOA SANTA":
                case "LEOPOLDO DE BULHOES":
                case "LUZIANIA":
                case "MAIRIPOTABA":
                case "MAMBAI":
                case "MARA ROSA":
                case "MARZAGAO":
                case "MATRINCHA":
                case "MAURILANDIA":
                case "MIMOSO DE GOIAS":
                case "MINACU":
                case "MINEIROS":
                case "MOIPORA":
                case "MONTE ALEGRE DE GOIAS":
                case "MONTES CLAROS DE GOIAS":
                case "MONTIVIDIU":
                case "MONTIVIDIU DO NORTE":
                //case "MORRINHOS":
                case "MORRO AGUDO DE GOIAS":
                case "MOSSAMEDES":
                case "MOZARLANDIA":
                //case "MUNDO NOVO":
                case "MUTUNOPOLIS":
                case "NAZARIO":
                case "NEROPOLIS":
                case "NIQUELANDIA":
                case "NOVA AMERICA":
                case "NOVA AURORA":
                case "NOVA CRIXAS":
                case "NOVA GLORIA":
                case "NOVA IGUACU DE GOIAS":
                case "NOVA ROMA":
                case "NOVA VENEZA":
                case "NOVO BRASIL":
                case "NOVO GAMA":
                case "NOVO PLANALTO":
                case "ORIZONA":
                case "OURO VERDE DE GOIAS":
                case "OUVIDOR":
                case "PADRE BERNARDO":
                case "PALESTINA DE GOIAS":
                case "PALMEIRAS DE GOIAS":
                case "PALMELO":
                case "PALMINOPOLIS":
                case "PANAMA":
                case "PARANAIGUARA":
                case "PARAUNA":
                case "PEROLANDIA":
                case "PETROLINA DE GOIAS":
                case "PILAR DE GOIAS":
                case "PIRACANJUBA":
                //case "PIRANHAS":
                case "PIRENOPOLIS":
                case "PIRES DO RIO":
                //case "PLANALTINA":
                case "PONTALINA":
                case "PORANGATU":
                case "PORTEIRAO":
                case "PORTELANDIA":
                case "POSSE":
                case "PROFESSOR JAMIL":
                case "QUIRINOPOLIS":
                case "RIALMA":
                case "RIANAPOLIS":
                case "RIO QUENTE":
                case "RIO VERDE":
                case "RUBIATABA":
                case "SANCLERLANDIA":
                case "SANTA BARBARA DE GOIAS":
                case "SANTA CRUZ DE GOIAS":
                case "SANTA FE DE GOIAS":
                case "SANTA HELENA DE GOIAS":
                case "SANTA ISABEL":
                case "SANTA RITA DO ARAGUAIA":
                case "SANTA RITA DO NOVO DESTINO":
                case "SANTA ROSA DE GOIAS":
                case "SANTA TEREZA DE GOIAS":
                case "SANTA TEREZINHA DE GOIAS":
                case "SANTO ANTONIO DA BARRA":
                case "SANTO ANTONIO DE GOIAS":
                case "SANTO ANTONIO DO DESCOBERTO":
                //case "SAO DOMINGOS":
                case "SAO FRANCISCO DE GOIAS":
                case "SAO JOAO D'ALIANCA":
                case "SAO JOAO DA PARAUNA":
                case "SAO LUIS DE MONTES BELOS":
                case "SAO LUIZ DO NORTE":
                case "SAO MIGUEL DO ARAGUAIA":
                case "SAO MIGUEL DO PASSA QUATRO":
                case "SAO PATRICIO":
                case "SAO SIMAO":
                case "SENADOR CANEDO":
                case "SERRANOPOLIS":
                case "SILVANIA":
                case "SIMOLANDIA":
                case "SITIO D'ABADIA":
                case "TAQUARAL DE GOIAS":
                case "TERESINA DE GOIAS":
                case "TEREZOPOLIS DE GOIAS":
                case "TRES RANCHOS":
                case "TRINDADE":
                case "TROMBAS":
                case "TURVANIA":
                case "TURVELANDIA":
                case "UIRAPURU":
                case "URUACU":
                case "URUANA":
                case "URUTAI":
                case "VALPARAISO DE GOIAS":
                //case "VARJAO":
                case "VIANOPOLIS":
                case "VICENTINOPOLIS":
                case "VILA BOA":
                case "VILA PROPICIO":

                    return cidade + "/GO";

                case "ACAILANDIA":
                case "AFONSO CUNHA":
                case "AGUA DOCE DO MARANHAO":
                case "ALCANTARA":
                case "ALDEIAS ALTAS":
                case "ALTAMIRA DO MARANHAO":
                case "ALTO ALEGRE DO MARANHAO":
                case "ALTO ALEGRE DO PINDARE":
                case "ALTO PARNAIBA":
                case "AMAPA DO MARANHAO":
                case "AMARANTE DO MARANHAO":
                case "ANAJATUBA":
                case "ANAPURUS":
                case "APICUM-ACU":
                case "ARAGUANA":
                case "ARAIOSES":
                case "ARAME":
                case "ARARI":
                case "AXIXA":
                case "BACABAL":
                case "BACABEIRA":
                case "BACURI":
                case "BACURITUBA":
                case "BALSAS":
                case "BARAO DE GRAJAU":
                case "BARRA DO CORDA":
                case "BARREIRINHAS":
                case "BELA VISTA DO MARANHAO":
                case "BELAGUA":
                case "BENEDITO LEITE":
                case "BEQUIMAO":
                case "BERNARDO DO MEARIM":
                case "BOA VISTA DO GURUPI":
                case "BOM JARDIM":
                case "BOM JESUS DAS SELVAS":
                case "BOM LUGAR":
                case "BREJO":
                case "BREJO DE AREIA":
                case "BURITI":
                case "BURITI BRAVO":
                case "BURITICUPU":
                case "BURITIRANA":
                case "CACHOEIRA GRANDE":
                case "CAJAPIO":
                case "CAJARI":
                case "CAMPESTRE DO MARANHAO":
                case "CANDIDO MENDES":
                case "CANTANHEDE":
                case "CAPINZAL DO NORTE":
                case "CAROLINA":
                case "CARUTAPERA":
                case "CAXIAS":
                case "CEDRAL":
                case "CENTRAL DO MARANHAO":
                case "CENTRO DO GUILHERME":
                case "CENTRO NOVO DO MARANHAO":
                case "CHAPADINHA":
                case "CIDELANDIA":
                case "CODO":
                case "COELHO NETO":
                case "COLINAS":
                case "CONCEICAO DO LAGO-ACU":
                case "COROATA":
                case "CURURUPU":
                //case "DAVINOPOLIS":
                case "DOM PEDRO":
                case "DUQUE BACELAR":
                case "ESPERANTINOPOLIS":
                case "ESTREITO":
                case "FEIRA NOVA DO MARANHAO":
                case "FERNANDO FALCAO":
                case "FORMOSA DA SERRA NEGRA":
                case "FORTALEZA DOS NOGUEIRAS":
                case "FORTUNA":
                case "GODOFREDO VIANA":
                case "GONCALVES DIAS":
                case "GOVERNADOR ARCHER":
                case "GOVERNADOR EDISON LOBAO":
                case "GOVERNADOR EUGENIO BARROS":
                case "GOVERNADOR LUIZ ROCHA":
                case "GOVERNADOR NEWTON BELLO":
                case "GOVERNADOR NUNES FREIRE":
                case "GRACA ARANHA":
                case "GRAJAU":
                case "GUIMARAES":
                case "HUMBERTO DE CAMPOS":
                case "ICATU":
                case "IGARAPE DO MEIO":
                case "IGARAPE GRANDE":
                case "IMPERATRIZ":
                case "ITAIPAVA DO GRAJAU":
                case "ITAPECURU MIRIM":
                case "ITINGA DO MARANHAO":
                case "JATOBA":
                case "JENIPAPO DOS VIEIRAS":
                case "JOAO LISBOA":
                case "JOSELANDIA":
                case "JUNCO DO MARANHAO":
                case "LAGO DA PEDRA":
                case "LAGO DO JUNCO":
                case "LAGO DOS RODRIGUES":
                case "LAGO VERDE":
                case "LAGOA DO MATO":
                case "LAGOA GRANDE DO MARANHAO":
                case "LAJEADO NOVO":
                case "LIMA CAMPOS":
                case "LORETO":
                case "LUIS DOMINGUES":
                case "MAGALHAES DE ALMEIDA":
                case "MARACACUME":
                case "MARAJA DO SENA":
                case "MARANHAOZINHO":
                case "MATA ROMA":
                case "MATINHA":
                case "MATOES":
                case "MATOES DO NORTE":
                case "MILAGRES DO MARANHAO":
                case "MIRADOR":
                case "MIRANDA DO NORTE":
                case "MIRINZAL":
                case "MONCAO":
                case "MONTES ALTOS":
                case "MORROS":
                case "NINA RODRIGUES":
                case "NOVA COLINAS":
                case "NOVA IORQUE":
                case "NOVA OLINDA DO MARANHAO":
                case "OLHO D'AGUA DAS CUNHAS":
                case "OLINDA NOVA DO MARANHAO":
                case "PACO DO LUMIAR":
                case "PALMEIRANDIA":
                case "PARAIBANO":
                case "PARNARAMA":
                case "PASSAGEM FRANCA":
                case "PASTOS BONS":
                case "PAULINO NEVES":
                case "PAULO RAMOS":
                case "PEDREIRAS":
                case "PEDRO DO ROSARIO":
                case "PENALVA":
                case "PERI MIRIM":
                case "PERITORO":
                case "PINDARE MIRIM":
                case "PINHEIRO":
                case "PIO XII":
                case "PIRAPEMAS":
                case "POCAO DE PEDRAS":
                case "PORTO FRANCO":
                case "PORTO RICO DO MARANHAO":
                //case "PRESIDENTE DUTRA":
                case "PRESIDENTE JUSCELINO":
                case "PRESIDENTE MEDICI":
                case "PRESIDENTE SARNEY":
                case "PRESIDENTE VARGAS":
                case "PRIMEIRA CRUZ":
                case "RAPOSA":
                case "RIACHAO":
                case "RIBAMAR FIQUENE":
                case "ROSARIO":
                case "SAMBAIBA":
                case "SANTA FILOMENA DO MARANHAO":
                case "SANTA HELENA":
                //case "SANTA INES":
                //case "SANTA LUZIA":
                case "SANTA LUZIA DO PARUA":
                case "SANTA QUITERIA DO MARANHAO":
                case "SANTA RITA":
                case "SANTANA DO MARANHAO":
                case "SANTO AMARO DO MARANHAO":
                case "SANTO ANTONIO DOS LOPES":
                case "SAO BENEDITO DO RIO PRETO":
                case "SAO BENTO":
                case "SAO BERNARDO":
                case "SAO DOMINGOS DO AZEITAO":
                case "SAO DOMINGOS DO MARANHAO":
                case "SAO FELIX DE BALSAS":
                case "SAO FRANCISCO DO BREJAO":
                case "SAO FRANCISCO DO MARANHAO":
                case "SAO JOAO BATISTA":
                case "SAO JOAO DO CARU":
                case "SAO JOAO DO PARAISO":
                case "SAO JOAO DO SOTER":
                case "SAO JOAO DOS PATOS":
                case "SAO JOSE DE RIBAMAR":
                case "SAO JOSE DOS BASILIOS":
                case "SAO LUIS":
                case "SAO LUIS GONZAGA DO MARANHAO":
                case "SAO MATEUS DO MARANHAO":
                case "SAO PEDRO DA AGUA BRANCA":
                case "SAO PEDRO DOS CRENTES":
                case "SAO RAIMUNDO DAS MANGABEIRAS":
                case "SAO RAIMUNDO DO DOCA BEZERRA":
                case "SAO ROBERTO":
                case "SAO VICENTE FERRER":
                case "SATUBINHA":
                case "SENADOR ALEXANDRE COSTA":
                case "SENADOR LA ROCQUE":
                case "SERRANO DO MARANHAO":
                case "SITIO NOVO":
                case "SUCUPIRA DO NORTE":
                case "SUCUPIRA DO RIACHAO":
                case "TASSO FRAGOSO":
                case "TIMBIRAS":
                case "TIMON":
                case "TRIZIDELA DO VALE":
                case "TUFILANDIA":
                case "TUNTUM":
                case "TURIACU":
                case "TURILANDIA":
                case "TUTOIA":
                case "URBANO SANTOS":
                case "VARGEM GRANDE":
                //case "VIANA":
                case "VILA NOVA DOS MARTIRIOS":
                case "VITORIA DO MEARIM":
                case "VITORINO FREIRE":
                case "ZE DOCA":

                    return cidade + "/MA";

                case "ABADIA DOS DOURADOS":
                case "ABAETE":
                case "ABRE CAMPO":
                case "ACAIACA":
                case "ACUCENA":
                case "AGUA BOA":
                case "AGUA COMPRIDA":
                case "AGUANIL":
                case "AGUAS FORMOSAS":
                case "AGUAS VERMELHAS":
                case "AIMORES":
                case "AIURUOCA":
                case "ALAGOA":
                case "ALBERTINA":
                case "ALEM PARAIBA":
                case "ALFENAS":
                case "ALFREDO VASCONCELOS":
                case "ALMENARA":
                case "ALPERCATA":
                case "ALPINOPOLIS":
                case "ALTEROSA":
                case "ALTO CAPARAO":
                case "ALTO JEQUITIBA":
                case "ALTO RIO DOCE":
                case "ALVARENGA":
                case "ALVINOPOLIS":
                case "ALVORADA DE MINAS":
                case "AMPARO DO SERRA":
                case "ANDRADAS":
                case "ANDRELANDIA":
                case "ANGELANDIA":
                case "ANTONIO CARLOS":
                case "ANTONIO DIAS":
                case "ANTONIO PRADO DE MINAS":
                case "ARACAI":
                case "ARACITABA":
                case "ARACUAI":
                case "ARAGUARI":
                case "ARANTINA":
                case "ARAPONGA":
                case "ARAPORA":
                case "ARAPUA":
                case "ARAUJOS":
                case "ARAXA":
                case "ARCEBURGO":
                case "ARCOS":
                case "AREADO":
                case "ARGIRITA":
                case "ARICANDUVA":
                case "ARINOS":
                case "ASTOLFO DUTRA":
                case "ATALEIA":
                case "AUGUSTO DE LIMA":
                case "BAEPENDI":
                case "BALDIM":
                case "BAMBUI":
                case "BANDEIRA":
                case "BANDEIRA DO SUL":
                case "BARAO DE COCAIS":
                case "BARAO DE MONTE ALTO":
                case "BARBACENA":
                case "BARRA LONGA":
                case "BARROSO":
                case "BELA VISTA DE MINAS":
                case "BELMIRO BRAGA":
                case "BELO HORIZONTE":
                case "BELO ORIENTE":
                case "BELO VALE":
                case "BERILO":
                case "BERIZAL":
                case "BERTOPOLIS":
                case "BETIM":
                case "BIAS FORTES":
                case "BICAS":
                case "BIQUINHAS":
                //case "BOA ESPERANCA":
                case "BOCAINA DE MINAS":
                case "BOCAIUVA":
                case "BOM DESPACHO":
                case "BOM JARDIM DE MINAS":
                case "BOM JESUS DA PENHA":
                case "BOM JESUS DO AMPARO":
                case "BOM JESUS DO GALHO":
                case "BOM REPOUSO":
                case "BOM SUCESSO":
                case "BONFIM":
                case "BONFINOPOLIS DE MINAS":
                case "BONITO DE MINAS":
                case "BORDA DA MATA":
                case "BOTELHOS":
                case "BOTUMIRIM":
                case "BRAS PIRES":
                case "BRASILANDIA DE MINAS":
                case "BRASILIA DE MINAS":
                case "BRASOPOLIS":
                case "BRAUNAS":
                case "BRUMADINHO":
                case "BUENO BRANDAO":
                case "BUENOPOLIS":
                case "BUGRE":
                case "BURITIS":
                case "BURITIZEIRO":
                case "CABECEIRA GRANDE":
                case "CABO VERDE":
                case "CACHOEIRA DA PRATA":
                case "CACHOEIRA DE MINAS":
                case "CACHOEIRA DE PAJEU":
                //case "CACHOEIRA DOURADA":
                case "CAETANOPOLIS":
                case "CAETE":
                case "CAIANA":
                case "CAJURI":
                case "CALDAS":
                case "CAMACHO":
                case "CAMANDUCAIA":
                case "CAMBUI":
                case "CAMBUQUIRA":
                case "CAMPANARIO":
                case "CAMPANHA":
                //case "CAMPESTRE":
                case "CAMPINA VERDE":
                case "CAMPO AZUL":
                case "CAMPO BELO":
                case "CAMPO DO MEIO":
                case "CAMPO FLORIDO":
                case "CAMPOS ALTOS":
                case "CAMPOS GERAIS":
                case "CANA VERDE":
                case "CANAA":
                //case "CANAPOLIS":
                //case "CANDEIAS":
                case "CANTAGALO":
                case "CAPARAO":
                case "CAPELA NOVA":
                case "CAPELINHA":
                case "CAPETINGA":
                case "CAPIM BRANCO":
                case "CAPINOPOLIS":
                case "CAPITAO ANDRADE":
                case "CAPITAO ENEAS":
                case "CAPITOLIO":
                case "CAPUTIRA":
                case "CARAI":
                case "CARANAIBA":
                case "CARANDAI":
                case "CARANGOLA":
                case "CARATINGA":
                case "CARBONITA":
                case "CAREACU":
                case "CARLOS CHAGAS":
                case "CARMESIA":
                case "CARMO DA CACHOEIRA":
                case "CARMO DA MATA":
                case "CARMO DE MINAS":
                case "CARMO DO CAJURU":
                case "CARMO DO PARANAIBA":
                case "CARMO DO RIO CLARO":
                case "CARMOPOLIS DE MINAS":
                case "CARNEIRINHO":
                case "CARRANCAS":
                case "CARVALHOPOLIS":
                case "CARVALHOS":
                case "CASA GRANDE":
                case "CASCALHO RICO":
                case "CASSIA":
                case "CATAGUASES":
                case "CATAS ALTAS":
                case "CATAS ALTAS DA NORUEGA":
                case "CATUJI":
                case "CATUTI":
                case "CAXAMBU":
                case "CEDRO DO ABAETE":
                case "CENTRAL DE MINAS":
                case "CENTRALINA":
                case "CHACARA":
                case "CHALE":
                case "CHAPADA DO NORTE":
                case "CHAPADA GAUCHA":
                case "CHIADOR":
                case "CIPOTANEA":
                case "CLARAVAL":
                case "CLARO DOS POCOES":
                case "CLAUDIO":
                case "COIMBRA":
                case "COLUNA":
                case "COMENDADOR GOMES":
                case "COMERCINHO":
                case "CONCEICAO DA APARECIDA":
                case "CONCEICAO DA BARRA DE MINAS":
                case "CONCEICAO DAS ALAGOAS":
                case "CONCEICAO DAS PEDRAS":
                case "CONCEICAO DE IPANEMA":
                case "CONCEICAO DO MATO DENTRO":
                case "CONCEICAO DO PARA":
                case "CONCEICAO DO RIO VERDE":
                case "CONCEICAO DOS OUROS":
                case "CONEGO MARINHO":
                case "CONFINS":
                case "CONGONHAL":
                case "CONGONHAS":
                case "CONGONHAS DO NORTE":
                case "CONQUISTA":
                case "CONSELHEIRO LAFAIETE":
                case "CONSELHEIRO PENA":
                case "CONSOLACAO":
                case "CONTAGEM":
                case "COQUEIRAL":
                case "CORACAO DE JESUS":
                case "CORDISBURGO":
                case "CORDISLANDIA":
                case "CORINTO":
                case "COROACI":
                case "COROMANDEL":
                case "CORONEL FABRICIANO":
                case "CORONEL MURTA":
                case "CORONEL PACHECO":
                case "CORONEL XAVIER CHAVES":
                case "CORREGO DANTA":
                case "CORREGO DO BOM JESUS":
                case "CORREGO FUNDO":
                case "CORREGO NOVO":
                case "COUTO DE MAGALHAES DE MINAS":
                case "CRISOLITA":
                case "CRISTAIS":
                case "CRISTALIA":
                case "CRISTIANO OTONI":
                case "CRISTINA":
                case "CRUCILANDIA":
                case "CRUZEIRO DA FORTALEZA":
                case "CRUZILIA":
                case "CUPARAQUE":
                case "CURRAL DE DENTRO":
                case "CURVELO":
                case "DATAS":
                case "DELFIM MOREIRA":
                case "DELFINOPOLIS":
                case "DELTA":
                case "DESCOBERTO":
                case "DESTERRO DE ENTRE RIOS":
                case "DESTERRO DO MELO":
                case "DIAMANTINA":
                case "DIOGO DE VASCONCELOS":
                case "DIONISIO":
                case "DIVINESIA":
                case "DIVINO":
                case "DIVINO DAS LARANJEIRAS":
                case "DIVINOLANDIA DE MINAS":
                case "DIVINOPOLIS":
                case "DIVISA ALEGRE":
                case "DIVISA NOVA":
                case "DIVISOPOLIS":
                case "DOM BOSCO":
                case "DOM CAVATI":
                case "DOM JOAQUIM":
                case "DOM SILVERIO":
                case "DOM VICOSO":
                case "DONA EUZEBIA":
                case "DORES DE CAMPOS":
                case "DORES DE GUANHAES":
                case "DORES DO INDAIA":
                case "DORES DO TURVO":
                case "DORESOPOLIS":
                case "DOURADOQUARA":
                case "DURANDE":
                case "ELOI MENDES":
                case "ENGENHEIRO CALDAS":
                case "ENGENHEIRO NAVARRO":
                case "ENTRE FOLHAS":
                case "ENTRE RIOS DE MINAS":
                case "ERVALIA":
                case "ESMERALDAS":
                case "ESPERA FELIZ":
                case "ESPINOSA":
                case "ESPIRITO SANTO DO DOURADO":
                case "ESTIVA":
                case "ESTRELA DALVA":
                case "ESTRELA DO INDAIA":
                case "ESTRELA DO SUL":
                case "EUGENOPOLIS":
                case "EWBANK DA CAMARA":
                case "EXTREMA":
                case "FAMA":
                case "FARIA LEMOS":
                case "FELICIO DOS SANTOS":
                case "FELISBURGO":
                case "FELIXLANDIA":
                case "FERNANDES TOURINHO":
                case "FERROS":
                case "FERVEDOURO":
                case "FLORESTAL":
                case "FORMIGA":
                //case "FORMOSO":
                case "FORTALEZA DE MINAS":
                case "FORTUNA DE MINAS":
                case "FRANCISCO BADARO":
                case "FRANCISCO DUMONT":
                case "FRANCISCO SA":
                case "FRANCISCOPOLIS":
                case "FREI GASPAR":
                case "FREI INOCENCIO":
                case "FREI LAGONEGRO":
                case "FRONTEIRA":
                case "FRONTEIRA DOS VALES":
                case "FRUTA DE LEITE":
                case "FRUTAL":
                case "FUNILANDIA":
                case "GALILEIA":
                case "GAMELEIRAS":
                case "GLAUCILANDIA":
                case "GOIABEIRA":
                case "GOIANA":
                case "GONCALVES":
                case "GONZAGA":
                case "GOUVEIA":
                case "GOVERNADOR VALADARES":
                case "GRAO MOGOL":
                case "GRUPIARA":
                case "GUANHAES":
                case "GUAPE":
                case "GUARACIABA":
                case "GUARACIAMA":
                case "GUARANESIA":
                case "GUARANI":
                case "GUARARA":
                case "GUARDA-MOR":
                case "GUAXUPE":
                case "GUIDOVAL":
                case "GUIMARANIA":
                case "GUIRICEMA":
                case "GURINHATA":
                case "HELIODORA":
                case "IAPU":
                case "IBERTIOGA":
                case "IBIA":
                case "IBIAI":
                case "IBIRACATU":
                case "IBIRACI":
                case "IBIRITE":
                case "IBITIURA DE MINAS":
                case "IBITURUNA":
                case "ICARAI DE MINAS":
                case "IGARAPE":
                case "IGARATINGA":
                case "IGUATAMA":
                case "IJACI":
                case "ILICINEA":
                case "IMBE DE MINAS":
                case "INCONFIDENTES":
                case "INDAIABIRA":
                case "INDIANOPOLIS":
                case "INGAI":
                case "INHAPIM":
                case "INHAUMA":
                case "INIMUTABA":
                case "IPABA":
                case "IPANEMA":
                case "IPATINGA":
                case "IPIACU":
                case "IPUIUNA":
                case "IRAI DE MINAS":
                case "ITABIRA":
                case "ITABIRINHA DE MANTENA":
                case "ITABIRITO":
                case "ITACAMBIRA":
                case "ITACARAMBI":
                case "ITAGUARA":
                case "ITAIPE":
                case "ITAJUBA":
                case "ITAMARANDIBA":
                case "ITAMARATI DE MINAS":
                case "ITAMBACURI":
                case "ITAMBE DO MATO DENTRO":
                case "ITAMOGI":
                case "ITAMONTE":
                case "ITANHANDU":
                case "ITANHOMI":
                case "ITAOBIM":
                case "ITAPAGIPE":
                case "ITAPECERICA":
                case "ITAPEVA":
                case "ITATIAIUCU":
                case "ITAU DE MINAS":
                case "ITAUNA":
                case "ITAVERAVA":
                case "ITINGA":
                case "ITUETA":
                case "ITUIUTABA":
                case "ITUMIRIM":
                case "ITURAMA":
                case "ITUTINGA":
                case "JABOTICATUBAS":
                case "JACINTO":
                case "JACUI":
                case "JACUTINGA":
                case "JAGUARACU":
                case "JAIBA":
                case "JAMPRUCA":
                case "JANAUBA":
                case "JANUARIA":
                case "JAPARAIBA":
                case "JAPONVAR":
                case "JECEABA":
                case "JENIPAPO DE MINAS":
                case "JEQUERI":
                case "JEQUITAI":
                case "JEQUITIBA":
                case "JEQUITINHONHA":
                case "JESUANIA":
                case "JOAIMA":
                case "JOANESIA":
                case "JOAO MONLEVADE":
                case "JOAO PINHEIRO":
                case "JOAQUIM FELICIO":
                case "JORDANIA":
                case "JOSE GONCALVES DE MINAS":
                case "JOSE RAYDAN":
                case "JOSENOPOLIS":
                case "JUATUBA":
                case "JUIZ DE FORA":
                case "JURAMENTO":
                case "JURUAIA":
                case "JUVENILIA":
                case "LADAINHA":
                case "LAGAMAR":
                case "LAGOA DA PRATA":
                case "LAGOA DOS PATOS":
                case "LAGOA DOURADA":
                case "LAGOA FORMOSA":
                case "LAGOA GRANDE":
                //case "LAGOA SANTA":
                case "LAJINHA":
                case "LAMBARI":
                case "LAMIM":
                case "LARANJAL":
                case "LASSANCE":
                case "LAVRAS":
                case "LEANDRO FERREIRA":
                case "LEME DO PRADO":
                case "LEOPOLDINA":
                case "LIBERDADE":
                case "LIMA DUARTE":
                case "LIMEIRA DO OESTE":
                case "LONTRA":
                case "LUISBURGO":
                case "LUISLANDIA":
                case "LUMINARIAS":
                case "LUZ":
                case "MACHACALIS":
                case "MACHADO":
                case "MADRE DE DEUS DE MINAS":
                case "MALACACHETA":
                case "MAMONAS":
                case "MANGA":
                case "MANHUACU":
                case "MANHUMIRIM":
                case "MANTENA":
                case "MAR DE ESPANHA":
                case "MARAVILHAS":
                case "MARIA DA FE":
                case "MARIANA":
                case "MARILAC":
                case "MARIO CAMPOS":
                case "MARIPA DE MINAS":
                case "MARLIERIA":
                case "MARMELOPOLIS":
                case "MARTINHO CAMPOS":
                case "MARTINS SOARES":
                case "MATA VERDE":
                case "MATERLANDIA":
                case "MATEUS LEME":
                case "MATHIAS LOBATO":
                case "MATIAS BARBOSA":
                case "MATIAS CARDOSO":
                case "MATIPO":
                case "MATO VERDE":
                case "MATOZINHOS":
                case "MATUTINA":
                case "MEDEIROS":
                case "MEDINA":
                case "MENDES PIMENTEL":
                case "MERCES":
                case "MESQUITA":
                case "MINAS NOVAS":
                case "MINDURI":
                case "MIRABELA":
                case "MIRADOURO":
                case "MIRAI":
                case "MIRAVANIA":
                case "MOEDA":
                case "MOEMA":
                case "MONJOLOS":
                case "MONSENHOR PAULO":
                case "MONTALVANIA":
                case "MONTE ALEGRE DE MINAS":
                case "MONTE AZUL":
                case "MONTE BELO":
                case "MONTE CARMELO":
                case "MONTE FORMOSO":
                case "MONTE SANTO DE MINAS":
                case "MONTE SIAO":
                case "MONTES CLAROS":
                case "MONTEZUMA":
                case "MORADA NOVA DE MINAS":
                case "MORRO DA GARCA":
                case "MORRO DO PILAR":
                case "MUNHOZ":
                case "MURIAE":
                case "MUTUM":
                case "MUZAMBINHO":
                case "NACIP RAYDAN":
                case "NANUQUE":
                case "NAQUE":
                case "NATALANDIA":
                case "NATERCIA":
                case "NAZARENO":
                case "NEPOMUCENO":
                case "NINHEIRA":
                case "NOVA BELEM":
                case "NOVA ERA":
                case "NOVA LIMA":
                case "NOVA MODICA":
                case "NOVA PONTE":
                case "NOVA PORTEIRINHA":
                case "NOVA RESENDE":
                case "NOVA SERRANA":
                case "NOVA UNIAO":
                case "NOVO CRUZEIRO":
                case "NOVO ORIENTE DE MINAS":
                case "NOVORIZONTE":
                case "OLARIA":
                case "OLHOS-D'AGUA":
                case "OLIMPIO NORONHA":
                case "OLIVEIRA":
                case "OLIVEIRA FORTES":
                case "ONCA DE PITANGUI":
                case "ORATORIOS":
                case "ORIZANIA":
                //case "OURO BRANCO":
                case "OURO FINO":
                case "OURO PRETO":
                case "OURO VERDE DE MINAS":
                case "PADRE CARVALHO":
                case "PADRE PARAISO":
                case "PAI PEDRO":
                case "PAINEIRAS":
                case "PAINS":
                case "PAIVA":
                case "PALMA":
                case "PALMOPOLIS":
                case "PAPAGAIOS":
                case "PARA DE MINAS":
                case "PARACATU":
                case "PARAGUACU":
                case "PARAISOPOLIS":
                case "PARAOPEBA":
                case "PASSA QUATRO":
                case "PASSA TEMPO":
                case "PASSA-VINTE":
                case "PASSABEM":
                case "PASSOS":
                case "PATIS":
                case "PATOS DE MINAS":
                case "PATROCINIO":
                case "PATROCINIO DO MURIAE":
                case "PAULA CANDIDO":
                case "PAULISTAS":
                case "PAVAO":
                case "PECANHA":
                case "PEDRA AZUL":
                case "PEDRA BONITA":
                case "PEDRA DO ANTA":
                case "PEDRA DO INDAIA":
                case "PEDRA DOURADA":
                case "PEDRALVA":
                case "PEDRAS DE MARIA DA CRUZ":
                case "PEDRINOPOLIS":
                case "PEDRO LEOPOLDO":
                case "PEDRO TEIXEIRA":
                case "PEQUERI":
                case "PEQUI":
                case "PERDIGAO":
                case "PERDIZES":
                case "PERDOES":
                case "PERIQUITO":
                case "PESCADOR":
                case "PIAU":
                case "PIEDADE DE CARATINGA":
                case "PIEDADE DE PONTE NOVA":
                case "PIEDADE DO RIO GRANDE":
                case "PIEDADE DOS GERAIS":
                case "PIMENTA":
                case "PINGO-D'AGUA":
                case "PINTOPOLIS":
                case "PIRACEMA":
                case "PIRAJUBA":
                case "PIRANGA":
                case "PIRANGUCU":
                case "PIRANGUINHO":
                case "PIRAPETINGA":
                case "PIRAPORA":
                case "PIRAUBA":
                case "PITANGUI":
                case "PIUMHI":
                case "PLANURA":
                case "POCO FUNDO":
                case "POCOS DE CALDAS":
                case "POCRANE":
                case "POMPEU":
                case "PONTE NOVA":
                case "PONTO CHIQUE":
                case "PONTO DOS VOLANTES":
                case "PORTEIRINHA":
                case "PORTO FIRME":
                case "POTE":
                case "POUSO ALEGRE":
                case "POUSO ALTO":
                case "PRADOS":
                case "PRATA":
                case "PRATAPOLIS":
                case "PRATINHA":
                case "PRESIDENTE BERNARDES":
                //case "PRESIDENTE JUSCELINO":
                case "PRESIDENTE KUBITSCHEK":
                case "PRESIDENTE OLEGARIO":
                case "PRUDENTE DE MORAIS":
                case "QUARTEL GERAL":
                case "QUELUZITO":
                case "RAPOSOS":
                case "RAUL SOARES":
                case "RECREIO":
                case "REDUTO":
                case "RESENDE COSTA":
                case "RESPLENDOR":
                case "RESSAQUINHA":
                case "RIACHINHO":
                case "RIACHO DOS MACHADOS":
                case "RIBEIRAO DAS NEVES":
                case "RIBEIRAO VERMELHO":
                case "RIO ACIMA":
                case "RIO CASCA":
                case "RIO DO PRADO":
                case "RIO DOCE":
                case "RIO ESPERA":
                case "RIO MANSO":
                case "RIO NOVO":
                case "RIO PARANAIBA":
                case "RIO PARDO DE MINAS":
                case "RIO PIRACICABA":
                case "RIO POMBA":
                case "RIO PRETO":
                case "RIO VERMELHO":
                case "RITAPOLIS":
                case "ROCHEDO DE MINAS":
                case "RODEIRO":
                case "ROMARIA":
                case "ROSARIO DA LIMEIRA":
                case "RUBELITA":
                case "RUBIM":
                case "SABARA":
                case "SABINOPOLIS":
                case "SACRAMENTO":
                case "SALINAS":
                case "SALTO DA DIVISA":
                //case "SANTA BARBARA":
                case "SANTA BARBARA DO LESTE":
                case "SANTA BARBARA DO MONTE VERDE":
                case "SANTA BARBARA DO TUGURIO":
                case "SANTA CRUZ DE MINAS":
                case "SANTA CRUZ DE SALINAS":
                case "SANTA CRUZ DO ESCALVADO":
                case "SANTA EFIGENIA DE MINAS":
                case "SANTA FE DE MINAS":
                case "SANTA HELENA DE MINAS":
                case "SANTA JULIANA":
                //case "SANTA LUZIA":
                case "SANTA MARGARIDA":
                case "SANTA MARIA DE ITABIRA":
                case "SANTA MARIA DO SALTO":
                case "SANTA MARIA DO SUACUI":
                case "SANTA RITA DE CALDAS":
                case "SANTA RITA DE IBITIPOCA":
                case "SANTA RITA DE JACUTINGA":
                case "SANTA RITA DE MINAS":
                case "SANTA RITA DO ITUETO":
                case "SANTA RITA DO SAPUCAI":
                case "SANTA ROSA DA SERRA":
                case "SANTA VITORIA":
                case "SANTANA DA VARGEM":
                case "SANTANA DE CATAGUASES":
                case "SANTANA DE PIRAPAMA":
                case "SANTANA DO DESERTO":
                case "SANTANA DO GARAMBEU":
                case "SANTANA DO JACARE":
                case "SANTANA DO MANHUACU":
                case "SANTANA DO PARAISO":
                case "SANTANA DO RIACHO":
                case "SANTANA DOS MONTES":
                case "SANTO ANTONIO DO AMPARO":
                case "SANTO ANTONIO DO AVENTUREIRO":
                case "SANTO ANTONIO DO GRAMA":
                case "SANTO ANTONIO DO ITAMBE":
                case "SANTO ANTONIO DO JACINTO":
                case "SANTO ANTONIO DO MONTE":
                case "SANTO ANTONIO DO RETIRO":
                case "SANTO ANTONIO DO RIO ABAIXO":
                case "SANTO HIPOLITO":
                case "SANTOS DUMONT":
                case "SAO BENTO ABADE":
                case "SAO BRAS DO SUACUI":
                case "SAO DOMINGOS DAS DORES":
                case "SAO DOMINGOS DO PRATA":
                case "SAO FELIX DE MINAS":
                case "SAO FRANCISCO":
                case "SAO FRANCISCO DE PAULA":
                case "SAO FRANCISCO DE SALES":
                case "SAO FRANCISCO DO GLORIA":
                case "SAO GERALDO":
                case "SAO GERALDO DA PIEDADE":
                case "SAO GERALDO DO BAIXIO":
                case "SAO GONCALO DO ABAETE":
                case "SAO GONCALO DO PARA":
                case "SAO GONCALO DO RIO ABAIXO":
                case "SAO GONCALO DO RIO PRETO":
                case "SAO GONCALO DO SAPUCAI":
                case "SAO GOTARDO":
                case "SAO JOAO BATISTA DO GLORIA":
                case "SAO JOAO DA LAGOA":
                case "SAO JOAO DA MATA":
                case "SAO JOAO DA PONTE":
                case "SAO JOAO DAS MISSOES":
                case "SAO JOAO DEL REI":
                case "SAO JOAO DO MANHUACU":
                case "SAO JOAO DO MANTENINHA":
                case "SAO JOAO DO ORIENTE":
                case "SAO JOAO DO PACUI":
                //case "SAO JOAO DO PARAISO":
                case "SAO JOAO EVANGELISTA":
                case "SAO JOAO NEPOMUCENO":
                case "SAO JOAQUIM DE BICAS":
                case "SAO JOSE DA BARRA":
                case "SAO JOSE DA LAPA":
                case "SAO JOSE DA SAFIRA":
                case "SAO JOSE DA VARGINHA":
                case "SAO JOSE DO ALEGRE":
                case "SAO JOSE DO DIVINO":
                case "SAO JOSE DO GOIABAL":
                case "SAO JOSE DO JACURI":
                case "SAO JOSE DO MANTIMENTO":
                case "SAO LOURENCO":
                case "SAO MIGUEL DO ANTA":
                case "SAO PEDRO DA UNIAO":
                case "SAO PEDRO DO SUACUI":
                case "SAO PEDRO DOS FERROS":
                case "SAO ROMAO":
                case "SAO ROQUE DE MINAS":
                case "SAO SEBASTIAO DA BELA VISTA":
                case "SAO SEBASTIAO DA VARGEM ALEGRE":
                case "SAO SEBASTIAO DO ANTA":
                case "SAO SEBASTIAO DO MARANHAO":
                case "SAO SEBASTIAO DO OESTE":
                case "SAO SEBASTIAO DO PARAISO":
                case "SAO SEBASTIAO DO RIO PRETO":
                case "SAO SEBASTIAO DO RIO VERDE":
                case "SAO THOME DAS LETRAS":
                case "SAO TIAGO":
                case "SAO TOMAS DE AQUINO":
                case "SAO VICENTE DE MINAS":
                case "SAPUCAI-MIRIM":
                case "SARDOA":
                case "SARZEDO":
                case "SEM-PEIXE":
                case "SENADOR AMARAL":
                case "SENADOR CORTES":
                case "SENADOR FIRMINO":
                case "SENADOR JOSE BENTO":
                case "SENADOR MODESTINO GONCALVES":
                case "SENHORA DE OLIVEIRA":
                case "SENHORA DO PORTO":
                case "SENHORA DOS REMEDIOS":
                case "SERICITA":
                case "SERITINGA":
                case "SERRA AZUL DE MINAS":
                case "SERRA DA SAUDADE":
                case "SERRA DO SALITRE":
                case "SERRA DOS AIMORES":
                case "SERRANIA":
                case "SERRANOPOLIS DE MINAS":
                case "SERRANOS":
                case "SERRO":
                case "SETE LAGOAS":
                case "SETUBINHA":
                case "SILVEIRANIA":
                case "SILVIANOPOLIS":
                case "SIMAO PEREIRA":
                case "SIMONESIA":
                case "SOBRALIA":
                case "SOLEDADE DE MINAS":
                case "TABULEIRO":
                case "TAIOBEIRAS":
                case "TAPARUBA":
                case "TAPIRA":
                case "TAPIRAI":
                case "TAQUARACU DE MINAS":
                case "TARUMIRIM":
                case "TEIXEIRAS":
                case "TEOFILO OTONI":
                case "TIMOTEO":
                case "TIRADENTES":
                case "TIROS":
                case "TOCANTINS":
                case "TOCOS DO MOJI":
                case "TOLEDO":
                case "TOMBOS":
                case "TRES CORACOES":
                case "TRES MARIAS":
                case "TRES PONTAS":
                case "TUMIRITINGA":
                case "TUPACIGUARA":
                case "TURMALINA":
                case "TURVOLANDIA":
                case "UBA":
                case "UBAI":
                case "UBAPORANGA":
                case "UBERABA":
                case "UBERLANDIA":
                case "UMBURATIBA":
                case "UNAI":
                case "UNIAO DE MINAS":
                case "URUANA DE MINAS":
                case "URUCANIA":
                case "URUCUIA":
                case "VARGEM ALEGRE":
                case "VARGEM BONITA":
                case "VARGEM GRANDE DO RIO PARDO":
                case "VARGINHA":
                case "VARJAO DE MINAS":
                case "VARZEA DA PALMA":
                case "VARZELANDIA":
                case "VAZANTE":
                case "VERDELANDIA":
                case "VEREDINHA":
                case "VERISSIMO":
                case "VERMELHO NOVO":
                case "VESPASIANO":
                //case "VICOSA":
                case "VIEIRAS":
                case "VIRGEM DA LAPA":
                case "VIRGINIA":
                case "VIRGINOPOLIS":
                case "VIRGOLANDIA":
                case "VISCONDE DO RIO BRANCO":
                case "VOLTA GRANDE":
                case "WENCESLAU BRAZ":

                    return cidade + "/MG";

                case "AGUA CLARA":
                case "ALCINOPOLIS":
                case "AMAMBAI":
                case "ANASTACIO":
                case "ANAURILANDIA":
                case "ANGELICA":
                case "ANTONIO JOAO":
                case "APARECIDA DO TABOADO":
                case "AQUIDAUANA":
                case "ARAL MOREIRA":
                case "BANDEIRANTES":
                case "BATAGUASSU":
                case "BATAIPORA":
                case "BELA VISTA":
                case "BODOQUENA":
                //case "BONITO":
                case "BRASILANDIA":
                case "CAARAPO":
                case "CAMAPUA":
                //case "CAMPO GRANDE":
                case "CARACOL":
                case "CASSILANDIA":
                case "CHAPADAO DO SUL":
                case "CORGUINHO":
                case "CORONEL SAPUCAIA":
                case "CORUMBA":
                case "COSTA RICA":
                case "COXIM":
                case "DEODAPOLIS":
                case "DOIS IRMAOS DO BURITI":
                case "DOURADINA":
                case "DOURADOS":
                case "ELDORADO":
                case "FATIMA DO SUL":
                case "GLORIA DE DOURADOS":
                case "GUIA LOPES DA LAGUNA":
                case "IGUATEMI":
                case "INOCENCIA":
                case "ITAPORA":
                case "ITAQUIRAI":
                case "IVINHEMA":
                case "JAPORA":
                case "JARAGUARI":
                //case "JARDIM":
                case "JATEI":
                case "JUTI":
                case "LADARIO":
                case "LAGUNA CARAPA":
                case "MARACAJU":
                case "MIRANDA":
                //case "MUNDO NOVO":
                case "NAVIRAI":
                case "NIOAQUE":
                case "NOVA ALVORADA DO SUL":
                case "NOVA ANDRADINA":
                case "NOVO HORIZONTE DO SUL":
                case "PARANAIBA":
                case "PARANHOS":
                case "PEDRO GOMES":
                case "PONTA PORA":
                case "PORTO MURTINHO":
                case "RIBAS DO RIO PARDO":
                case "RIO BRILHANTE":
                case "RIO NEGRO":
                case "RIO VERDE DE MATO GROSSO":
                case "ROCHEDO":
                case "SANTA RITA DO PARDO":
                case "SAO GABRIEL DO OESTE":
                case "SELVIRIA":
                case "SETE QUEDAS":
                case "SIDROLANDIA":
                case "SONORA":
                case "TACURU":
                case "TAQUARUSSU":
                case "TERENOS":
                case "TRES LAGOAS":
                case "VICENTINA":

                    return cidade + "/MS";

                case "MATO GROSSO":
                case "ACORIZAL":
                //case "AGUA BOA":
                case "ALTA FLORESTA":
                case "ALTO ARAGUAIA":
                case "ALTO BOA VISTA":
                case "ALTO GARCAS":
                case "ALTO PARAGUAI":
                case "ALTO TAQUARI":
                case "APIACAS":
                case "ARAGUAIANA":
                case "ARAGUAINHA":
                case "ARAPUTANGA":
                case "ARENAPOLIS":
                case "ARIPUANA":
                case "BARAO DE MELGACO":
                case "BARRA DO BUGRES":
                case "BARRA DO GARCAS":
                case "BOM JESUS DO ARAGUAIA":
                case "BRASNORTE":
                case "CACERES":
                case "CAMPINAPOLIS":
                case "CAMPO NOVO DO PARECIS":
                case "CAMPO VERDE":
                case "CAMPOS DE JULIO":
                case "CANABRAVA DO NORTE":
                //case "CANARANA":
                case "CARLINDA":
                case "CASTANHEIRA":
                case "CHAPADA DOS GUIMARAES":
                case "CLAUDIA":
                case "COCALINHO":
                case "COLIDER":
                case "COLNIZA":
                case "COMODORO":
                case "CONFRESA":
                case "CONQUISTA D'OESTE":
                case "COTRIGUACU":
                case "CURVELANDIA":
                case "CUIABA":
                case "DENISE":
                case "DIAMANTINO":
                case "DOM AQUINO":
                case "FELIZ NATAL":
                case "FIGUEIROPOLIS D'OESTE":
                case "GAUCHA DO NORTE":
                case "GENERAL CARNEIRO":
                case "GLORIA D'OESTE":
                case "GUARANTA DO NORTE":
                case "GUIRATINGA":
                case "INDIAVAI":
                case "ITAUBA":
                case "ITIQUIRA":
                case "JACIARA":
                case "JANGADA":
                case "JAURU":
                case "JUARA":
                case "JUINA":
                case "JURUENA":
                case "JUSCIMEIRA":
                case "LAMBARI D'OESTE":
                case "LUCAS DO RIO VERDE":
                case "LUCIARA":
                case "MARCELANDIA":
                case "MATUPA":
                case "MIRASSOL D'OESTE":
                case "NOBRES":
                case "NORTELANDIA":
                case "NOSSA SENHORA DO LIVRAMENTO":
                case "NOVA BANDEIRANTES":
                case "NOVA BRASILANDIA":
                case "NOVA CANAA DO NORTE":
                case "NOVA GUARITA":
                case "NOVA LACERDA":
                case "NOVA MARILANDIA":
                case "NOVA MARINGA":
                case "NOVA MONTE VERDE":
                case "NOVA MUTUM":
                case "NOVA NAZARE":
                case "NOVA OLIMPIA":
                case "NOVA SANTA HELENA":
                case "NOVA UBIRATA":
                case "NOVA XAVANTINA":
                case "NOVO HORIZONTE DO NORTE":
                case "NOVO MUNDO":
                case "NOVO SANTO ANTONIO":
                case "NOVO SAO JOAQUIM":
                case "PARANAITA":
                case "PARANATINGA":
                case "PEDRA PRETA":
                case "PEIXOTO DE AZEVEDO":
                case "PLANALTO DA SERRA":
                case "POCONE":
                case "PONTAL DO ARAGUAIA":
                case "PONTE BRANCA":
                case "PONTES E LACERDA":
                case "PORTO ALEGRE DO NORTE":
                case "PORTO DOS GAUCHOS":
                case "PORTO ESPERIDIAO":
                case "PORTO ESTRELA":
                case "POXOREO":
                case "PRIMAVERA DO LESTE":
                case "QUERENCIA":
                case "RESERVA DO CABACAL":
                case "RIBEIRAO CASCALHEIRA":
                case "RIBEIRAOZINHO":
                //case "RIO BRANCO":
                case "RONDOLANDIA":
                case "RONDONOPOLIS":
                case "ROSARIO OESTE":
                case "SALTO DO CEU":
                case "SANTA CARMEM":
                case "SANTA CRUZ DO XINGU":
                case "SANTA RITA DO TRIVELATO":
                case "SANTA TEREZINHA":
                case "SANTO AFONSO":
                case "SANTO ANTONIO DO LESTE":
                case "SANTO ANTONIO DO LEVERGER":
                case "SAO FELIX DO ARAGUAIA":
                case "SAO JOSE DO POVO":
                case "SAO JOSE DO RIO CLARO":
                case "SAO JOSE DO XINGU":
                case "SAO JOSE DOS QUATRO MARCOS":
                case "SAO PEDRO DA CIPA":
                case "SAPEZAL":
                case "SERRA NOVA DOURADA":
                case "SINOP":
                case "SORRISO":
                case "TABAPORA":
                case "TANGARA DA SERRA":
                case "TAPURAH":
                case "TERRA NOVA DO NORTE":
                case "TESOURO":
                case "TORIXOREU":
                case "UNIAO DO SUL":
                case "VALE DE SAO DOMINGOS":
                case "VARZEA GRANDE":
                case "VERA":
                case "VILA BELA DA SANTISSIMA TRINDADE":
                case "VILA RICA":


                    return cidade + "/MT";

                case "PARA":
                case "ABAETETUBA":
                case "ABEL FIGUEIREDO":
                case "ACARA":
                case "AFUA":
                case "AGUA AZUL DO NORTE":
                case "ALENQUER":
                case "ALMEIRIM":
                case "ALTAMIRA":
                case "ANAJAS":
                case "ANANINDEUA":
                case "ANAPU":
                case "AUGUSTO CORREA":
                case "AURORA DO PARA":
                case "AVEIRO":
                case "BAGRE":
                case "BAIAO":
                case "BANNACH":
                case "BARCARENA":
                //case "BELEM":
                case "BELTERRA":
                case "BENEVIDES":
                case "BOM JESUS DO TOCANTINS":
                //case "BONITO":
                case "BRAGANCA":
                case "BRASIL NOVO":
                case "BREJO GRANDE DO ARAGUAIA":
                case "BREU BRANCO":
                case "BREVES":
                case "BUJARU":
                case "CACHOEIRA DO ARARI":
                case "CACHOEIRA DO PIRIA":
                case "CAMETA":
                case "CANAA DOS CARAJAS":
                case "CAPANEMA":
                case "CAPITAO POCO":
                case "CASTANHAL":
                case "CHAVES":
                case "COLARES":
                case "CONCEICAO DO ARAGUAIA":
                case "CONCORDIA DO PARA":
                case "CUMARU DO NORTE":
                case "CURIONOPOLIS":
                case "CURRALINHO":
                case "CURUA":
                case "CURUCA":
                case "DOM ELISEU":
                case "ELDORADO DOS CARAJAS":
                case "FARO":
                case "FLORESTA DO ARAGUAIA":
                case "GARRAFAO DO NORTE":
                case "GOIANESIA DO PARA":
                case "GURUPA":
                case "IGARAPE-ACU":
                case "IGARAPE-MIRI":
                case "INHANGAPI":
                case "IPIXUNA DO PARA":
                case "IRITUIA":
                case "ITAITUBA":
                case "ITUPIRANGA":
                case "JACAREACANGA":
                case "JACUNDA":
                case "JURUTI":
                case "LIMOEIRO DO AJURU":
                case "MAE DO RIO":
                case "MAGALHAES BARATA":
                case "MARABA":
                case "MARACANA":
                case "MARAPANIM":
                case "MARITUBA":
                case "MEDICILANDIA":
                case "MELGACO":
                case "MOCAJUBA":
                case "MOJU":
                case "MONTE ALEGRE":
                case "MUANA":
                case "NOVA ESPERANCA DO PIRIA":
                case "NOVA IPIXUNA":
                case "NOVA TIMBOTEUA":
                case "NOVO PROGRESSO":
                case "NOVO REPARTIMENTO":
                case "OBIDOS":
                case "OEIRAS DO PARA":
                case "ORIXIMINA":
                case "OUREM":
                case "OURILANDIA DO NORTE":
                case "PACAJA":
                case "PALESTINA DO PARA":
                case "PARAGOMINAS":
                case "PARAUAPEBAS":
                case "PAU D'ARCO":
                case "PEIXE-BOI":
                case "PICARRA":
                case "PLACAS":
                case "PONTA DE PEDRAS":
                case "PORTEL":
                case "PORTO DE MOZ":
                case "PRAINHA":
                case "PRIMAVERA":
                case "QUATIPURU":
                //case "REDENCAO":
                case "RIO MARIA":
                case "RONDON DO PARA":
                case "RUROPOLIS":
                case "SALINOPOLIS":
                case "SALVATERRA":
                case "SANTA BARBARA DO PARA":
                case "SANTA CRUZ DO ARARI":
                case "SANTA ISABEL DO PARA":
                case "SANTA LUZIA DO PARA":
                case "SANTA MARIA DAS BARREIRAS":
                case "SANTA MARIA DO PARA":
                case "SANTANA DO ARAGUAIA":
                case "SANTAREM":
                case "SANTAREM NOVO":
                case "SANTO ANTONIO DO TAUA":
                case "SAO CAETANO DE ODIVELA":
                case "SAO DOMINGOS DO ARAGUAIA":
                case "SAO DOMINGOS DO CAPIM":
                case "SAO FELIX DO XINGU":
                case "SAO FRANCISCO DO PARA":
                case "SAO GERALDO DO ARAGUAIA":
                case "SAO JOAO DA PONTA":
                case "SAO JOAO DE PIRABAS":
                case "SAO JOAO DO ARAGUAIA":
                case "SAO MIGUEL DO GUAMA":
                case "SAO SEBASTIAO DA BOA VISTA":
                case "SAPUCAIA":
                case "SENADOR JOSE PORFIRIO":
                case "SOURE":
                case "TAILANDIA":
                case "TERRA ALTA":
                case "TERRA SANTA":
                case "TOME-ACU":
                case "TRACUATEUA":
                case "TRAIRAO":
                case "TUCUMA":
                case "TUCURUI":
                case "ULIANOPOLIS":
                case "URUARA":
                case "VIGIA":
                case "VISEU":
                case "VITORIA DO XINGU":
                case "XINGUARA":

                    return cidade + "/PA";

                case "PARAIBA":
                //case "AGUA BRANCA":
                case "AGUIAR":
                case "ALAGOA GRANDE":
                case "ALAGOA NOVA":
                case "ALAGOINHA":
                case "ALCANTIL":
                case "ALGODAO DE JANDAIRA":
                case "ALHANDRA":
                case "AMPARO":
                case "APARECIDA":
                case "ARACAGI":
                case "ARARA":
                case "ARARUNA":
                case "AREIA":
                case "AREIA DE BARAUNAS":
                case "AREIAL":
                case "AROEIRAS":
                case "ASSUNCAO":
                case "BAIA DA TRAICAO":
                case "BANANEIRAS":
                case "BARAUNA":
                case "BARRA DE SANTA ROSA":
                case "BARRA DE SANTANA":
                //case "BARRA DE SAO MIGUEL":
                case "BAYEUX":
                //case "BELEM":
                case "BELEM DO BREJO DO CRUZ":
                case "BERNARDINO BATISTA":
                case "BOA VENTURA":
                case "BOA VISTA":
                case "BOM JESUS":
                //case "BOM SUCESSO":
                case "BONITO DE SANTA FE":
                case "BOQUEIRAO":
                case "BORBOREMA":
                case "BREJO DO CRUZ":
                case "BREJO DOS SANTOS":
                case "CAAPORA":
                case "CABACEIRAS":
                case "CABEDELO":
                case "CACHOEIRA DOS INDIOS":
                case "CACIMBA DE AREIA":
                case "CACIMBA DE DENTRO":
                case "CACIMBAS":
                case "CAICARA":
                case "CAJAZEIRAS":
                case "CAJAZEIRINHAS":
                case "CALDAS BRANDAO":
                case "CAMALAU":
                case "CAMPINA GRANDE":
                case "CAMPO DE SANTANA":
                case "CAPIM":
                case "CARAUBAS":
                case "CARRAPATEIRA":
                case "CASSERENGUE":
                case "CATINGUEIRA":
                case "CATOLE DO ROCHA":
                case "CATURITE":
                case "CONCEICAO":
                case "CONDADO":
                //case "CONDE":
                case "CONGO":
                case "COREMAS":
                case "COXIXOLA":
                case "CRUZ DO ESPIRITO SANTO":
                case "CUBATI":
                case "CUITE":
                case "CUITE DE MAMANGUAPE":
                case "CUITEGI":
                case "CURRAL DE CIMA":
                case "CURRAL VELHO":
                case "DAMIAO":
                case "DESTERRO":
                case "DIAMANTE":
                case "DONA INES":
                case "DUAS ESTRADAS":
                case "EMAS":
                case "ESPERANCA":
                case "FAGUNDES":
                case "FREI MARTINHO":
                case "GADO BRAVO":
                case "GUARABIRA":
                case "GURINHEM":
                case "GURJAO":
                case "IBIARA":
                case "IGARACY":
                case "IMACULADA":
                case "INGA":
                case "ITABAIANA":
                case "ITAPORANGA":
                case "ITAPOROROCA":
                case "ITATUBA":
                case "JACARAU":
                case "JERICO":
                case "JOAO PESSOA":
                case "JUAREZ TAVORA":
                case "JUAZEIRINHO":
                case "JUNCO DO SERIDO":
                case "JURIPIRANGA":
                case "JURU":
                case "LAGOA":
                case "LAGOA DE DENTRO":
                case "LAGOA SECA":
                case "LASTRO":
                case "LIVRAMENTO":
                case "LOGRADOURO":
                case "LUCENA":
                case "MAE D'AGUA":
                case "MALTA":
                case "MAMANGUAPE":
                case "MANAIRA":
                case "MARCACAO":
                case "MARI":
                case "MARIZOPOLIS":
                case "MASSARANDUBA":
                case "MATARACA":
                case "MATINHAS":
                //case "MATO GROSSO":
                case "MATUREIA":
                case "MOGEIRO":
                case "MONTADAS":
                case "MONTE HOREBE":
                case "MONTEIRO":
                //case "MULUNGU":
                case "NATUBA":
                case "NAZAREZINHO":
                case "NOVA FLORESTA":
                //case "NOVA OLINDA":
                case "NOVA PALMEIRA":
                case "OLHO D'AGUA":
                case "OLIVEDOS":
                case "OURO VELHO":
                case "PARARI":
                case "PASSAGEM":
                case "PATOS":
                case "PAULISTA":
                //case "PEDRA BRANCA":
                case "PEDRA LAVRADA":
                case "PEDRAS DE FOGO":
                case "PEDRO REGIS":
                case "PIANCO":
                case "PICUI":
                //case "PILAR":
                case "PILOES":
                case "PILOEZINHOS":
                case "PIRPIRITUBA":
                case "PITIMBU":
                case "POCINHOS":
                case "POCO DANTAS":
                case "POCO DE JOSE DE MOURA":
                case "POMBAL":
                //case "PRATA":
                case "PRINCESA ISABEL":
                case "PUXINANA":
                //case "QUEIMADAS":
                case "QUIXABA":
                case "REMIGIO":
                //case "RIACHAO":
                case "RIACHAO DO BACAMARTE":
                case "RIACHAO DO POCO":
                case "RIACHO DE SANTO ANTONIO":
                case "RIACHO DOS CAVALOS":
                case "RIO TINTO":
                case "SALGADINHO":
                case "SALGADO DE SAO FELIX":
                case "SANTA CECILIA":
                case "SANTA CRUZ":
                //case "SANTA HELENA":
                //case "SANTA INES":
                //case "SANTA LUZIA":
                //case "SANTA RITA":
                //case "SANTA TERESINHA":
                case "SANTANA DE MANGUEIRA":
                case "SANTANA DOS GARROTES":
                //case "SANTAREM":
                case "SANTO ANDRE":
                case "SAO BENTINHO":
                //case "SAO BENTO":
                case "SAO DOMINGOS DE POMBAL":
                case "SAO DOMINGOS DO CARIRI":
                //case "SAO FRANCISCO":
                case "SAO JOAO DO CARIRI":
                case "SAO JOAO DO RIO DO PEIXE":
                case "SAO JOAO DO TIGRE":
                case "SAO JOSE DA LAGOA TAPADA":
                case "SAO JOSE DE CAIANA":
                case "SAO JOSE DE ESPINHARAS":
                case "SAO JOSE DE PIRANHAS":
                case "SAO JOSE DE PRINCESA":
                case "SAO JOSE DO BONFIM":
                case "SAO JOSE DO BREJO DO CRUZ":
                case "SAO JOSE DO SABUGI":
                case "SAO JOSE DOS CORDEIROS":
                case "SAO JOSE DOS RAMOS":
                case "SAO MAMEDE":
                case "SAO MIGUEL DE TAIPU":
                case "SAO SEBASTIAO DE LAGOA DE ROCA":
                case "SAO SEBASTIAO DO UMBUZEIRO":
                case "SAPE":
                case "SERIDO":
                case "SERRA BRANCA":
                case "SERRA DA RAIZ":
                case "SERRA GRANDE":
                case "SERRA REDONDA":
                case "SERRARIA":
                case "SERTAOZINHO":
                case "SOBRADO":
                case "SOLANEA":
                case "SOLEDADE":
                case "SOSSEGO":
                case "SOUSA":
                case "SUME":
                //case "TAPEROA":
                case "TAVARES":
                case "TEIXEIRA":
                case "TENORIO":
                case "TRIUNFO":
                case "UIRAUNA":
                case "UMBUZEIRO":
                case "VARZEA":
                case "VIEIROPOLIS":
                case "VISTA SERRANA":
                case "ZABELE":

                    return cidade + "/PB";

                case "PERNAMBUCO":
                case "ABREU E LIMA":
                case "AFOGADOS DA INGAZEIRA":
                case "AFRANIO":
                case "AGRESTINA":
                case "AGUA PRETA":
                case "AGUAS BELAS":
                //case "ALAGOINHA":
                case "ALIANCA":
                case "ALTINHO":
                case "AMARAJI":
                case "ANGELIM":
                //case "ARACOIABA":
                case "ARARIPINA":
                case "ARCOVERDE":
                case "BARRA DE GUABIRABA":
                case "BARREIROS":
                case "BELEM DE MARIA":
                case "BELEM DE SAO FRANCISCO":
                case "BELO JARDIM":
                case "BETANIA":
                case "BEZERROS":
                case "BODOCO":
                case "BOM CONSELHO":
                //case "BOM JARDIM":
                //case "BONITO":
                case "BREJAO":
                case "BREJINHO":
                case "BREJO DA MADRE DE DEUS":
                case "BUENOS AIRES":
                case "BUIQUE":
                case "CABO DE SANTO AGOSTINHO":
                case "CABROBO":
                case "CACHOEIRINHA":
                case "CAETES":
                case "CALCADO":
                case "CALUMBI":
                case "CAMARAGIBE":
                case "CAMOCIM DE SAO FELIX":
                case "CAMUTANGA":
                case "CANHOTINHO":
                case "CAPOEIRAS":
                case "CARNAIBA":
                case "CARNAUBEIRA DA PENHA":
                case "CARPINA":
                case "CARUARU":
                case "CASINHAS":
                case "CATENDE":
                //case "CEDRO":
                case "CHA DE ALEGRIA":
                case "CHA GRANDE":
                //case "CONDADO":
                case "CORRENTES":
                case "CORTES":
                case "CUMARU":
                case "CUPIRA":
                case "CUSTODIA":
                case "DORMENTES":
                case "ESCADA":
                case "EXU":
                case "FEIRA NOVA":
                case "FERNANDO DE NORONHA":
                case "FERREIROS":
                case "FLORES":
                case "FLORESTA":
                case "FREI MIGUELINHO":
                case "GAMELEIRA":
                case "GARANHUNS":
                case "GLORIA DO GOITA":
                //case "GOIANA":
                case "GRANITO":
                case "GRAVATA":
                case "IATI":
                case "IBIMIRIM":
                case "IBIRAJUBA":
                case "IGARASSU":
                case "IGUARACI":
                case "INAJA":
                case "INGAZEIRA":
                case "IPOJUCA":
                case "IPUBI":
                case "ITACURUBA":
                case "ITAIBA":
                case "ITAMARACA":
                //case "ITAMBE":
                case "ITAPETIM":
                case "ITAPISSUMA":
                case "ITAQUITINGA":
                case "JABOATAO DOS GUARARAPES":
                case "JAQUEIRA":
                case "JATAUBA":
                //case "JATOBA":
                case "JOAO ALFREDO":
                case "JOAQUIM NABUCO":
                case "JUCATI":
                case "JUPI":
                case "JUREMA":
                case "LAGOA DO CARRO":
                case "LAGOA DO ITAENGA":
                case "LAGOA DO OURO":
                case "LAGOA DOS GATOS":
                //case "LAGOA GRANDE":
                case "LAJEDO":
                case "LIMOEIRO":
                case "MACAPARANA":
                case "MACHADOS":
                case "MANARI":
                case "MARAIAL":
                case "MIRANDIBA":
                case "MOREILANDIA":
                case "MORENO":
                case "NAZARE DA MATA":
                case "OLINDA":
                case "OROBO":
                case "OROCO":
                case "OURICURI":
                case "PALMARES":
                case "PALMEIRINA":
                case "PANELAS":
                case "PARANATAMA":
                case "PARNAMIRIM":
                case "PASSIRA":
                case "PAUDALHO":
                //case "PAULISTA":
                case "PEDRA":
                case "PESQUEIRA":
                case "PETROLANDIA":
                case "PETROLINA":
                case "POCAO":
                case "POMBOS":
                //case "PRIMAVERA":
                case "QUIPAPA":
                //case "QUIXABA":
                case "RECIFE":
                case "RIACHO DAS ALMAS":
                case "RIBEIRAO":
                case "RIO FORMOSO":
                case "SAIRE":
                //case "SALGADINHO":
                case "SALGUEIRO":
                case "SALOA":
                case "SANHARO":
                //case "SANTA CRUZ":
                case "SANTA CRUZ DA BAIXA VERDE":
                case "SANTA CRUZ DO CAPIBARIBE":
                case "SANTA FILOMENA":
                case "SANTA MARIA DA BOA VISTA":
                case "SANTA MARIA DO CAMBUCA":
                //case "SANTA TEREZINHA":
                case "SAO BENEDITO DO SUL":
                case "SAO BENTO DO UNA":
                case "SAO CAITANO":
                case "SAO JOAO":
                case "SAO JOAQUIM DO MONTE":
                case "SAO JOSE DA COROA GRANDE":
                case "SAO JOSE DO BELMONTE":
                case "SAO JOSE DO EGITO":
                case "SAO LOURENCO DA MATA":
                //case "SAO VICENTE FERRER":
                case "SERRA TALHADA":
                case "SERRITA":
                case "SERTANIA":
                case "SIRINHAEM":
                case "SOLIDAO":
                case "SURUBIM":
                case "TABIRA":
                case "TACAIMBO":
                case "TACARATU":
                case "TAMANDARE":
                case "TAQUARITINGA DO NORTE":
                case "TEREZINHA":
                //case "TERRA NOVA":
                case "TIMBAUBA":
                case "TORITAMA":
                case "TRACUNHAEM":
                //case "TRINDADE":
                //case "TRIUNFO":
                case "TUPANATINGA":
                case "TUPARETAMA":
                case "VENTUROSA":
                case "VERDEJANTE":
                case "VERTENTE DO LERIO":
                case "VERTENTES":
                case "VICENCIA":
                case "VITORIA DE SANTO ANTAO":
                case "XEXEU":

                    return cidade + "/PE";

                case "Piauí":
                case "ACAUA":
                case "AGRICOLANDIA":
                //case "AGUA BRANCA":
                case "ALAGOINHA DO PIAUI":
                case "ALEGRETE DO PIAUI":
                case "ALTO LONGA":
                case "ALTOS":
                case "ALVORADA DO GURGUEIA":
                case "AMARANTE":
                case "ANGICAL DO PIAUI":
                case "ANISIO DE ABREU":
                case "ANTONIO ALMEIDA":
                case "AROAZES":
                case "ARRAIAL":
                case "ASSUNCAO DO PIAUI":
                case "AVELINO LOPES":
                case "BAIXA GRANDE DO RIBEIRO":
                case "BARRA D'ALCANTARA":
                case "BARRAS":
                case "BARREIRAS DO PIAUI":
                case "BARRO DURO":
                //case "BATALHA":
                case "BELA VISTA DO PIAUI":
                case "BELEM DO PIAUI":
                case "BENEDITINOS":
                case "BERTOLINIA":
                case "BETANIA DO PIAUI":
                case "BOA HORA":
                case "BOCAINA":
                //case "BOM JESUS":
                case "BOM PRINCIPIO DO PIAUI":
                case "BONFIM DO PIAUI":
                case "BOQUEIRAO DO PIAUI":
                case "BRASILEIRA":
                case "BREJO DO PIAUI":
                case "BURITI DOS LOPES":
                case "BURITI DOS MONTES":
                case "CABECEIRAS DO PIAUI":
                case "CAJAZEIRAS DO PIAUI":
                case "CAJUEIRO DA PRAIA":
                case "CALDEIRAO GRANDE DO PIAUI":
                case "CAMPINAS DO PIAUI":
                case "CAMPO ALEGRE DO FIDALGO":
                case "CAMPO GRANDE DO PIAUI":
                case "CAMPO LARGO DO PIAUI":
                case "CAMPO MAIOR":
                case "CANAVIEIRA":
                case "CANTO DO BURITI":
                case "CAPITAO DE CAMPOS":
                case "CAPITAO GERVASIO OLIVEIRA":
                //case "CARACOL":
                case "CARAUBAS DO PIAUI":
                case "CARIDADE DO PIAUI":
                case "CASTELO DO PIAUI":
                case "CAXINGO":
                case "COCAL":
                case "COCAL DE TELHA":
                case "COCAL DOS ALVES":
                case "COIVARAS":
                case "COLONIA DO GURGUEIA":
                case "COLONIA DO PIAUI":
                case "CONCEICAO DO CANINDE":
                case "CORONEL JOSE DIAS":
                case "CORRENTE":
                case "CRISTALANDIA DO PIAUI":
                case "CRISTINO CASTRO":
                case "CURIMATA":
                case "CURRAIS":
                case "CURRAL NOVO DO PIAUI":
                case "CURRALINHOS":
                case "DEMERVAL LOBAO":
                case "DIRCEU ARCOVERDE":
                case "DOM EXPEDITO LOPES":
                case "DOM INOCENCIO":
                case "DOMINGOS MOURAO":
                case "ELESBAO VELOSO":
                case "ELISEU MARTINS":
                case "ESPERANTINA":
                case "FARTURA DO PIAUI":
                case "FLORES DO PIAUI":
                case "FLORESTA DO PIAUI":
                case "FLORIANO":
                case "FRANCINOPOLIS":
                case "FRANCISCO AYRES":
                case "FRANCISCO MACEDO":
                case "FRANCISCO SANTOS":
                case "FRONTEIRAS":
                case "GEMINIANO":
                case "GILBUES":
                case "GUADALUPE":
                case "GUARIBAS":
                case "HUGO NAPOLEAO":
                case "ILHA GRANDE":
                case "INHUMA":
                case "IPIRANGA DO PIAUI":
                case "ISAIAS COELHO":
                case "ITAINOPOLIS":
                case "ITAUEIRA":
                case "JACOBINA DO PIAUI":
                case "JAICOS":
                case "JARDIM DO MULATO":
                case "JATOBA DO PIAUI":
                case "JERUMENHA":
                case "JOAO COSTA":
                case "JOAQUIM PIRES":
                case "JOCA MARQUES":
                case "JOSE DE FREITAS":
                case "JUAZEIRO DO PIAUI":
                case "JULIO BORGES":
                //case "JUREMA":
                case "LAGOA ALEGRE":
                case "LAGOA DE SAO FRANCISCO":
                case "LAGOA DO BARRO DO PIAUI":
                case "LAGOA DO PIAUI":
                case "LAGOA DO SITIO":
                case "LAGOINHA DO PIAUI":
                case "LANDRI SALES":
                case "LUIS CORREIA":
                case "LUZILANDIA":
                case "MADEIRO":
                case "MANOEL EMIDIO":
                case "MARCOLANDIA":
                case "MARCOS PARENTE":
                case "MASSAPE DO PIAUI":
                case "MATIAS OLIMPIO":
                case "MIGUEL ALVES":
                case "MIGUEL LEAO":
                case "MILTON BRANDAO":
                case "MONSENHOR GIL":
                case "MONSENHOR HIPOLITO":
                case "MONTE ALEGRE DO PIAUI":
                case "MORRO CABECA NO TEMPO":
                case "MORRO DO CHAPEU DO PIAUI":
                case "MURICI DOS PORTELAS":
                case "NAZARE DO PIAUI":
                case "NOSSA SENHORA DE NAZARE":
                case "NOSSA SENHORA DOS REMEDIOS":
                case "NOVA SANTA RITA":
                case "NOVO ORIENTE DO PIAUI":
                //case "NOVO SANTO ANTONIO":
                case "OEIRAS":
                case "OLHO D'AGUA DO PIAUI":
                case "PADRE MARCOS":
                case "PAES LANDIM":
                case "PAJEU DO PIAUI":
                case "PALMEIRA DO PIAUI":
                case "PALMEIRAIS":
                case "PAQUETA":
                case "PARNAGUA":
                case "PARNAIBA":
                case "PASSAGEM FRANCA DO PIAUI":
                case "PATOS DO PIAUI":
                case "PAU D'ARCO DO PIAUI":
                case "PAULISTANA":
                case "PAVUSSU":
                case "PEDRO II":
                case "PEDRO LAURENTINO":
                case "PICOS":
                case "PIMENTEIRAS":
                case "PIO IX":
                case "PIRACURUCA":
                case "PIRIPIRI":
                case "PORTO":
                case "PORTO ALEGRE DO PIAUI":
                case "PRATA DO PIAUI":
                case "QUEIMADA NOVA":
                case "REDENCAO DO GURGUEIA":
                case "REGENERACAO":
                case "RIACHO FRIO":
                case "RIBEIRA DO PIAUI":
                case "RIBEIRO GONCALVES":
                case "RIO GRANDE DO PIAUI":
                case "SANTA CRUZ DO PIAUI":
                case "SANTA CRUZ DOS MILAGRES":
                //case "SANTA FILOMENA":
                case "SANTA LUZ":
                case "SANTA ROSA DO PIAUI":
                case "SANTANA DO PIAUI":
                case "SANTO ANTONIO DE LISBOA":
                case "SANTO ANTONIO DOS MILAGRES":
                case "SANTO INACIO DO PIAUI":
                case "SAO BRAZ DO PIAUI":
                case "SAO FELIX DO PIAUI":
                case "SAO FRANCISCO DE ASSIS DO PIAUI":
                case "SAO FRANCISCO DO PIAUI":
                case "SAO GONCALO DO GURGUEIA":
                case "SAO GONCALO DO PIAUI":
                case "SAO JOAO DA CANABRAVA":
                case "SAO JOAO DA FRONTEIRA":
                case "SAO JOAO DA SERRA":
                case "SAO JOAO DA VARJOTA":
                case "SAO JOAO DO ARRAIAL":
                case "SAO JOAO DO PIAUI":
                //case "SAO JOSE DO DIVINO":
                case "SAO JOSE DO PEIXE":
                case "SAO JOSE DO PIAUI":
                case "SAO JULIAO":
                case "SAO LOURENCO DO PIAUI":
                case "SAO LUIS DO PIAUI":
                case "SAO MIGUEL DA BAIXA GRANDE":
                case "SAO MIGUEL DO FIDALGO":
                case "SAO MIGUEL DO TAPUIO":
                case "SAO PEDRO DO PIAUI":
                case "SAO RAIMUNDO NONATO":
                case "SEBASTIAO BARROS":
                case "SEBASTIAO LEAL":
                case "SIGEFREDO PACHECO":
                case "SIMOES":
                case "SIMPLICIO MENDES":
                case "SOCORRO DO PIAUI":
                case "SUSSUAPARA":
                case "TAMBORIL DO PIAUI":
                case "TANQUE DO PIAUI":
                case "TERESINA":
                case "UNIAO":
                case "URUCUI":
                case "VALENCA DO PIAUI":
                case "VARZEA BRANCA":
                //case "VARZEA GRANDE":
                case "VERA MENDES":
                case "VILA NOVA DO PIAUI":
                case "WALL FERRAZ":

                    return cidade + "/PI";

                case "PARANA":
                case "ABATIA":
                case "ADRIANOPOLIS":
                case "AGUDOS DO SUL":
                case "ALMIRANTE TAMANDARE":
                case "ALTAMIRA DO PARANA":
                case "ALTO PARANA":
                case "ALTO PIQUIRI":
                case "ALTONIA":
                case "ALVORADA DO SUL":
                case "AMAPORA":
                case "AMPERE":
                case "ANAHY":
                case "ANDIRA":
                case "ANGULO":
                case "ANTONINA":
                case "ANTONIO OLINTO":
                case "APUCARANA":
                case "ARAPONGAS":
                case "ARAPOTI":
                //case "ARAPUA":
                //case "ARARUNA":
                case "ARAUCARIA":
                case "ARIRANHA DO IVAI":
                case "ASSAI":
                case "ASSIS CHATEAUBRIAND":
                case "ASTORGA":
                //case "ATALAIA":
                case "BALSA NOVA":
                //case "BANDEIRANTES":
                case "BARBOSA FERRAZ":
                case "BARRA DO JACARE":
                case "BARRACAO":
                case "BELA VISTA DA CAROBA":
                case "BELA VISTA DO PARAISO":
                case "BITURUNA":
                //case "BOA ESPERANCA":
                case "BOA ESPERANCA DO IGUACU":
                case "BOA VENTURA DE SAO ROQUE":
                case "BOA VISTA DA APARECIDA":
                case "BOCAIUVA DO SUL":
                case "BOM JESUS DO SUL":
                //case "BOM SUCESSO":
                case "BOM SUCESSO DO SUL":
                case "BORRAZOPOLIS":
                case "BRAGANEY":
                case "BRASILANDIA DO SUL":
                case "CAFEARA":
                case "CAFELANDIA":
                case "CAFEZAL DO SUL":
                case "CALIFORNIA":
                case "CAMBARA":
                case "CAMBE":
                case "CAMBIRA":
                case "CAMPINA DA LAGOA":
                case "CAMPINA DO SIMAO":
                case "CAMPINA GRANDE DO SUL":
                case "CAMPO BONITO":
                case "CAMPO DO TENENTE":
                case "CAMPO LARGO":
                case "CAMPO MAGRO":
                case "CAMPO MOURAO":
                case "CANDIDO DE ABREU":
                case "CANDOI":
                //case "CANTAGALO":
                //case "CAPANEMA":
                case "CAPITAO LEONIDAS MARQUES":
                case "CARAMBEI":
                case "CARLOPOLIS":
                //case "CASCAVEL":
                case "CASTRO":
                case "CATANDUVAS":
                case "CENTENARIO DO SUL":
                case "CERRO AZUL":
                case "CEU AZUL":
                case "CHOPINZINHO":
                case "CIANORTE":
                case "CIDADE GAUCHA":
                case "CLEVELANDIA":
                case "COLOMBO":
                case "COLORADO":
                case "CONGONHINHAS":
                case "CONSELHEIRO MAIRINCK":
                case "CONTENDA":
                case "CORBELIA":
                case "CORNELIO PROCOPIO":
                case "CORONEL DOMINGOS SOARES":
                case "CORONEL VIVIDA":
                case "CORUMBATAI DO SUL":
                case "CRUZ MACHADO":
                case "CRUZEIRO DO IGUACU":
                case "CRUZEIRO DO OESTE":
                //case "CRUZEIRO DO SUL":
                case "CRUZMALTINA":
                case "CURITIBA":
                case "CURIUVA":
                case "DIAMANTE D'OESTE":
                case "DIAMANTE DO NORTE":
                case "DIAMANTE DO SUL":
                case "DOIS VIZINHOS":
                //case "DOURADINA":
                case "DOUTOR CAMARGO":
                case "DOUTOR ULYSSES":
                case "ENEAS MARQUES":
                case "ENGENHEIRO BELTRAO":
                case "ENTRE RIOS DO OESTE":
                case "ESPERANCA NOVA":
                case "ESPIGAO ALTO DO IGUACU":
                case "FAROL":
                case "FAXINAL":
                case "FAZENDA RIO GRANDE":
                case "FENIX":
                case "FERNANDES PINHEIRO":
                case "FIGUEIRA":
                case "FLOR DA SERRA DO SUL":
                case "FLORAI":
                //case "FLORESTA":
                case "FLORESTOPOLIS":
                case "FLORIDA":
                case "FORMOSA DO OESTE":
                case "FOZ DO IGUACU":
                case "FOZ DO JORDAO":
                case "FRANCISCO ALVES":
                case "FRANCISCO BELTRAO":
                //case "GENERAL CARNEIRO":
                case "GODOY MOREIRA":
                case "GOIOERE":
                case "GOIOXIM":
                case "GRANDES RIOS":
                case "GUAIRA":
                case "GUAIRACA":
                case "GUAMIRANGA":
                case "GUAPIRAMA":
                case "GUAPOREMA":
                case "GUARACI":
                case "GUARANIACU":
                case "GUARAPUAVA":
                case "GUARAQUECABA":
                case "GUARATUBA":
                case "HONORIO SERPA":
                case "IBAITI":
                case "IBEMA":
                case "IBIPORA":
                case "ICARAIMA":
                case "IGUARACU":
                //case "IGUATU":
                case "IMBAU":
                case "IMBITUVA":
                case "INACIO MARTINS":
                //case "INAJA":
                //case "INDIANOPOLIS":
                case "IPIRANGA":
                //case "IPORA":
                case "IRACEMA DO OESTE":
                case "IRATI":
                case "IRETAMA":
                case "ITAGUAJE":
                case "ITAIPULANDIA":
                case "ITAMBARACA":
                //case "ITAMBE":
                case "ITAPEJARA D'OESTE":
                case "ITAPERUCU":
                case "ITAUNA DO SUL":
                case "IVAI":
                case "IVAIPORA":
                case "IVATE":
                case "IVATUBA":
                case "JABOTI":
                case "JACAREZINHO":
                case "JAGUAPITA":
                case "JAGUARIAIVA":
                case "JANDAIA DO SUL":
                case "JANIOPOLIS":
                case "JAPIRA":
                //case "JAPURA":
                case "JARDIM ALEGRE":
                case "JARDIM OLINDA":
                case "JATAIZINHO":
                case "JESUITAS":
                case "JOAQUIM TAVORA":
                case "JUNDIAI DO SUL":
                case "JURANDA":
                //case "JUSSARA":
                case "KALORE":
                case "LAPA":
                //case "LARANJAL":
                case "LARANJEIRAS DO SUL":
                case "LEOPOLIS":
                case "LIDIANOPOLIS":
                case "LINDOESTE":
                case "LOANDA":
                case "LOBATO":
                case "LONDRINA":
                case "LUIZIANA":
                case "LUNARDELLI":
                case "LUPIONOPOLIS":
                case "MALLET":
                case "MAMBORE":
                case "MANDAGUACU":
                case "MANDAGUARI":
                case "MANDIRITUBA":
                case "MANFRINOPOLIS":
                case "MANGUEIRINHA":
                case "MANOEL RIBAS":
                case "MARECHAL CANDIDO RONDON":
                case "MARIA HELENA":
                case "MARIALVA":
                case "MARILANDIA DO SUL":
                case "MARILENA":
                case "MARILUZ":
                case "MARINGA":
                case "MARIOPOLIS":
                case "MARIPA":
                case "MARMELEIRO":
                case "MARQUINHO":
                case "MARUMBI":
                case "MATELANDIA":
                case "MATINHOS":
                case "MATO RICO":
                case "MAUA DA SERRA":
                case "MEDIANEIRA":
                case "MERCEDES":
                //case "MIRADOR":
                case "MIRASELVA":
                case "MISSAL":
                case "MOREIRA SALES":
                case "MORRETES":
                case "MUNHOZ DE MELO":
                case "NOSSA SENHORA DAS GRACAS":
                case "NOVA ALIANCA DO IVAI":
                case "NOVA AMERICA DA COLINA":
                //case "NOVA AURORA":
                case "NOVA CANTU":
                case "NOVA ESPERANCA":
                case "NOVA ESPERANCA DO SUDOESTE":
                //case "NOVA FATIMA":
                case "NOVA LARANJEIRAS":
                case "NOVA LONDRINA":
                //case "NOVA OLIMPIA":
                case "NOVA PRATA DO IGUACU":
                case "NOVA SANTA BARBARA":
                case "NOVA SANTA ROSA":
                case "NOVA TEBAS":
                case "NOVO ITACOLOMI":
                case "ORTIGUEIRA":
                case "OURIZONA":
                case "OURO VERDE DO OESTE":
                case "PAICANDU":
                case "PALMAS":
                case "PALMEIRA":
                case "PALMITAL":
                case "PALOTINA":
                case "PARAISO DO NORTE":
                case "PARANACITY":
                case "PARANAGUA":
                case "PARANAPOEMA":
                case "PARANAVAI":
                case "PATO BRAGADO":
                case "PATO BRANCO":
                case "PAULA FREITAS":
                case "PAULO FRONTIN":
                case "PEABIRU":
                case "PEROBAL":
                case "PEROLA":
                case "PEROLA D'OESTE":
                case "PIEN":
                case "PINHAIS":
                case "PINHAL DE SAO BENTO":
                case "PINHALAO":
                case "PINHAO":
                case "PIRAI DO SUL":
                case "PIRAQUARA":
                case "PITANGA":
                case "PITANGUEIRAS":
                case "PLANALTINA DO PARANA":
                //case "PLANALTO":
                case "PONTA GROSSA":
                case "PONTAL DO PARANA":
                case "PORECATU":
                case "PORTO AMAZONAS":
                case "PORTO BARREIRO":
                case "PORTO RICO":
                case "PORTO VITORIA":
                case "PRADO FERREIRA":
                case "PRANCHITA":
                case "PRESIDENTE CASTELO BRANCO":
                case "PRIMEIRO DE MAIO":
                case "PRUDENTOPOLIS":
                case "QUARTO CENTENARIO":
                case "QUATIGUA":
                case "QUATRO BARRAS":
                case "QUATRO PONTES":
                case "QUEDAS DO IGUACU":
                case "QUERENCIA DO NORTE":
                case "QUINTA DO SOL":
                case "QUITANDINHA":
                case "RAMILANDIA":
                case "RANCHO ALEGRE":
                case "RANCHO ALEGRE D'OESTE":
                case "REALEZA":
                case "REBOUCAS":
                case "RENASCENCA":
                case "RESERVA":
                case "RESERVA DO IGUACU":
                case "RIBEIRAO CLARO":
                case "RIBEIRAO DO PINHAL":
                case "RIO AZUL":
                case "RIO BOM":
                case "RIO BONITO DO IGUACU":
                case "RIO BRANCO DO IVAI":
                case "RIO BRANCO DO SUL":
                //case "RIO NEGRO":
                case "ROLANDIA":
                case "RONCADOR":
                case "RONDON":
                case "ROSARIO DO IVAI":
                case "SABAUDIA":
                case "SALGADO FILHO":
                case "SALTO DO ITARARE":
                case "SALTO DO LONTRA":
                case "SANTA AMELIA":
                case "SANTA CECILIA DO PAVAO":
                case "SANTA CRUZ MONTE CASTELO":
                case "SANTA FE":
                //case "SANTA HELENA":
                //case "SANTA INES":
                case "SANTA ISABEL DO IVAI":
                case "SANTA IZABEL DO OESTE":
                case "SANTA LUCIA":
                case "SANTA MARIA DO OESTE":
                case "SANTA MARIANA":
                case "SANTA MONICA":
                case "SANTA TEREZA DO OESTE":
                case "SANTA TEREZINHA DE ITAIPU":
                case "SANTANA DO ITARARE":
                case "SANTO ANTONIO DA PLATINA":
                case "SANTO ANTONIO DO CAIUA":
                case "SANTO ANTONIO DO PARAISO":
                case "SANTO ANTONIO DO SUDOESTE":
                case "SANTO INACIO":
                case "SAO CARLOS DO IVAI":
                case "SAO JERONIMO DA SERRA":
                //case "SAO JOAO":
                case "SAO JOAO DO CAIUA":
                case "SAO JOAO DO IVAI":
                case "SAO JOAO DO TRIUNFO":
                case "SAO JORGE D'OESTE":
                case "SAO JORGE DO IVAI":
                case "SAO JORGE DO PATROCINIO":
                case "SAO JOSE DA BOA VISTA":
                case "SAO JOSE DAS PALMEIRAS":
                case "SAO JOSE DOS PINHAIS":
                case "SAO MANOEL DO PARANA":
                case "SAO MATEUS DO SUL":
                case "SAO MIGUEL DO IGUACU":
                case "SAO PEDRO DO IGUACU":
                case "SAO PEDRO DO IVAI":
                case "SAO PEDRO DO PARANA":
                case "SAO SEBASTIAO DA AMOREIRA":
                case "SAO TOME":
                case "SAPOPEMA":
                case "SARANDI":
                case "SAUDADE DO IGUACU":
                case "SENGES":
                case "SERRANOPOLIS DO IGUACU":
                case "SERTANEJA":
                case "SERTANOPOLIS":
                case "SIQUEIRA CAMPOS":
                case "SULINA":
                case "TAMARANA":
                case "TAMBOARA":
                case "TAPEJARA":
                //case "TAPIRA":
                case "TEIXEIRA SOARES":
                case "TELEMACO BORBA":
                case "TERRA BOA":
                case "TERRA RICA":
                case "TERRA ROXA":
                case "TIBAGI":
                case "TIJUCAS DO SUL":
                //case "TOLEDO":
                case "TOMAZINA":
                case "TRES BARRAS DO PARANA":
                case "TUNAS DO PARANA":
                case "TUNEIRAS DO OESTE":
                case "TUPASSI":
                case "TURVO":
                case "UBIRATA":
                case "UMUARAMA":
                case "UNIAO DA VITORIA":
                case "UNIFLOR":
                case "URAI":
                case "VENTANIA":
                case "VERA CRUZ DO OESTE":
                case "VERE":
                case "VILA ALTA":
                case "VIRMOND":
                case "VITORINO":
                //case "WENCESLAU BRAZ":
                case "XAMBRE":

                    return cidade + "/PR";

                case "Rio de Janeiro":
                case "ANGRA DOS REIS":
                case "APERIBE":
                case "ARARUAMA":
                case "AREAL":
                case "ARMACAO DE BUZIOS":
                case "ARRAIAL DO CABO":
                case "BARRA DO PIRAI":
                case "BARRA MANSA":
                case "BELFORD ROXO":
                //case "BOM JARDIM":
                case "BOM JESUS DO ITABAPOANA":
                case "CABO FRIO":
                case "CACHOEIRAS DE MACACU":
                case "CAMBUCI":
                case "CAMPOS DOS GOYTACAZES":
                //case "CANTAGALO":
                case "CARAPEBUS":
                case "CARDOSO MOREIRA":
                case "CARMO":
                case "CASIMIRO DE ABREU":
                case "COMENDADOR LEVY GASPARIAN":
                case "CONCEICAO DE MACABU":
                case "CORDEIRO":
                case "DUAS BARRAS":
                case "DUQUE DE CAXIAS":
                case "ENGENHEIRO PAULO DE FRONTIN":
                case "GUAPIMIRIM":
                case "IGUABA GRANDE":
                case "ITABORAI":
                case "ITAGUAI":
                case "ITALVA":
                case "ITAOCARA":
                case "ITAPERUNA":
                case "ITATIAIA":
                case "JAPERI":
                case "LAJE DO MURIAE":
                case "MACAE":
                case "MACUCO":
                case "MAGE":
                case "MANGARATIBA":
                case "MARICA":
                case "MENDES":
                //case "MESQUITA":
                case "MIGUEL PEREIRA":
                case "MIRACEMA":
                case "NATIVIDADE":
                case "NILOPOLIS":
                case "NITEROI":
                case "NOVA FRIBURGO":
                case "NOVA IGUACU":
                case "PARACAMBI":
                case "PARAIBA DO SUL":
                case "PARATI":
                case "PATY DO ALFERES":
                case "PETROPOLIS":
                case "PINHEIRAL":
                case "PIRAI":
                case "PORCIUNCULA":
                case "PORTO REAL":
                case "QUATIS":
                case "QUEIMADOS":
                case "QUISSAMA":
                case "RESENDE":
                case "RIO BONITO":
                case "RIO CLARO":
                case "RIO DAS FLORES":
                case "RIO DAS OSTRAS":
                case "RIO DE JANEIRO":
                case "SANTA MARIA MADALENA":
                case "SANTO ANTONIO DE PADUA":
                case "SAO FIDELIS":
                case "SAO FRANCISCO DE ITABAPOANA":
                case "SAO GONCALO":
                case "SAO JOAO DA BARRA":
                case "SAO JOAO DE MERITI":
                case "SAO JOSE DE UBA":
                case "SAO JOSE DO VALE DO RIO PRETO":
                case "SAO PEDRO DA ALDEIA":
                case "SAO SEBASTIAO DO ALTO":
                //case "SAPUCAIA":
                case "SAQUAREMA":
                case "SEROPEDICA":
                case "SILVA JARDIM":
                case "SUMIDOURO":
                case "TANGUA":
                case "TERESOPOLIS":
                case "TRAJANO DE MORAIS":
                case "TRES RIOS":
                //case "VALENCA":
                case "VARRE-SAI":
                case "VASSOURAS":
                case "VOLTA REDONDA":

                    return cidade + "/RJ";

                case "ACARI":
                case "ACU":
                case "AFONSO BEZERRA":
                case "AGUA NOVA":
                case "ALEXANDRIA":
                case "ALMINO AFONSO":
                case "ALTO DO RODRIGUES":
                case "ANGICOS":
                case "ANTONIO MARTINS":
                case "APODI":
                case "AREIA BRANCA":
                case "ARES":
                case "AUGUSTO SEVERO":
                case "BAIA FORMOSA":
                //case "BARAUNA":
                case "BARCELONA":
                case "BENTO FERNANDES":
                case "BODO":
                //case "BOM JESUS":
                //case "BREJINHO":
                case "CAICARA DO NORTE":
                case "CAICARA DO RIO DO VENTO":
                case "CAICO":
                case "CAMPO REDONDO":
                case "CANGUARETAMA":
                //case "CARAUBAS":
                case "CARNAUBA DOS DANTAS":
                case "CARNAUBAIS":
                case "CEARA-MIRIM":
                case "CERRO CORA":
                case "CORONEL EZEQUIEL":
                case "CORONEL JOAO PESSOA":
                case "CRUZETA":
                case "CURRAIS NOVOS":
                case "DOUTOR SEVERIANO":
                case "ENCANTO":
                case "EQUADOR":
                case "ESPIRITO SANTO":
                case "EXTREMOZ":
                case "FELIPE GUERRA":
                case "FERNANDO PEDROZA":
                case "FLORANIA":
                case "FRANCISCO DANTAS":
                case "FRUTUOSO GOMES":
                case "GALINHOS":
                case "GOIANINHA":
                case "GOVERNADOR DIX-SEPT ROSADO":
                case "GROSSOS":
                case "GUAMARE":
                case "IELMO MARINHO":
                case "IPANGUACU":
                case "IPUEIRA":
                //case "ITAJA":
                case "ITAU":
                case "JACANA":
                //case "JANDAIRA":
                case "JANDUIS":
                case "JANUARIO CICCO":
                case "JAPI":
                case "JARDIM DE ANGICOS":
                case "JARDIM DE PIRANHAS":
                case "JARDIM DO SERIDO":
                case "JOAO CAMARA":
                case "JOAO DIAS":
                case "JOSE DA PENHA":
                case "JUCURUTU":
                //case "JUNDIA":
                case "LAGOA D'ANTA":
                case "LAGOA DE PEDRAS":
                case "LAGOA DE VELHOS":
                case "LAGOA NOVA":
                case "LAGOA SALGADA":
                case "LAJES":
                case "LAJES PINTADAS":
                case "LUCRECIA":
                case "LUIS GOMES":
                case "MACAIBA":
                case "MACAU":
                case "MAJOR SALES":
                case "MARCELINO VIEIRA":
                case "MARTINS":
                case "MAXARANGUAPE":
                case "MESSIAS TARGINO":
                case "MONTANHAS":
                //case "MONTE ALEGRE":
                case "MONTE DAS GAMELEIRAS":
                case "MOSSORO":
                case "NATAL":
                case "NISIA FLORESTA":
                case "NOVA CRUZ":
                case "OLHO-D'AGUA DO BORGES":
                //case "OURO BRANCO":
                //case "PARANA":
                case "PARAU":
                case "PARAZINHO":
                case "PARELHAS":
                //case "PARNAMIRIM":
                case "PASSA E FICA":
                //case "PASSAGEM":
                case "PATU":
                case "PAU DOS FERROS":
                case "PEDRA GRANDE":
                //case "PEDRA PRETA":
                case "PEDRO AVELINO":
                case "PEDRO VELHO":
                case "PENDENCIAS":
                //case "PILOES":
                case "POCO BRANCO":
                case "PORTALEGRE":
                case "PORTO DO MANGUE":
                //case "PRESIDENTE JUSCELINO":
                case "PUREZA":
                case "RAFAEL FERNANDES":
                case "RAFAEL GODEIRO":
                case "RIACHO DA CRUZ":
                //case "RIACHO DE SANTANA":
                case "RIACHUELO":
                case "RIO DO FOGO":
                case "RODOLFO FERNANDES":
                //case "RUY BARBOSA":
                //case "SANTA CRUZ":
                //case "SANTA MARIA":
                case "SANTANA DO MATOS":
                case "SANTANA DO SERIDO":
                case "SANTO ANTONIO":
                case "SAO BENTO DO NORTE":
                case "SAO BENTO DO TRAIRI":
                case "SAO FERNANDO":
                case "SAO FRANCISCO DO OESTE":
                //case "SAO GONCALO DO AMARANTE":
                case "SAO JOAO DO SABUGI":
                case "SAO JOSE DE MIPIBU":
                case "SAO JOSE DO CAMPESTRE":
                case "SAO JOSE DO SERIDO":
                case "SAO MIGUEL":
                case "SAO MIGUEL DE TOUROS":
                case "SAO PAULO DO POTENGI":
                case "SAO PEDRO":
                case "SAO RAFAEL":
                //case "SAO TOME":
                case "SAO VICENTE":
                case "SENADOR ELOI DE SOUZA":
                case "SENADOR GEORGINO AVELINO":
                case "SERRA DE SAO BENTO":
                case "SERRA DO MEL":
                case "SERRA NEGRA DO NORTE":
                //case "SERRINHA":
                case "SERRINHA DOS PINTOS":
                case "SEVERIANO MELO":
                //case "SITIO NOVO":
                case "TABOLEIRO GRANDE":
                case "TAIPU":
                case "TANGARA":
                case "TENENTE ANANIAS":
                case "TENENTE LAURENTINO CRUZ":
                case "TIBAU":
                case "TIBAU DO SUL":
                case "TIMBAUBA DOS BATISTAS":
                case "TOUROS":
                case "TRIUNFO POTIGUAR":
                case "UMARIZAL":
                case "UPANEMA":
                //case "VARZEA":
                case "VENHA-VER":
                //case "VERA CRUZ":
                //case "VICOSA":
                case "VILA FLOR":

                    return cidade + "/RN";

                case "RONDONIA":
                case "ALTA FLORESTA D'OESTE":
                case "ALTO ALEGRE DO PARECIS":
                case "ALTO PARAISO":
                case "ALVORADA D'OESTE":
                case "ARIQUEMES":
                //case "BURITIS":
                case "CABIXI":
                case "CACAULANDIA":
                case "CACOAL":
                case "CAMPO NOVO DE RONDONIA":
                case "CANDEIAS DO JAMARI":
                case "CASTANHEIRAS":
                case "CEREJEIRAS":
                case "CHUPINGUAIA":
                case "COLORADO DO OESTE":
                case "CORUMBIARA":
                case "COSTA MARQUES":
                case "CUJUBIM":
                case "ESPIGAO D'OESTE":
                case "GOVERNADOR JORGE TEIXEIRA":
                case "GUAJARA-MIRIM":
                case "ITAPUA DO OESTE":
                case "JARU":
                case "JI-PARANA":
                case "MACHADINHO D'OESTE":
                case "MINISTRO ANDREAZZA":
                case "MIRANTE DA SERRA":
                case "MONTE NEGRO":
                case "NOVA BRASILANDIA D'OESTE":
                case "NOVA MAMORE":
                //case "NOVA UNIAO":
                case "NOVO HORIZONTE DO OESTE":
                case "OURO PRETO DO OESTE":
                case "PARECIS":
                case "PIMENTA BUENO":
                case "PIMENTEIRAS DO OESTE":
                case "PORTO VELHO":
                //case "PRESIDENTE MEDICI":
                case "PRIMAVERA DE RONDONIA":
                case "RIO CRESPO":
                case "ROLIM DE MOURA":
                case "SANTA LUZIA D'OESTE":
                case "SAO FELIPE D'OESTE":
                case "SAO FRANCISCO DO GUAPORE":
                case "SAO MIGUEL DO GUAPORE":
                case "SERINGUEIRAS":
                case "TEIXEIROPOLIS":
                case "THEOBROMA":
                case "URUPA":
                case "VALE DO ANARI":
                case "VALE DO PARAISO":
                case "VILHENA":

                    return cidade + "/RO";

                case "RORAIMA":
                case "ALTO ALEGRE":
                case "AMAJARI":
                //case "BOA VISTA":
                //case "BONFIM":
                case "CANTA":
                case "CARACARAI":
                case "CAROEBE":
                //case "IRACEMA":
                case "MUCAJAI":
                case "NORMANDIA":
                case "PACARAIMA":
                case "RORAINOPOLIS":
                case "SAO JOAO DA BALIZA":
                case "SAO LUIZ":
                case "UIRAMUTA":

                    return cidade + "/RR";

                case "RIO GRANDE DO SUL":
                case "ACEGUA":
                case "AGUA SANTA":
                case "AGUDO":
                case "AJURICABA":
                case "ALECRIM":
                case "ALEGRETE":
                case "ALEGRIA":
                case "ALMIRANTE TAMANDARE DO SUL":
                case "ALPESTRE":
                //case "ALTO ALEGRE":
                case "ALTO FELIZ":
                case "ALVORADA":
                case "AMARAL FERRADOR":
                case "AMETISTA DO SUL":
                case "ANDRE DA ROCHA":
                case "ANTA GORDA":
                case "ANTONIO PRADO":
                case "ARAMBARE":
                case "ARARICA":
                case "ARATIBA":
                case "ARROIO DO MEIO":
                case "ARROIO DO PADRE":
                case "ARROIO DO SAL":
                case "ARROIO DO TIGRE":
                case "ARROIO DOS RATOS":
                case "ARROIO GRANDE":
                case "ARVOREZINHA":
                case "AUGUSTO PESTANA":
                case "AUREA":
                case "BAGE":
                case "BALNEARIO PINHAL":
                case "BARAO":
                case "BARAO DE COTEGIPE":
                case "BARAO DO TRIUNFO":
                case "BARRA DO GUARITA":
                case "BARRA DO QUARAI":
                case "BARRA DO RIBEIRO":
                case "BARRA DO RIO AZUL":
                case "BARRA FUNDA":
                //case "BARRACAO":
                case "BARROS CASSAL":
                case "BENJAMIN CONSTAN DO SUL":
                case "BENTO GONCALVES":
                case "BOA VISTA DAS MISSOES":
                case "BOA VISTA DO BURICA":
                case "BOA VISTA DO CADEADO":
                case "BOA VISTA DO INCRA":
                case "BOA VISTA DO SUL":
                //case "BOM JESUS":
                case "BOM PRINCIPIO":
                case "BOM PROGRESSO":
                case "BOM RETIRO DO SUL":
                case "BOQUEIRAO DO LEAO":
                case "BOSSOROCA":
                case "BOZANO":
                case "BRAGA":
                case "BROCHIER":
                case "BUTIA":
                case "CACAPAVA DO SUL":
                case "CACEQUI":
                case "CACHOEIRA DO SUL":
                //case "CACHOEIRINHA":
                case "CACIQUE DOBLE":
                case "CAIBATE":
                //case "CAICARA":
                case "CAMAQUA":
                case "CAMARGO":
                case "CAMBARA DO SUL":
                case "CAMPESTRE DA SERRA":
                case "CAMPINA DAS MISSOES":
                case "CAMPINAS DO SUL":
                case "CAMPO BOM":
                case "CAMPO NOVO":
                case "CAMPOS BORGES":
                case "CANDELARIA":
                case "CANDIDO GODOI":
                case "CANDIOTA":
                case "CANELA":
                case "CANGUCU":
                case "CANOAS":
                case "CANUDOS DO VALE":
                case "CAPAO BONITO DO SUL":
                case "CAPAO DA CANOA":
                case "CAPAO DO CIPO":
                case "CAPAO DO LEAO":
                case "CAPELA DE SANTANA":
                case "CAPITAO":
                case "CAPIVARI DO SUL":
                case "CARAA":
                case "CARAZINHO":
                case "CARLOS BARBOSA":
                case "CARLOS GOMES":
                case "CASCA":
                case "CASEIROS":
                case "CATUIPE":
                case "CAXIAS DO SUL":
                case "CENTENARIO":
                case "CERRITO":
                case "CERRO BRANCO":
                case "CERRO GRANDE":
                case "CERRO GRANDE DO SUL":
                case "CERRO LARGO":
                case "CHAPADA":
                case "CHARQUEADAS":
                case "CHARRUA":
                case "CHIAPETA":
                case "CHUI":
                case "CHUVISCA":
                case "CIDREIRA":
                case "CIRIACO":
                //case "COLINAS":
                //case "COLORADO":
                case "CONDOR":
                case "CONSTANTINA":
                case "COQUEIRO BAIXO":
                case "COQUEIROS DO SUL":
                case "CORONEL BARROS":
                case "CORONEL BICACO":
                case "CORONEL PILAR":
                case "COTIPORA":
                case "COXILHA":
                case "CRISSIUMAL":
                case "CRISTAL":
                case "CRISTAL DO SUL":
                case "CRUZ ALTA":
                case "CRUZALTENSE":
                //case "CRUZEIRO DO SUL":
                case "DAVID CANABARRO":
                case "DERRUBADAS":
                case "DEZESSEIS DE NOVEMBRO":
                case "DILERMANDO DE AGUIAR":
                case "DOIS IRMAOS":
                case "DOIS IRMAOS DAS MISSOES":
                case "DOIS LAJEADOS":
                case "DOM FELICIANO":
                case "DOM PEDRITO":
                case "DOM PEDRO DE ALCANTARA":
                case "DONA FRANCISCA":
                case "DOUTOR MAURICIO CARDOSO":
                case "DOUTOR RICARDO":
                case "ELDORADO DO SUL":
                case "ENCANTADO":
                case "ENCRUZILHADA DO SUL":
                case "ENGENHO VELHO":
                case "ENTRE RIOS DO SUL":
                case "ENTRE-IJUIS":
                case "EREBANGO":
                case "ERECHIM":
                case "ERNESTINA":
                case "ERVAL GRANDE":
                case "ERVAL SECO":
                case "ESMERALDA":
                case "ESPERANCA DO SUL":
                case "ESPUMOSO":
                case "ESTACAO":
                case "ESTANCIA VELHA":
                case "ESTEIO":
                case "ESTRELA":
                case "ESTRELA VELHA":
                case "EUGENIO DE CASTRO":
                case "FAGUNDES VARELA":
                case "FARROUPILHA":
                case "FAXINAL DO SOTURNO":
                case "FAXINALZINHO":
                case "FAZENDA VILANOVA":
                case "FELIZ":
                case "FLORES DA CUNHA":
                case "FLORIANO PEIXOTO":
                case "FONTOURA XAVIER":
                case "FORMIGUEIRO":
                case "FORQUETINHA":
                case "FORTALEZA DOS VALOS":
                case "FREDERICO WESTPHALEN":
                case "GARIBALDI":
                case "GARRUCHOS":
                case "GAURAMA":
                case "GENERAL CAMARA":
                case "GENTIL":
                case "GETULIO VARGAS":
                case "GIRUA":
                case "GLORINHA":
                case "GRAMADO":
                case "GRAMADO DOS LOUREIROS":
                case "GRAMADO XAVIER":
                case "GRAVATAI":
                case "GUABIJU":
                case "GUAIBA":
                case "GUAPORE":
                case "GUARANI DAS MISSOES":
                case "HARMONIA":
                case "HERVAL":
                case "HERVEIRAS":
                case "HORIZONTINA":
                case "HULHA NEGRA":
                //case "HUMAITA":
                case "IBARAMA":
                case "IBIACA":
                case "IBIRAIARAS":
                case "IBIRAPUITA":
                case "IBIRUBA":
                case "IGREJINHA":
                case "IJUI":
                case "ILOPOLIS":
                case "IMBE":
                case "IMIGRANTE":
                //case "INDEPENDENCIA":
                case "INHACORA":
                case "IPE":
                case "IPIRANGA DO SUL":
                case "IRAI":
                case "ITAARA":
                case "ITACURUBI":
                case "ITAPUCA":
                case "ITAQUI":
                case "ITATI":
                case "ITATIBA DO SUL":
                case "IVORA":
                case "IVOTI":
                case "JABOTICABA":
                case "JACUIZINHO":
                //case "JACUTINGA":
                case "JAGUARAO":
                case "JAGUARI":
                case "JAQUIRANA":
                case "JARI":
                case "JOIA":
                case "JULIO DE CASTILHOS":
                case "LAGOA BONITA DO SUL":
                case "LAGOA DOS TRES CANTOS":
                case "LAGOA VERMELHA":
                case "LAGOAO":
                case "LAJEADO":
                case "LAJEADO DO BUGRE":
                case "LAVRAS DO SUL":
                case "LIBERATO SALZANO":
                case "LINDOLFO COLLOR":
                case "LINHA NOVA":
                case "MACAMBARA":
                case "MACHADINHO":
                case "MAMPITUBA":
                case "MANOEL VIANA":
                case "MAQUINE":
                case "MARATA":
                //case "MARAU":
                case "MARCELINO RAMOS":
                case "MARIANA PIMENTEL":
                case "MARIANO MORO":
                case "MARQUES DE SOUZA":
                case "MATA":
                case "MATO CASTELHANO":
                case "MATO LEITAO":
                case "MATO QUEIMADO":
                case "MAXIMILIANO DE ALMEIDA":
                case "MINAS DO LEAO":
                case "MIRAGUAI":
                case "MONTAURI":
                case "MONTE ALEGRE DOS CAMPOS":
                case "MONTE BELO DO SUL":
                case "MONTENEGRO":
                case "MORMACO":
                case "MORRINHOS DO SUL":
                case "MORRO REDONDO":
                case "MORRO REUTER":
                case "MOSTARDAS":
                case "MUCUM":
                case "MUITOS CAPOES":
                case "MULITERNO":
                case "NAO-ME-TOQUE":
                case "NICOLAU VERGUEIRO":
                case "NONOAI":
                case "NOVA ALVORADA":
                case "NOVA ARACA":
                case "NOVA BASSANO":
                case "NOVA BOA VISTA":
                case "NOVA BRESCIA":
                case "NOVA CANDELARIA":
                case "NOVA ESPERANCA DO SUL":
                case "NOVA HARTZ":
                case "NOVA PADUA":
                case "NOVA PALMA":
                case "NOVA PETROPOLIS":
                case "NOVA PRATA":
                case "NOVA RAMADA":
                case "NOVA ROMA DO SUL":
                //case "NOVA SANTA RITA":
                case "NOVO BARREIRO":
                case "NOVO CABRAIS":
                case "NOVO HAMBURGO":
                case "NOVO MACHADO":
                case "NOVO TIRADENTES":
                case "NOVO XINGU":
                case "OSORIO":
                case "PAIM FILHO":
                case "PALMARES DO SUL":
                case "PALMEIRA DAS MISSOES":
                case "PALMITINHO":
                case "PANAMBI":
                case "PANTANO GRANDE":
                case "PARAI":
                case "PARAISO DO SUL":
                case "PARECI NOVO":
                case "PAROBE":
                case "PASSA SETE":
                case "PASSO DO SOBRADO":
                case "PASSO FUNDO":
                case "PAULO BENTO":
                case "PAVERAMA":
                case "PEDRAS ALTAS":
                case "PEDRO OSORIO":
                case "PEJUCARA":
                case "PELOTAS":
                case "PICADA CAFE":
                case "PINHAL":
                case "PINHAL DA SERRA":
                case "PINHAL GRANDE":
                case "PINHEIRINHO DO VALE":
                case "PINHEIRO MACHADO":
                case "PIRAPO":
                case "PIRATINI":
                //case "PLANALTO":
                case "POCO DAS ANTAS":
                case "PONTAO":
                case "PONTE PRETA":
                case "PORTAO":
                case "PORTO ALEGRE":
                case "PORTO LUCENA":
                case "PORTO MAUA":
                case "PORTO VERA CRUZ":
                case "PORTO XAVIER":
                case "POUSO NOVO":
                case "PRESIDENTE LUCENA":
                case "PROGRESSO":
                case "PROTASIO ALVES":
                case "PUTINGA":
                case "QUARAI":
                case "QUATRO IRMAOS":
                case "QUEVEDOS":
                case "QUINZE DE NOVEMBRO":
                case "REDENTORA":
                case "RELVADO":
                case "RESTINGA SECA":
                case "RIO DOS INDIOS":
                case "RIO GRANDE":
                case "RIO PARDO":
                case "RIOZINHO":
                case "ROCA SALES":
                case "RODEIO BONITO":
                case "ROLADOR":
                case "ROLANTE":
                case "RONDA ALTA":
                case "RONDINHA":
                case "ROQUE GONZALES":
                case "ROSARIO DO SUL":
                case "SAGRADA FAMILIA":
                case "SALDANHA MARINHO":
                case "SALTO DO JACUI":
                case "SALVADOR DAS MISSOES":
                case "SALVADOR DO SUL":
                case "SANANDUVA":
                case "SANTA BARBARA DO SUL":
                case "SANTA CECILIA DO SUL":
                case "SANTA CLARA DO SUL":
                case "SANTA CRUZ DO SUL":
                case "SANTA MARGARIDA DO SUL":
                //case "SANTA MARIA":
                case "SANTA MARIA DO HERVAL":
                case "SANTA ROSA":
                case "SANTA TEREZA":
                case "SANTA VITORIA DO PALMAR":
                case "SANTANA DA BOA VISTA":
                case "SANTANA DO LIVRAMENTO":
                case "SANTIAGO":
                case "SANTO ANGELO":
                case "SANTO ANTONIO DA PATRULHA":
                case "SANTO ANTONIO DAS MISSOES":
                case "SANTO ANTONIO DO PALMA":
                case "SANTO ANTONIO DO PLANALTO":
                case "SANTO AUGUSTO":
                case "SANTO CRISTO":
                case "SANTO EXPEDITO DO SUL":
                case "SAO BORJA":
                case "SAO DOMINGOS DO SUL":
                case "SAO FRANCISCO DE ASSIS":
                //case "SAO FRANCISCO DE PAULA":
                //case "SAO GABRIEL":
                case "SAO JERONIMO":
                case "SAO JOAO DA URTIGA":
                case "SAO JOAO DO POLESINE":
                case "SAO JORGE":
                case "SAO JOSE DAS MISSOES":
                case "SAO JOSE DO HERVAL":
                case "SAO JOSE DO HORTENCIO":
                case "SAO JOSE DO INHACORA":
                case "SAO JOSE DO NORTE":
                case "SAO JOSE DO OURO":
                case "SAO JOSE DO SUL":
                case "SAO JOSE DOS AUSENTES":
                case "SAO LEOPOLDO":
                case "SAO LOURENCO DO SUL":
                case "SAO LUIZ GONZAGA":
                case "SAO MARCOS":
                case "SAO MARTINHO":
                case "SAO MARTINHO DA SERRA":
                case "SAO MIGUEL DAS MISSOES":
                case "SAO NICOLAU":
                case "SAO PAULO DAS MISSOES":
                case "SAO PEDRO DA SERRA":
                case "SAO PEDRO DAS MISSOES":
                case "SAO PEDRO DO BUTIA":
                case "SAO PEDRO DO SUL":
                case "SAO SEBASTIAO DO CAI":
                case "SAO SEPE":
                case "SAO VALENTIM":
                case "SAO VALENTIM DO SUL":
                case "SAO VALERIO DO SUL":
                case "SAO VENDELINO":
                case "SAO VICENTE DO SUL":
                case "SAPIRANGA":
                case "SAPUCAIA DO SUL":
                //case "SARANDI":
                case "SEBERI":
                case "SEDE NOVA":
                case "SEGREDO":
                case "SELBACH":
                case "SENADOR SALGADO FILHO":
                case "SENTINELA DO SUL":
                case "SERAFINA CORREA":
                case "SERIO":
                case "SERTAO":
                case "SERTAO SANTANA":
                case "SETE DE SETEMBRO":
                case "SEVERIANO DE ALMEIDA":
                case "SILVEIRA MARTINS":
                case "SINIMBU":
                //case "SOBRADINHO":
                //case "SOLEDADE":
                case "TABAI":
                //case "TAPEJARA":
                case "TAPERA":
                case "TAPES":
                case "TAQUARA":
                case "TAQUARI":
                case "TAQUARUCU DO SUL":
                //case "TAVARES":
                case "TENENTE PORTELA":
                case "TERRA DE AREIA":
                case "TEUTONIA":
                case "TIO HUGO":
                case "TIRADENTES DO SUL":
                case "TOROPI":
                case "TORRES":
                case "TRAMANDAI":
                case "TRAVESSEIRO":
                case "TRES ARROIOS":
                case "TRES CACHOEIRAS":
                case "TRES COROAS":
                case "TRES DE MAIO":
                case "TRES FORQUILHAS":
                case "TRES PALMEIRAS":
                case "TRES PASSOS":
                case "TRINDADE DO SUL":
                //case "TRIUNFO":
                case "TUCUNDUVA":
                case "TUNAS":
                case "TUPANCI DO SUL":
                case "TUPANCIRETA":
                case "TUPANDI":
                case "TUPARENDI":
                case "TURUCU":
                case "UBIRETAMA":
                case "UNIAO DA SERRA":
                case "UNISTALDA":
                case "URUGUAIANA":
                case "VACARIA":
                case "VALE DO SOL":
                case "VALE REAL":
                case "VALE VERDE":
                case "VANINI":
                case "VENANCIO AIRES":
                //case "VERA CRUZ":
                case "VERANOPOLIS":
                case "VESPASIANO CORREA":
                case "VIADUTOS":
                case "VIAMAO":
                case "VICENTE DUTRA":
                case "VICTOR GRAEFF":
                case "VILA FLORES":
                case "VILA LANGARO":
                case "VILA MARIA":
                case "VILA NOVA DO SUL":
                case "VISTA ALEGRE":
                case "VISTA ALEGRE DO PRATA":
                case "VISTA GAUCHA":
                case "VITORIA DAS MISSOES":
                case "WESTFALIA":
                case "XANGRI-LA":

                    return cidade + "/RS";


                case "SANTA CATARINA":
                case "ABDON BATISTA":
                case "ABELARDO LUZ":
                case "AGROLANDIA":
                case "AGRONOMICA":
                case "AGUA DOCE":
                case "AGUAS DE CHAPECO":
                case "AGUAS FRIAS":
                case "AGUAS MORNAS":
                case "ALFREDO WAGNER":
                case "ALTO BELA VISTA":
                //case "ANCHIETA":
                case "ANGELINA":
                case "ANITA GARIBALDI":
                case "ANITAPOLIS":
                //case "ANTONIO CARLOS":
                case "APIUNA":
                case "ARABUTA":
                case "ARAQUARI":
                case "ARARANGUA":
                case "ARMAZEM":
                case "ARROIO TRINTA":
                case "ARVOREDO":
                case "ASCURRA":
                case "ATALANTA":
                //case "AURORA":
                case "BALNEARIO ARROIO DO SILVA":
                case "BALNEARIO BARRA DO SUL":
                case "BALNEARIO CAMBORIU":
                case "BALNEARIO GAIVOTA":
                case "BANDEIRANTE":
                case "BARRA BONITA":
                case "BARRA VELHA":
                case "BELA VISTA DO TOLDO":
                //case "BELMONTE":
                case "BENEDITO NOVO":
                case "BIGUACU":
                case "BLUMENAU":
                case "BOCAINA DO SUL":
                case "BOM JARDIM DA SERRA":
                //case "BOM JESUS":
                case "BOM JESUS DO OESTE":
                case "BOM RETIRO":
                case "BOMBINHAS":
                case "BOTUVERA":
                case "BRACO DO NORTE":
                case "BRACO DO TROMBUDO":
                case "BRUNOPOLIS":
                case "BRUSQUE":
                case "CACADOR":
                case "CAIBI":
                case "CALMON":
                case "CAMBORIU":
                //case "CAMPO ALEGRE":
                case "CAMPO BELO DO SUL":
                case "CAMPO ERE":
                case "CAMPOS NOVOS":
                case "CANELINHA":
                case "CANOINHAS":
                case "CAPAO ALTO":
                case "CAPINZAL":
                case "CAPIVARI DE BAIXO":
                //case "CATANDUVAS":
                case "CAXAMBU DO SUL":
                case "CELSO RAMOS":
                case "CERRO NEGRO":
                case "CHAPADAO DO LAGEADO":
                case "CHAPECO":
                case "COCAL DO SUL":
                case "CONCORDIA":
                case "CORDILHEIRA ALTA":
                case "CORONEL FREITAS":
                case "CORONEL MARTINS":
                case "CORREIA PINTO":
                case "CORUPA":
                case "CRICIUMA":
                case "CUNHA PORA":
                case "CUNHATAI":
                case "CURITIBANOS":
                case "DESCANSO":
                case "DIONISIO CERQUEIRA":
                case "DONA EMMA":
                case "DOUTOR PEDRINHO":
                //case "ENTRE RIOS":
                case "ERMO":
                case "ERVAL VELHO":
                case "FAXINAL DOS GUEDES":
                case "FLOR DO SERTAO":
                case "FLORIANOPOLIS":
                case "FORMOSA DO SUL":
                case "FORQUILHINHA":
                case "FRAIBURGO":
                case "FREI ROGERIO":
                case "GALVAO":
                case "GAROPABA":
                case "GARUVA":
                case "GASPAR":
                case "GOVERNADOR CELSO RAMOS":
                case "GRAO PARA":
                case "GRAVATAL":
                case "GUABIRUBA":
                //case "GUARACIABA":
                case "GUARAMIRIM":
                case "GUARUJA DO SUL":
                case "GUATAMBU":
                case "HERVAL D'OESTE":
                case "IBIAM":
                case "IBICARE":
                case "IBIRAMA":
                case "ICARA":
                case "ILHOTA":
                case "IMARUI":
                case "IMBITUBA":
                case "IMBUIA":
                case "INDAIAL":
                case "IOMERE":
                //case "IPIRA":
                case "IPORA DO OESTE":
                case "IPUACU":
                case "IPUMIRIM":
                case "IRACEMINHA":
                case "IRANI":
                //case "IRATI":
                case "IRINEOPOLIS":
                case "ITA":
                case "ITAIOPOLIS":
                case "ITAJAI":
                case "ITAPEMA":
                //case "ITAPIRANGA":
                //case "ITAPOA":
                case "ITUPORANGA":
                case "JABORA":
                case "JACINTO MACHADO":
                case "JAGUARUNA":
                case "JARAGUA DO SUL":
                case "JARDINOPOLIS":
                case "JOACABA":
                case "JOINVILLE":
                case "JOSE BOITEUX":
                case "JUPIA":
                case "LACERDOPOLIS":
                case "LAGES":
                case "LAGUNA":
                case "LAJEADO GRANDE":
                case "LAURENTINO":
                case "LAURO MULLER":
                case "LEBON REGIS":
                case "LEOBERTO LEAL":
                case "LINDOIA DO SUL":
                case "LONTRAS":
                case "LUIZ ALVES":
                case "LUZERNA":
                case "MACIEIRA":
                case "MAFRA":
                case "MAJOR GERCINO":
                case "MAJOR VIEIRA":
                case "MARACAJA":
                //case "MARAVILHA":
                case "MAREMA":
                //case "MASSARANDUBA":
                case "MATOS COSTA":
                case "MELEIRO":
                case "MIRIM DOCE":
                case "MODELO":
                case "MONDAI":
                case "MONTE CARLO":
                case "MONTE CASTELO":
                case "MORRO DA FUMACA":
                case "MORRO GRANDE":
                case "NAVEGANTES":
                case "NOVA ERECHIM":
                case "NOVA ITABERABA":
                case "NOVA TRENTO":
                //case "NOVA VENEZA":
                //case "NOVO HORIZONTE":
                case "ORLEANS":
                case "OTACILIO COSTA":
                case "OURO":
                case "OURO VERDE":
                case "PAIAL":
                case "PAINEL":
                case "PALHOCA":
                case "PALMA SOLA":
                //case "PALMEIRA":
                case "PALMITOS":
                case "PAPANDUVA":
                case "PARAISO":
                case "PASSO DE TORRES":
                case "PASSOS MAIA":
                case "PAULO LOPES":
                case "PEDRAS GRANDES":
                case "PENHA":
                case "PERITIBA":
                //case "PETROLANDIA":
                case "PICARRAS":
                case "PINHALZINHO":
                case "PINHEIRO PRETO":
                case "PIRATUBA":
                case "PLANALTO ALEGRE":
                case "POMERODE":
                case "PONTE ALTA":
                case "PONTE ALTA DO NORTE":
                case "PONTE SERRADA":
                case "PORTO BELO":
                case "PORTO UNIAO":
                case "POUSO REDONDO":
                case "PRAIA GRANDE":
                //case "PRESIDENTE CASTELO BRANCO":
                case "PRESIDENTE GETULIO":
                case "PRESIDENTE NEREU":
                case "PRINCESA":
                case "QUILOMBO":
                case "RANCHO QUEIMADO":
                case "RIO DAS ANTAS":
                case "RIO DO CAMPO":
                case "RIO DO OESTE":
                case "RIO DO SUL":
                case "RIO DOS CEDROS":
                case "RIO FORTUNA":
                case "RIO NEGRINHO":
                case "RIO RUFINO":
                case "RIQUEZA":
                case "RODEIO":
                case "ROMELANDIA":
                case "SALETE":
                case "SALTINHO":
                case "SALTO VELOSO":
                case "SANGAO":
                //case "SANTA CECILIA":
                //case "SANTA HELENA":
                case "SANTA ROSA DE LIMA":
                case "SANTA ROSA DO SUL":
                //case "SANTA TEREZINHA":
                case "SANTA TEREZINHA DO PROGRESSO":
                case "SANTIAGO DO SUL":
                case "SANTO AMARO DA IMPERATRIZ":
                case "SAO BENTO DO SUL":
                case "SAO BERNARDINO":
                case "SAO BONIFACIO":
                case "SAO CARLOS":
                case "SAO CRISTOVAO DO SUL":
                //case "SAO DOMINGOS":
                case "SAO FRANCISCO DO SUL":
                //case "SAO JOAO BATISTA":
                case "SAO JOAO DO ITAPERIU":
                case "SAO JOAO DO OESTE":
                case "SAO JOAO DO SUL":
                case "SAO JOAQUIM":
                case "SAO JOSE":
                case "SAO JOSE DO CEDRO":
                case "SAO JOSE DO CERRITO":
                case "SAO LOURENCO DO OESTE":
                case "SAO LUDGERO":
                //case "SAO MARTINHO":
                case "SAO MIGUEL DA BOA VISTA":
                case "SAO MIGUEL DO OESTE":
                case "SAO PEDRO DE ALCANTARA":
                case "SAUDADES":
                case "SCHROEDER":
                case "SEARA":
                case "SERRA ALTA":
                case "SIDEROPOLIS":
                case "SOMBRIO":
                case "SUL BRASIL":
                case "TAIO":
                //case "TANGARA":
                case "TIGRINHOS":
                case "TIJUCAS":
                case "TIMBE DO SUL":
                case "TIMBO":
                case "TIMBO GRANDE":
                case "TRES BARRAS":
                case "TREVISO":
                case "TREZE DE MAIO":
                case "TREZE TILIAS":
                case "TROMBUDO CENTRAL":
                case "TUBARAO":
                case "TUNAPOLIS":
                //case "TURVO":
                case "UNIAO DO OESTE":
                case "URUBICI":
                case "URUPEMA":
                case "URUSSANGA":
                case "VARGEAO":
                case "VARGEM":
                //case "VARGEM BONITA":
                case "VIDAL RAMOS":
                case "VIDEIRA":
                case "VITOR MEIRELES":
                case "WITMARSUM":
                case "XANXERE":
                case "XAVANTINA":
                case "XAXIM":
                case "ZORTEA":

                    return cidade + "/SC";


                case "SERGIPE":
                case "AMPARO DE SAO FRANCISCO":
                case "AQUIDABA":
                case "ARACAJU":
                case "ARAUA":
                //case "AREIA BRANCA":
                case "BARRA DOS COQUEIROS":
                case "BOQUIM":
                case "BREJO GRANDE":
                case "CAMPO DO BRITO":
                case "CANHOBA":
                case "CANINDE DE SAO FRANCISCO":
                //case "CAPELA":
                case "CARIRA":
                case "CARMOPOLIS":
                case "CEDRO DE SAO JOAO":
                case "CRISTINAPOLIS":
                case "CUMBE":
                case "DIVINA PASTORA":
                case "ESTANCIA":
                //case "FEIRA NOVA":
                case "FREI PAULO":
                case "GARARU":
                case "GENERAL MAYNARD":
                case "GRACHO CARDOSO":
                case "ILHA DAS FLORES":
                case "INDIAROBA":
                //case "ITABAIANA":
                case "ITABAIANINHA":
                case "ITABI":
                case "ITAPORANGA D'AJUDA":
                case "JAPARATUBA":
                case "JAPOATA":
                case "LAGARTO":
                case "LARANJEIRAS":
                case "MACAMBIRA":
                case "MALHADA DOS BOIS":
                case "MALHADOR":
                case "MARUIM":
                case "MOITA BONITA":
                case "MONTE ALEGRE DE SERGIPE":
                case "MURIBECA":
                case "NEOPOLIS":
                case "NOSSA SENHORA APARECIDA":
                case "NOSSA SENHORA DA GLORIA":
                case "NOSSA SENHORA DAS DORES":
                case "NOSSA SENHORA DE LOURDES":
                case "NOSSA SENHORA DO SOCORRO":
                //case "PACATUBA":
                case "PEDRA MOLE":
                case "PEDRINHAS":
                //case "PINHAO":
                case "PIRAMBU":
                case "POCO REDONDO":
                case "POCO VERDE":
                case "PORTO DA FOLHA":
                case "PROPRIA":
                case "RIACHAO DO DANTAS":
                //case "RIACHUELO":
                case "RIBEIROPOLIS":
                case "ROSARIO DO CATETE":
                case "SALGADO":
                case "SANTA LUZIA DO ITANHY":
                //case "SANTA ROSA DE LIMA":
                case "SANTANA DO SAO FRANCISCO":
                case "SANTO AMARO DAS BROTAS":
                case "SAO CRISTOVAO":
                //case "SAO DOMINGOS":
                //case "SAO FRANCISCO":
                case "SAO MIGUEL DO ALEIXO":
                case "SIMAO DIAS":
                case "SIRIRI":
                case "TELHA":
                case "TOBIAS BARRETO":
                case "TOMAR DO GERU":
                case "UMBAUBA":

                    return cidade + "/SE";

                case "SAO PAULO":
                case "ADAMANTINA":
                case "ADOLFO":
                case "AGUAI":
                case "AGUAS DA PRATA":
                case "AGUAS DE LINDOIA":
                case "AGUAS DE SANTA BARBARA":
                case "AGUAS DE SAO PEDRO":
                case "AGUDOS":
                case "ALAMBARI":
                case "ALFREDO MARCONDES":
                case "ALTAIR":
                case "ALTINOPOLIS":
                //case "ALTO ALEGRE":
                case "ALUMINIO":
                case "ALVARES FLORENCE":
                case "ALVARES MACHADO":
                case "ALVARO DE CARVALHO":
                case "ALVINLANDIA":
                case "AMERICANA":
                case "AMERICO BRASILIENSE":
                case "AMERICO DE CAMPOS":
                //case "AMPARO":
                case "ANALANDIA":
                case "ANDRADINA":
                case "ANGATUBA":
                case "ANHEMBI":
                case "ANHUMAS":
                //case "APARECIDA":
                case "APARECIDA D'OESTE":
                case "APIAI":
                case "ARACARIGUAMA":
                case "ARACATUBA":
                case "ARACOIABA DA SERRA":
                case "ARAMINA":
                case "ARANDU":
                case "ARAPEI":
                case "ARARAQUARA":
                case "ARARAS":
                case "ARCO-IRIS":
                case "AREALVA":
                case "AREIAS":
                case "AREIOPOLIS":
                case "ARIRANHA":
                case "ARTUR NOGUEIRA":
                case "ARUJA":
                case "ASPASIA":
                case "ASSIS":
                case "ATIBAIA":
                case "AURIFLAMA":
                case "AVAI":
                case "AVANHANDAVA":
                case "AVARE":
                case "BADY BASSITT":
                case "BALBINOS":
                case "BALSAMO":
                case "BANANAL":
                case "BARAO DE ANTONINA":
                case "BARBOSA":
                case "BARIRI":
                //case "BARRA BONITA":
                case "BARRA DO CHAPEU":
                case "BARRA DO TURVO":
                case "BARRETOS":
                case "BARRINHA":
                case "BARUERI":
                case "BASTOS":
                case "BATATAIS":
                case "BAURU":
                case "BEBEDOURO":
                case "BENTO DE ABREU":
                case "BERNARDINO DE CAMPOS":
                case "BERTIOGA":
                case "BILAC":
                case "BIRIGUI":
                case "BIRITIBA-MIRIM":
                case "BOA ESPERANCA DO SUL":
                //case "BOCAINA":
                case "BOFETE":
                case "BOITUVA":
                case "BOM JESUS DOS PERDOES":
                case "BOM SUCESSO DE ITARARE":
                case "BORA":
                case "BORACEIA":
                //case "BORBOREMA":
                case "BOREBI":
                case "BOTUCATU":
                case "BRAGANCA PAULISTA":
                case "BRAUNA":
                case "BREJO ALEGRE":
                case "BRODOWSKI":
                case "BROTAS":
                case "BURI":
                case "BURITAMA":
                case "BURITIZAL":
                case "CABRALIA PAULISTA":
                case "CABREUVA":
                case "CACAPAVA":
                case "CACHOEIRA PAULISTA":
                case "CACONDE":
                //case "CAFELANDIA":
                case "CAIABU":
                case "CAIEIRAS":
                case "CAIUA":
                case "CAJAMAR":
                case "CAJATI":
                case "CAJOBI":
                case "CAJURU":
                case "CAMPINA DO MONTE ALEGRE":
                case "CAMPINAS":
                case "CAMPO LIMPO PAULISTA":
                case "CAMPOS DO JORDAO":
                case "CAMPOS NOVOS PAULISTA":
                case "CANANEIA":
                case "CANAS":
                case "CANDIDO MOTA":
                case "CANDIDO RODRIGUES":
                case "CANITAR":
                case "CAPAO BONITO":
                case "CAPELA DO ALTO":
                case "CAPIVARI":
                case "CARAGUATATUBA":
                case "CARAPICUIBA":
                case "CARDOSO":
                case "CASA BRANCA":
                case "CASSIA DOS COQUEIROS":
                case "CASTILHO":
                case "CATANDUVA":
                case "CATIGUA":
                //case "CEDRAL":
                case "CERQUEIRA CESAR":
                case "CERQUILHO":
                case "CESARIO LANGE":
                case "CHARQUEADA":
                case "CHAVANTES":
                case "CLEMENTINA":
                case "COLINA":
                case "COLOMBIA":
                case "CONCHAL":
                case "CONCHAS":
                case "CORDEIROPOLIS":
                case "COROADOS":
                case "CORONEL MACEDO":
                case "CORUMBATAI":
                case "COSMOPOLIS":
                case "COSMORAMA":
                case "COTIA":
                case "CRAVINHOS":
                case "CRISTAIS PAULISTA":
                case "CRUZALIA":
                //case "CRUZEIRO":
                case "CUBATAO":
                case "CUNHA":
                case "DESCALVADO":
                case "DIADEMA":
                case "DIRCE REIS":
                case "DIVINOLANDIA":
                case "DOBRADA":
                case "DOIS CORREGOS":
                case "DOLCINOPOLIS":
                case "DOURADO":
                case "DRACENA":
                case "DUARTINA":
                case "DUMONT":
                case "ECHAPORA":
                //case "ELDORADO":
                case "ELIAS FAUSTO":
                case "ELISIARIO":
                case "EMBAUBA":
                case "EMBU":
                case "EMBU-GUACU":
                case "EMILIANOPOLIS":
                case "ENGENHEIRO COELHO":
                case "ESPIRITO SANTO DO PINHAL":
                case "ESPIRITO SANTO DO TURVO":
                case "ESTIVA GERBI":
                case "ESTRELA D'OESTE":
                //case "ESTRELA DO NORTE":
                case "EUCLIDES DA CUNHA PAULISTA":
                case "FARTURA":
                case "FERNANDO PRESTES":
                case "FERNANDOPOLIS":
                case "FERNAO":
                case "FERRAZ DE VASCONCELOS":
                case "FLORA RICA":
                case "FLOREAL":
                case "FLORINIA":
                case "FLORIDA PAULISTA":
                case "FRANCA":
                case "FRANCISCO MORATO":
                case "FRANCO DA ROCHA":
                case "GABRIEL MONTEIRO":
                case "GALIA":
                case "GARCA":
                case "GASTAO VIDIGAL":
                case "GAVIAO PEIXOTO":
                case "GENERAL SALGADO":
                case "GETULINA":
                case "GLICERIO":
                case "GUAICARA":
                case "GUAIMBE":
                //case "GUAIRA":
                case "GUAPIACU":
                case "GUAPIARA":
                //case "GUARA":
                case "GUARACAI":
                //case "GUARACI":
                case "GUARANI D'OESTE":
                case "GUARANTA":
                case "GUARARAPES":
                case "GUARAREMA":
                case "GUARATINGUETA":
                case "GUAREI":
                case "GUARIBA":
                case "GUARUJA":
                case "GUARULHOS":
                case "GUATAPARA":
                case "GUZOLANDIA":
                case "HERCULANDIA":
                case "HOLAMBRA":
                case "HORTOLANDIA":
                case "IACANGA":
                case "IACRI":
                case "IARAS":
                case "IBATE":
                case "IBIRA":
                case "IBIRAREMA":
                case "IBITINGA":
                case "IBIUNA":
                case "ICEM":
                case "IEPE":
                case "IGARACU DO TIETE":
                case "IGARAPAVA":
                case "IGARATA":
                case "IGUAPE":
                case "ILHA COMPRIDA":
                case "ILHA SOLTEIRA":
                case "ILHABELA":
                case "INDAIATUBA":
                case "INDIANA":
                case "INDIAPORA":
                case "INUBIA PAULISTA":
                case "IPAUCU":
                case "IPERO":
                case "IPEUNA":
                case "IPIGUA":
                case "IPORANGA":
                case "IPUA":
                case "IRACEMAPOLIS":
                case "IRAPUA":
                case "IRAPURU":
                case "ITABERA":
                case "ITAI":
                case "ITAJOBI":
                case "ITAJU":
                case "ITANHAEM":
                case "ITAOCA":
                case "ITAPECERICA DA SERRA":
                case "ITAPETININGA":
                //case "ITAPEVA":
                case "ITAPEVI":
                case "ITAPIRA":
                case "ITAPIRAPUA PAULISTA":
                case "ITAPOLIS":
                //case "ITAPORANGA":
                case "ITAPUI":
                case "ITAPURA":
                case "ITAQUAQUECETUBA":
                case "ITARARE":
                case "ITARIRI":
                case "ITATIBA":
                case "ITATINGA":
                case "ITIRAPINA":
                case "ITIRAPUA":
                case "ITOBI":
                case "ITU":
                case "ITUPEVA":
                case "ITUVERAVA":
                //case "JABORANDI":
                case "JABOTICABAL":
                case "JACAREI":
                case "JACI":
                case "JACUPIRANGA":
                case "JAGUARIUNA":
                case "JALES":
                case "JAMBEIRO":
                case "JANDIRA":
                //case "JARDINOPOLIS":
                case "JARINU":
                case "JAU":
                case "JERIQUARA":
                case "JOANOPOLIS":
                case "JOAO RAMALHO":
                case "JOSE BONIFACIO":
                case "JULIO MESQUITA":
                case "JUMIRIM":
                case "JUNDIAI":
                case "JUNQUEIROPOLIS":
                case "JUQUIA":
                case "JUQUITIBA":
                case "LAGOINHA":
                case "LARANJAL PAULISTA":
                case "LAVINIA":
                case "LAVRINHAS":
                case "LEME":
                case "LENCOIS PAULISTA":
                case "LIMEIRA":
                case "LINDOIA":
                case "LINS":
                case "LORENA":
                case "LOURDES":
                case "LOUVEIRA":
                case "LUCELIA":
                case "LUCIANOPOLIS":
                case "LUIS ANTONIO":
                case "LUIZIANIA":
                case "LUPERCIO":
                case "LUTECIA":
                case "MACATUBA":
                case "MACAUBAL":
                case "MACEDONIA":
                case "MAGDA":
                case "MAIRINQUE":
                case "MAIRIPORA":
                case "MANDURI":
                case "MARABA PAULISTA":
                case "MARACAI":
                case "MARAPOAMA":
                case "MARIAPOLIS":
                case "MARILIA":
                case "MARINOPOLIS":
                case "MARTINOPOLIS":
                case "MATAO":
                case "MAUA":
                case "MENDONCA":
                case "MERIDIANO":
                case "MESOPOLIS":
                case "MIGUELOPOLIS":
                case "MINEIROS DO TIETE":
                case "MIRA ESTRELA":
                case "MIRACATU":
                case "MIRANDOPOLIS":
                case "MIRANTE DO PARANAPANEMA":
                case "MIRASSOL":
                case "MIRASSOLANDIA":
                case "MOCOCA":
                case "MOGI DAS CRUZES":
                case "MOGI-GUACU":
                case "MOGI-MIRIM":
                case "MOMBUCA":
                case "MONCOES":
                case "MONGAGUA":
                case "MONTE ALEGRE DO SUL":
                case "MONTE ALTO":
                case "MONTE APRAZIVEL":
                case "MONTE AZUL PAULISTA":
                //case "MONTE CASTELO":
                case "MONTE MOR":
                case "MONTEIRO LOBATO":
                case "MORRO AGUDO":
                case "MORUNGABA":
                case "MOTUCA":
                case "MURUTINGA DO SUL":
                case "NANTES":
                case "NARANDIBA":
                case "NATIVIDADE DA SERRA":
                case "NAZARE PAULISTA":
                case "NEVES PAULISTA":
                case "NHANDEARA":
                case "NIPOA":
                case "NOVA ALIANCA":
                case "NOVA CAMPINA":
                case "NOVA CANAA PAULISTA":
                case "NOVA CASTILHO":
                case "NOVA EUROPA":
                case "NOVA GRANADA":
                case "NOVA GUATAPORANGA":
                case "NOVA INDEPENDENCIA":
                case "NOVA LUZITANIA":
                case "NOVA ODESSA":
                case "NOVAIS":
                //case "NOVO HORIZONTE":
                case "NUPORANGA":
                case "OCAUCU":
                case "OLEO":
                case "OLIMPIA":
                case "ONDA VERDE":
                case "ORIENTE":
                case "ORINDIUVA":
                case "ORLANDIA":
                case "OSASCO":
                case "OSCAR BRESSANE":
                case "OSVALDO CRUZ":
                case "OURINHOS":
                //case "OURO VERDE":
                case "OUROESTE":
                case "PACAEMBU":
                //case "PALESTINA":
                case "PALMARES PAULISTA":
                case "PALMEIRA D'OESTE":
                //case "PALMITAL":
                case "PANORAMA":
                case "PARAGUACU PAULISTA":
                case "PARAIBUNA":
                //case "PARAISO":
                case "PARANAPANEMA":
                case "PARANAPUA":
                case "PARAPUA":
                case "PARDINHO":
                case "PARIQUERA-ACU":
                case "PARISI":
                case "PATROCINIO PAULISTA":
                case "PAULICEIA":
                case "PAULINIA":
                case "PAULISTANIA":
                case "PAULO DE FARIA":
                case "PEDERNEIRAS":
                case "PEDRA BELA":
                case "PEDRANOPOLIS":
                case "PEDREGULHO":
                case "PEDREIRA":
                case "PEDRINHAS PAULISTA":
                case "PEDRO DE TOLEDO":
                case "PENAPOLIS":
                case "PEREIRA BARRETO":
                case "PEREIRAS":
                case "PERUIBE":
                case "PIACATU":
                case "PIEDADE":
                case "PILAR DO SUL":
                case "PINDAMONHANGABA":
                case "PINDORAMA":
                //case "PINHALZINHO":
                case "PIQUEROBI":
                case "PIQUETE":
                case "PIRACAIA":
                case "PIRACICABA":
                case "PIRAJU":
                case "PIRAJUI":
                case "PIRANGI":
                case "PIRAPORA DO BOM JESUS":
                case "PIRAPOZINHO":
                case "PIRASSUNUNGA":
                case "PIRATININGA":
                //case "PITANGUEIRAS":
                //case "PLANALTO":
                case "PLATINA":
                case "POA":
                case "POLONI":
                case "POMPEIA":
                case "PONGAI":
                case "PONTAL":
                case "PONTALINDA":
                case "PONTES GESTAL":
                case "POPULINA":
                case "PORANGABA":
                case "PORTO FELIZ":
                case "PORTO FERREIRA":
                case "POTIM":
                case "POTIRENDABA":
                case "PRACINHA":
                case "PRADOPOLIS":
                //case "PRAIA GRANDE":
                case "PRATANIA":
                case "PRESIDENTE ALVES":
                //case "PRESIDENTE BERNARDES":
                case "PRESIDENTE EPITACIO":
                case "PRESIDENTE PRUDENTE":
                case "PRESIDENTE VENCESLAU":
                case "PROMISSAO":
                case "QUADRA":
                case "QUATA":
                case "QUEIROZ":
                case "QUELUZ":
                case "QUINTANA":
                case "RAFARD":
                case "RANCHARIA":
                case "REDENCAO DA SERRA":
                case "REGENTE FEIJO":
                case "REGINOPOLIS":
                case "REGISTRO":
                case "RESTINGA":
                case "RIBEIRA":
                case "RIBEIRAO BONITO":
                case "RIBEIRAO BRANCO":
                case "RIBEIRAO CORRENTE":
                case "RIBEIRAO DO SUL":
                case "RIBEIRAO DOS INDIOS":
                case "RIBEIRAO GRANDE":
                case "RIBEIRAO PIRES":
                case "RIBEIRAO PRETO":
                case "RIFAINA":
                case "RINCAO":
                case "RINOPOLIS":
                //case "RIO CLARO":
                case "RIO DAS PEDRAS":
                case "RIO GRANDE DA SERRA":
                case "RIOLANDIA":
                case "RIVERSUL":
                case "ROSANA":
                case "ROSEIRA":
                case "RUBIACEA":
                case "RUBINEIA":
                case "SABINO":
                case "SAGRES":
                case "SALES":
                case "SALES OLIVEIRA":
                case "SALESOPOLIS":
                case "SALMOURAO":
                //case "SALTINHO":
                case "SALTO":
                case "SALTO DE PIRAPORA":
                case "SALTO GRANDE":
                case "SANDOVALINA":
                case "SANTA ADELIA":
                case "SANTA ALBERTINA":
                case "SANTA BARBARA D'OESTE":
                case "SANTA BRANCA":
                case "SANTA CLARA D'OESTE":
                case "SANTA CRUZ DA CONCEICAO":
                case "SANTA CRUZ DA ESPERANCA":
                case "SANTA CRUZ DAS PALMEIRAS":
                case "SANTA CRUZ DO RIO PARDO":
                case "SANTA ERNESTINA":
                case "SANTA FE DO SUL":
                case "SANTA GERTRUDES":
                //case "SANTA ISABEL":
                //case "SANTA LUCIA":
                case "SANTA MARIA DA SERRA":
                case "SANTA MERCEDES":
                case "SANTA RITA D'OESTE":
                case "SANTA RITA DO PASSA QUATRO":
                case "SANTA ROSA DE VITERBO":
                case "SANTA SALETE":
                case "SANTANA DA PONTE PENSA":
                case "SANTANA DE PARNAIBA":
                case "SANTO ANASTACIO":
                //case "SANTO ANDRE":
                case "SANTO ANTONIO DA ALEGRIA":
                case "SANTO ANTONIO DE POSSE":
                case "SANTO ANTONIO DO ARACANGUA":
                case "SANTO ANTONIO DO JARDIM":
                case "SANTO ANTONIO DO PINHAL":
                case "SANTO EXPEDITO":
                case "SANTOPOLIS DO AGUAPEI":
                case "SANTOS":
                case "SAO BENTO DO SAPUCAI":
                case "SAO BERNARDO DO CAMPO":
                case "SAO CAETANO DO SUL":
                //case "SAO CARLOS":
                //case "SAO FRANCISCO":
                case "SAO JOAO DA BOA VISTA":
                case "SAO JOAO DAS DUAS PONTES":
                case "SAO JOAO DE IRACEMA":
                case "SAO JOAO DO PAU D'ALHO":
                case "SAO JOAQUIM DA BARRA":
                case "SAO JOSE DA BELA VISTA":
                case "SAO JOSE DO BARREIRO":
                case "SAO JOSE DO RIO PARDO":
                case "SAO JOSE DO RIO PRETO":
                case "SAO JOSE DOS CAMPOS":
                case "SAO LOURENCO DA SERRA":
                case "SAO LUIS DO PARAITINGA":
                case "SAO MANUEL":
                case "SAO MIGUEL ARCANJO":
                //case "SAO PAULO":
                //case "SAO PEDRO":
                case "SAO PEDRO DO TURVO":
                case "SAO ROQUE":
                //case "SAO SEBASTIAO":
                case "SAO SEBASTIAO DA GRAMA":
                //case "SAO SIMAO":
                //case "SAO VICENTE":
                case "SARAPUI":
                case "SARUTAIA":
                case "SEBASTIANOPOLIS DO SUL":
                case "SERRA AZUL":
                case "SERRA NEGRA":
                case "SERRANA":
                //case "SERTAOZINHO":
                case "SETE BARRAS":
                case "SEVERINIA":
                case "SILVEIRAS":
                case "SOCORRO":
                case "SOROCABA":
                case "SUD MENNUCCI":
                case "SUMARE":
                case "SUZANAPOLIS":
                case "SUZANO":
                case "TABAPUA":
                //case "TABATINGA":
                case "TABOAO DA SERRA":
                case "TACIBA":
                case "TAGUAI":
                case "TAIACU":
                case "TAIUVA":
                case "TAMBAU":
                case "TANABI":
                //case "TAPIRAI":
                case "TAPIRATIBA":
                case "TAQUARAL":
                case "TAQUARITINGA":
                case "TAQUARITUBA":
                case "TAQUARIVAI":
                case "TARABAI":
                case "TARUMA":
                case "TATUI":
                case "TAUBATE":
                case "TEJUPA":
                //case "TEODORO SAMPAIO":
                //case "TERRA ROXA":
                case "TIETE":
                case "TIMBURI":
                case "TORRE DE PEDRA":
                case "TORRINHA":
                case "TRABIJU":
                case "TREMEMBE":
                case "TRES FRONTEIRAS":
                case "TUIUTI":
                case "TUPA":
                case "TUPI PAULISTA":
                case "TURIUBA":
                //case "TURMALINA":
                case "UBARANA":
                case "UBATUBA":
                case "UBIRAJARA":
                case "UCHOA":
                case "UNIAO PAULISTA":
                case "URANIA":
                case "URU":
                case "URUPES":
                case "VALENTIM GENTIL":
                case "VALINHOS":
                case "VALPARAISO":
                //case "VARGEM":
                case "VARGEM GRANDE DO SUL":
                case "VARGEM GRANDE PAULISTA":
                case "VARZEA PAULISTA":
                //case "VERA CRUZ":
                case "VINHEDO":
                case "VIRADOURO":
                case "VISTA ALEGRE DO ALTO":
                case "VITORIA BRASIL":
                case "VOTORANTIM":
                case "VOTUPORANGA":
                case "ZACARIAS":

                    return cidade + "/SP";


                //case "TOCANTINS":
                case "ABREULANDIA":
                case "AGUIARNOPOLIS":
                case "ALIANCA DO TOCANTINS":
                case "ALMAS":
                //case "ALVORADA":
                case "ANANAS":
                case "ANGICO":
                case "APARECIDA DO RIO NEGRO":
                case "ARAGOMINAS":
                case "ARAGUACEMA":
                case "ARAGUACU":
                case "ARAGUAINA":
                //case "ARAGUANA":
                case "ARAGUATINS":
                case "ARAPOEMA":
                case "ARRAIAS":
                case "AUGUSTINOPOLIS":
                case "AURORA DO TOCANTINS":
                case "AXIXA DO TOCANTINS":
                case "BABACULANDIA":
                case "BANDEIRANTES DO TOCANTINS":
                case "BARRA DO OURO":
                case "BARROLANDIA":
                case "BERNARDO SAYAO":
                //case "BOM JESUS DO TOCANTINS":
                case "BRASILANDIA DO TOCANTINS":
                case "BREJINHO DE NAZARE":
                case "BURITI DO TOCANTINS":
                //case "CACHOEIRINHA":
                case "CAMPOS LINDOS":
                case "CARIRI DO TOCANTINS":
                case "CARMOLANDIA":
                case "CARRASCO BONITO":
                case "CASEARA":
                //case "CENTENARIO":
                case "CHAPADA DA NATIVIDADE":
                case "CHAPADA DE AREIA":
                case "COLINAS DO TOCANTINS":
                case "COLMEIA":
                case "COMBINADO":
                case "CONCEICAO DO TOCANTINS":
                case "COUTO MAGALHAES":
                case "CRISTALANDIA":
                case "CRIXAS DO TOCANTINS":
                case "DARCINOPOLIS":
                case "DIANOPOLIS":
                case "DIVINOPOLIS DO TOCANTINS":
                case "DOIS IRMAOS DO TOCANTINS":
                case "DUERE":
                //case "ESPERANTINA":
                //case "FATIMA":
                case "FIGUEIROPOLIS":
                //case "FILADELFIA":
                case "FORMOSO DO ARAGUAIA":
                case "FORTALEZA DO TABOCAO":
                case "GOIANORTE":
                case "GOIATINS":
                case "GUARAI":
                case "GURUPI":
                //case "IPUEIRAS":
                case "ITACAJA":
                case "ITAGUATINS":
                case "ITAPIRATINS":
                case "ITAPORA DO TOCANTINS":
                case "JAU DO TOCANTINS":
                case "JUARINA":
                case "LAGOA DA CONFUSAO":
                case "LAGOA DO TOCANTINS":
                //case "LAJEADO":
                case "LAVANDEIRA":
                case "LIZARDA":
                case "LUZINOPOLIS":
                case "MARIANOPOLIS DO TOCANTINS":
                case "MATEIROS":
                case "MAURILANDIA DO TOCANTINS":
                case "MIRACEMA DO TOCANTINS":
                case "MIRANORTE":
                case "MONTE DO CARMO":
                case "MONTE SANTO DO TOCANTINS":
                case "MURICILANDIA":
                //case "NATIVIDADE":
                //case "NAZARE":
                //case "NOVA OLINDA":
                case "NOVA ROSALANDIA":
                case "NOVO ACORDO":
                case "NOVO ALEGRE":
                case "NOVO JARDIM":
                case "OLIVEIRA DE FATIMA":
                //case "PALMAS":
                case "PALMEIRANTE":
                case "PALMEIRAS DO TOCANTINS":
                case "PALMEIROPOLIS":
                case "PARAISO DO TOCANTINS":
                //case "PARANA":
                //case "PAU D'ARCO":
                case "PEDRO AFONSO":
                case "PEIXE":
                case "PEQUIZEIRO":
                case "PINDORAMA DO TOCANTINS":
                case "PIRAQUE":
                case "PIUM":
                case "PONTE ALTA DO BOM JESUS":
                case "PONTE ALTA DO TOCANTINS":
                case "PORTO ALEGRE DO TOCANTINS":
                case "PORTO NACIONAL":
                case "PRAIA NORTE":
                //case "PRESIDENTE KENNEDY":
                case "PUGMIL":
                case "RECURSOLANDIA":
                //case "RIACHINHO":
                case "RIO DA CONCEICAO":
                case "RIO DOS BOIS":
                case "RIO SONO":
                case "SAMPAIO":
                case "SANDOLANDIA":
                case "SANTA FE DO ARAGUAIA":
                case "SANTA MARIA DO TOCANTINS":
                case "SANTA RITA DO TOCANTINS":
                case "SANTA ROSA DO TOCANTINS":
                case "SANTA TEREZA DO TOCANTINS":
                case "SANTA TEREZINHA DO TOCANTINS":
                case "SAO BENTO DO TOCANTINS":
                case "SAO FELIX DO TOCANTINS":
                case "SAO MIGUEL DO TOCANTINS":
                case "SAO SALVADOR DO TOCANTINS":
                case "SAO SEBASTIAO DO TOCANTINS":
                case "SAO VALERIO":
                case "SILVANOPOLIS":
                case "SITIO NOVO DO TOCANTINS":
                case "SUCUPIRA":
                //case "TAGUATINGA":
                case "TAIPAS DO TOCANTINS":
                case "TALISMA":
                case "TOCANTINIA":
                case "TOCANTINOPOLIS":
                case "TUPIRAMA":
                case "TUPIRATINS":
                case "WANDERLANDIA":
                case "XAMBIOA":

                    return cidade + "/TO";

            }
            return cidade.Trim();
        }

        #endregion

        #region Retorna Cidade baseado no Estado
        private string RetornaCidadeEstado(string cidade, string stringEstado)
        {
            cidade = RemoveAcentuacao(cidade);
            cidade = cidade.ToUpper();
            cidade = cidade.Trim();

            #region Capitais/Estados
            if (cidade == "FARIA LIMA" || cidade == "DUTRA")
            {
                cidade = "SAO PAULO";
            }
            if (cidade == "ST" || cidade == "ST. BARBARA D’OESTE" || cidade == "SANTA BARBARA D OESTE" || cidade == "SANTA BARBARA DO OESTE" || cidade == "SANTA BARBARA DOESTE")
            {
                cidade = "SANTA BARBARA D'OESTE";
            }

            if (cidade == "SANTA CATARINA")
                cidade = "FLORIANOPOLIS";
            if (cidade == "ACRE")
                cidade = "RIO BRANCO";
            if (cidade == "ALAGOAS")
                cidade = "MACEIO";
            if (cidade == "AMAPA")
                cidade = "MACAPA";
            if (cidade == "AMAZONAS")
                cidade = "MANAUS";
            if (cidade == "BAHIA")
                cidade = "SALVADOR";
            if (cidade == "CEARA")
                cidade = "FORTALEZA";
            if (cidade == "ESPIRITO SANTO")
                cidade = "VITORIA";
            if (cidade == "GOIAS")
                cidade = "GOIANIA";
            if (cidade == "MARANHAO")
                cidade = "SAO LUIS";
            if (cidade == "MATO GROSSO")
                cidade = "CUIBA";
            if (cidade == "MATO GROSSO DO SUL")
                cidade = "CAMPO GRANDE";
            if (cidade == "MINAS GERAIS")
                cidade = "BELO HORIZONTE";
            //if (cidade == "PARA")
            //    cidade = "BELEM";
            if (cidade == "PARAIBA")
                cidade = "JOAO PESSOA";
            if (cidade == "PARANA")
                cidade = "CURITIBA";
            if (cidade == "PERNAMBUCO")
                cidade = "RECIFE";
            if (cidade == "RIO GRANDE DO NORTE")
                cidade = "NATAL";
            if (cidade == "RIO GRANDE DO SUL")
                cidade = "PORTO ALEGRE";
            if (cidade == "RONDONIA")
                cidade = "PORTO VELHO";
            if (cidade == "SERGIPE")
                cidade = "ARACAJU";
            if (cidade == "TOCANTINS")
                cidade = "PALMAS";
            #endregion 

            string estadoAux = RetornaSiglaEstado(stringEstado);
            estadoAux = estadoAux.ToUpper();
            if (!string.IsNullOrEmpty(estadoAux))
            {
                foreach (var estadoCidade in estadosCidade)
                {
                    if (estadoCidade.Key.Equals(estadoAux))
                    {
                        return estadoCidade.Value.Contains(cidade) ? $"{cidade}/{estadoCidade.Key}" : "";
                    }
                }
            }
            return "";
        }
        #endregion

        #region Retorna Sigla do Estado
        private string RetornaSiglaEstado(string estado)
        {
            #region Lista de Estados e suas siglas
            Dictionary<string, string> listaEstadoAux = new Dictionary<string, string>() {
                {"AC","ACRE"},
                {"AL","ALAGOAS"},
                {"AP","AMAPA"},
                {"AM","AMAZONAS"},
                {"BA","BAHIA"},
                {"CE","CEARA"},
                {"DF","DISTRITO FEDERAL"},
                {"ES","ESPIRITO SANTO"},
                {"GO","GOIAS"},
                {"MA","MARANHAO"},
                {"MT","MATO GROSSO"},
                {"MS","MATO GROSSO DO SUL"},
                {"MG","MINAS GERAIS"},
                {"PA","PARA"},
                {"PB","PARAIBA"},
                {"PR","PARANA"},
                {"PE","PERNAMBUCO"},
                {"PI","PIAUI"},
                {"RJ","RIO DE JANEIRO"},
                {"RN","RIO GRANDE DO NORTE"},
                {"RS","RIO GRANDE DO SUL"},
                {"RO","RONDONIA"},
                {"RR","RORAIMA"},
                {"SC","SANTA CATARINA"},
                {"SP","SAO PAULO"},
                {"SE","SERGIPE"},
                {"TO","TOCANTINS"}};
            #endregion
            var estadoAux = RemoveAcentuacao(estado);
            estadoAux = estadoAux.ToUpper();
            estadoAux = estadoAux.Trim();
            foreach (var item in listaEstadoAux)
            {
                if ((item.Value.Equals(estadoAux)) || (item.Key.Equals(estadoAux)))
                    return item.Key;
            }
            return "";
        }
        #endregion
    }
}
