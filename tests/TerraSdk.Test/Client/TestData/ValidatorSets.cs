using System.Diagnostics.CodeAnalysis;
using TerraSdk.Client.ModelsOld;
using TerraSdk.Common.Extensions;

namespace TerraSdk.Test.Client.TestData
{
    public class ValidatorSets
    {
        [return: NotNullIfNotNull("str")]
        private static byte[]? ParseBase64( string str) => ByteArrayExtensions.ParseBase64(str);

        /// <summary>
        /// Creates validator set response, which was made by querying https://api.Terra.network/validatorsets/1
        /// And converting resulting json to C# code. 
        /// </summary>
        public static ResponseWithHeight<ValidatorSet> FirstValidatorSet()
        {
            return new ResponseWithHeight<ValidatorSet>()
            {
                Height = 0,
                Result = new ValidatorSet()
                {
                    BlockHeight = 1,
                    Validators = new TendermintValidator[]
                    {
                        new TendermintValidator
                        {
                            Address = ParseBase64("Terravalcons1qqqqrezrl53hujmpdch6d805ac75n220ku09rl"),
                            PubKey =
                                "Terravalconspub1zcjduepq7mft6gfls57a0a42d7uhx656cckhfvtrlmw744jv4q0mvlv0dypskehfk8",
                            ProposerPriority = 240363,
                            VotingPower = 240363
                        },
                        new TendermintValidator
                        {
                            Address = ParseBase64("Terravalcons1qq92t2l4jz5pt67tmts8ptl4p0jhr6utx5xa8y"),
                            PubKey =
                                "Terravalconspub1zcjduepqe93asg05nlnj30ej2pe3r8rkeryyuflhtfw3clqjphxn4j3u27msrr63nk",
                            ProposerPriority = 2007379,
                            VotingPower = 2007379
                        },
                        new TendermintValidator
                        {
                            Address = ParseBase64("Terravalcons1qxdeeg55f57vxmruwv5rau743etv3fw530uf8x"),
                            PubKey =
                                "Terravalconspub1zcjduepq55mjplg9gy979ua9r5qmk2wr5nysmputt28j0zsgadn933lyh32sh20cmm",
                            ProposerPriority = 750443,
                            VotingPower = 750443
                        },
                        new TendermintValidator
                        {
                            Address = ParseBase64("Terravalcons1qex0qkzhk4t0a436cv5zrlusgvfdpukghc302f"),
                            PubKey =
                                "Terravalconspub1zcjduepqe4egjtvcewavewd4rvukeks60jeaxpujevl6kkgcwj0phpxgg3sse83m68",
                            ProposerPriority = 808213,
                            VotingPower = 808213
                        },
                        new TendermintValidator
                        {
                            Address = ParseBase64("Terravalcons1px0zkz2cxvc6lh34uhafveea9jnaagckmrlsye"),
                            PubKey =
                                "Terravalconspub1zcjduepq0dc9apn3pz2x2qyujcnl2heqq4aceput2uaucuvhrjts75q0rv5smjjn7v",
                            ProposerPriority = 6833973,
                            VotingPower = 6833973
                        },
                        new TendermintValidator
                        {
                            Address = ParseBase64("Terravalcons1p5scdpmdymvg9aa72r0dj27nedfc8q2r3zermn"),
                            PubKey =
                                "Terravalconspub1zcjduepquxeuhp0gj88u5mrukuazzrxc4rnjjuakls4fr2gzxlwj4f9p8lfs965r7z",
                            ProposerPriority = 147459,
                            VotingPower = 147459
                        },
                        new TendermintValidator
                        {
                            Address = ParseBase64("Terravalcons1rrrc6y6unkqawnmzxnday6xy0u8cn6zyl5yhtr"),
                            PubKey =
                                "Terravalconspub1zcjduepqz679nxu2dkfd6y9hytqwvf2z4yuevraqykkm2464ag4e6z278h3qdq92xu",
                            ProposerPriority = 771260,
                            VotingPower = 771260
                        },
                        new TendermintValidator
                        {
                            Address = ParseBase64("Terravalcons1rtst6se0nfgjy362v33jt5d05crgdyhfvvvvay"),
                            PubKey =
                                "Terravalconspub1zcjduepq5e8w7t7k9pwfewgrwy8vn6cghk0x49chx64vt0054yl4wwsmjgrqfackxm",
                            ProposerPriority = 870910,
                            VotingPower = 870910
                        },
                        new TendermintValidator
                        {
                            Address = ParseBase64("Terravalcons1r6wwjn7shfw0awgply9uvkxkfkzmzdxjyma30v"),
                            PubKey =
                                "Terravalconspub1zcjduepqfuxvufupnsm7v5anpwd7z8ec70z2k209j7xclnm25zz7vauhyc5qjgxx3h",
                            ProposerPriority = 575601,
                            VotingPower = 575601
                        },
                        new TendermintValidator
                        {
                            Address = ParseBase64("Terravalcons1yxv746y5egu3l2p0q8pvv99lavgr6ptvdhx306"),
                            PubKey =
                                "Terravalconspub1zcjduepqp0j4vum7ryt6nl6zsgq9ar347afmq2c5z6jmzeavv2p2ns6m0dgs5zmg4z",
                            ProposerPriority = 11834382,
                            VotingPower = 11834382
                        },
                        new TendermintValidator
                        {
                            Address = ParseBase64("Terravalcons1y35q3lcg7wpwkq8pyh6s3zm0uv4e0zzhvncv7h"),
                            PubKey =
                                "Terravalconspub1zcjduepqfndze9l7th79g0m4fguf5cueksmywl6sw2xhuz7gp6jatr39ffuqn3exk9",
                            ProposerPriority = 113305,
                            VotingPower = 113305
                        },
                        new TendermintValidator
                        {
                            Address = ParseBase64("Terravalcons19wd9t5alj0tnwhwjq7m4chk562u3my2xwt72qg"),
                            PubKey =
                                "Terravalconspub1zcjduepqs0et7kpf82glsw5j9jnppekrpa7kl6gr6xk67ztqg9ynmhgj82ks9edcrw",
                            ProposerPriority = 457390,
                            VotingPower = 457390
                        },
                        new TendermintValidator
                        {
                            Address = ParseBase64("Terravalcons193fg6g69a4hf20qupqv79saqr2luhf2hladw0j"),
                            PubKey =
                                "Terravalconspub1zcjduepqsl29jhapyxf4fa5a947dmnlvrt266fm959hfg2c657ju80hq0ljs3qejr7",
                            ProposerPriority = 250002,
                            VotingPower = 250002
                        },
                        new TendermintValidator
                        {
                            Address = ParseBase64("Terravalcons19jwvcvtlk2pa2jk8fzpc5e8jjyrq88j3h8y9v2"),
                            PubKey =
                                "Terravalconspub1zcjduepqvn4a4skwj88c8e0jvns3qjrhyy0whvnuwmth3k8kexvqk5vupw4qsdje47",
                            ProposerPriority = 1090322,
                            VotingPower = 1090322
                        },
                        new TendermintValidator
                        {
                            Address = ParseBase64("Terravalcons1xxfqlx7r5wdkdpmvcltdtevfuype80cwmrrtae"),
                            PubKey =
                                "Terravalconspub1zcjduepqjc07nu2ya8tyzl8m385rnc382pkulwt2gh8yary73f3a96jak7pqsf63xf",
                            ProposerPriority = 5136569,
                            VotingPower = 5136569
                        },
                        new TendermintValidator
                        {
                            Address = ParseBase64("Terravalcons1xd3737tmqtkvqq5fuush8kp82scy0tx6882l4q"),
                            PubKey =
                                "Terravalconspub1zcjduepqnru7aa6ayyuwddd5qsa6tvutzs7xl9jk6pfx4ka5dr4y9d3q6eesgz9rz7",
                            ProposerPriority = 301633,
                            VotingPower = 301633
                        },
                        new TendermintValidator
                        {
                            Address = ParseBase64("Terravalcons1xsehlmhrdvpue82unavmxzxquvtakcrupua5p8"),
                            PubKey =
                                "Terravalconspub1zcjduepqmgwzcm3aqmc8nln9u4q5ydsjwx6rzqrch6p243x2gtzetnx5l3ls432euv",
                            ProposerPriority = 416777,
                            VotingPower = 416777
                        },
                        new TendermintValidator
                        {
                            Address = ParseBase64("Terravalcons18xt8rsh7fvn3fmrwsl2wu32w790n8232mlz4p6"),
                            PubKey =
                                "Terravalconspub1zcjduepq8xpk5nh78lmgg0s0qqdyh4xtcw66xemt8anjsr6hrvlhauq252kstq7zr7",
                            ProposerPriority = 1324644,
                            VotingPower = 1324644
                        },
                        new TendermintValidator
                        {
                            Address = ParseBase64("Terravalcons1gpl3gngunh4yae4ge0pdfspz5et4q6ury3yyvp"),
                            PubKey =
                                "Terravalconspub1zcjduepqwr5p8j076mfydn7wckqz748lr0j50zwgsftnfpvgz6rz0rkvvqwqg5fyaf",
                            ProposerPriority = 263015,
                            VotingPower = 263015
                        },
                        new TendermintValidator
                        {
                            Address = ParseBase64("Terravalcons1gtt8qhn3vcttff2y90d2q59hcm5lmhjrr5menw"),
                            PubKey =
                                "Terravalconspub1zcjduepq9weu2v0za8fdcvx0w3ps972k5v7sm6h5as9qaznc437vwpfxu37q0f3lyg",
                            ProposerPriority = 1452397,
                            VotingPower = 1452397
                        },
                        new TendermintValidator
                        {
                            Address = ParseBase64("Terravalcons1g63l3wpe8w4p20zqu4ezat5zagx53vedf849wa"),
                            PubKey =
                                "Terravalconspub1zcjduepqajqpmv4j70a08ahs8lyjt8qk28ffa77zjegd7yajghchy8au575qmmxuyt",
                            ProposerPriority = 565710,
                            VotingPower = 565710
                        },
                        new TendermintValidator
                        {
                            Address = ParseBase64("Terravalcons1fyr09ffnfkgx5nrrl85av9f8486e8380f3mvng"),
                            PubKey =
                                "Terravalconspub1zcjduepq668g4epaumjtx35rk3ucz2nlm7l7zuewkt0kzutg9hha859zjxmsvl2v67",
                            ProposerPriority = 646812,
                            VotingPower = 646812
                        },
                        new TendermintValidator
                        {
                            Address = ParseBase64("Terravalcons1fxalkxap5ag99cezd68purh7kvu33w9jhtryqq"),
                            PubKey =
                                "Terravalconspub1zcjduepq0cet8ez89wj4yz8uencych7aldc5wyyrpx6jvh6n6kxxslumln5sxkq922",
                            ProposerPriority = 1288016,
                            VotingPower = 1288016
                        },
                        new TendermintValidator
                        {
                            Address = ParseBase64("Terravalcons1ftmf66j5xmpsudvyc93ggv772hn430x2kj93pq"),
                            PubKey =
                                "Terravalconspub1zcjduepquuc5k7egx8ymejamr27c3sgw6tyhmt0eq0ak4qvflvhxx56nvjzsx9etmd",
                            ProposerPriority = 4260028,
                            VotingPower = 4260028
                        },
                        new TendermintValidator
                        {
                            Address = ParseBase64("Terravalcons1fjfzxravzc3s8kvpcpkayfnr5n78vg4u68zz0s"),
                            PubKey =
                                "Terravalconspub1zcjduepqgx5xdrx0xktl5r8e3w7vj329fgh3fnep8ahgx8027nd5nkjxzuqs5us5en",
                            ProposerPriority = 673138,
                            VotingPower = 673138
                        },
                        new TendermintValidator
                        {
                            Address = ParseBase64("Terravalcons1f6wt886tr7npwvuhgjjkqzmzsqn9945uym9g3q"),
                            PubKey =
                                "Terravalconspub1zcjduepqnnh28nlj55sc329ppnhcr0xx7kuc9vnsp3dpwc28wdhhxtjc7jfs9k57f7",
                            ProposerPriority = 333672,
                            VotingPower = 333672
                        },
                        new TendermintValidator
                        {
                            Address = ParseBase64("Terravalcons12ys9vkd8zl0lh9hq2nut6yggwv8p0t4882vg4k"),
                            PubKey =
                                "Terravalconspub1zcjduepqtj2urav4g9wex3hku588au0x4sucrc9lpky46zp5u8w4mvd584sqmcxxhs",
                            ProposerPriority = 5919803,
                            VotingPower = 5919803
                        },
                        new TendermintValidator
                        {
                            Address = ParseBase64("Terravalcons128dj2e3qfm3xvsn74znvkuvcxk43wzlfngfrz8"),
                            PubKey =
                                "Terravalconspub1zcjduepq5tm478lhn4du7l46yp6fgu9e8fcfks0j4kf87pk4z8vc3clckxzqvh2q72",
                            ProposerPriority = 698511,
                            VotingPower = 698511
                        },
                        new TendermintValidator
                        {
                            Address = ParseBase64("Terravalcons12tskgcf5gv4lj5etfzqudmfjus9wtgka8znl6y"),
                            PubKey =
                                "Terravalconspub1zcjduepqzu34dgs2p6ysz52hpdycls4jcfwgnf2pvxv0eh539ypmadkjfmes6mwaa3",
                            ProposerPriority = 250982,
                            VotingPower = 250982
                        },
                        new TendermintValidator
                        {
                            Address = ParseBase64("Terravalcons12uccfrsey4mst23ge3l042x8prhqzn2j6fffxd"),
                            PubKey =
                                "Terravalconspub1zcjduepqncdd6lvm4r42eke822e5eg0alentpvlxjwzat7nvpynlp0vcu55sl5z96g",
                            ProposerPriority = 245002,
                            VotingPower = 245002
                        },
                        new TendermintValidator
                        {
                            Address = ParseBase64("Terravalcons12acnhd6zr3l7kwqmsclusl0dt6pf42tpw50hqz"),
                            PubKey =
                                "Terravalconspub1zcjduepq8y846wm58fmmuctxp7csqmaz3594xnykcean0lp722ntf6u5ycaqss4prd",
                            ProposerPriority = 1176114,
                            VotingPower = 1176114
                        },
                        new TendermintValidator
                        {
                            Address = ParseBase64("Terravalcons1t2e48d6g630jph7wr8tnh2ylymsuxn8huya638"),
                            PubKey =
                                "Terravalconspub1zcjduepq87zcnf8sm4ewacjafqujfevt8rhwj5qk9uwtx4ef89ctuqmndkeq446ahw",
                            ProposerPriority = 832362,
                            VotingPower = 832362
                        },
                        new TendermintValidator
                        {
                            Address = ParseBase64("Terravalcons1vu2xpycvehymqmzaq40y64gwhrd0y2g77ec8vl"),
                            PubKey =
                                "Terravalconspub1zcjduepqmfxl36td7rcdzszzrk6c7kzp5l3jlw4lnxz8zms3py7qcsa9xlns7zxfd6",
                            ProposerPriority = 3858330,
                            VotingPower = 3858330
                        },
                        new TendermintValidator
                        {
                            Address = ParseBase64("Terravalcons1v7dcj7zewwlff48alzmxlp9f9xfjayw9qznplh"),
                            PubKey =
                                "Terravalconspub1zcjduepqg6y8magedjwr9p6s2c28zp28jdjtecxhn97ew6tnuzqklg63zgfspp9y3n",
                            ProposerPriority = 11231582,
                            VotingPower = 11231582
                        },
                        new TendermintValidator
                        {
                            Address = ParseBase64("Terravalcons1dr6mh6kw7y2vwg82njvtlghlmcqu2n730pfk8a"),
                            PubKey =
                                "Terravalconspub1zcjduepqtcsm8lp7n6ph98vd59qa9esgyuysuntww9juz5wynxrhzpspmuuq6g5pzg",
                            ProposerPriority = 395542,
                            VotingPower = 395542
                        },
                        new TendermintValidator
                        {
                            Address = ParseBase64("Terravalcons1d94te9gcdlt95pc9ps52kqxfxk9rz5psfatv7y"),
                            PubKey =
                                "Terravalconspub1zcjduepqrgyyjxpe0ujefxwnkpmqz9m0hj03y09tdz9lwc0s7mvy469hulfq69f8sd",
                            ProposerPriority = 1471123,
                            VotingPower = 1471123
                        },
                        new TendermintValidator
                        {
                            Address = ParseBase64("Terravalcons1dj6867rt9u6scyaxpwmh6wv2eqhfqzv9favv9l"),
                            PubKey =
                                "Terravalconspub1zcjduepqmuspsp8739l0lgn2qz0arargk6ccfy2p82mwflsrsqzwpvhuh5usuwykf6",
                            ProposerPriority = 101467,
                            VotingPower = 101467
                        },
                        new TendermintValidator
                        {
                            Address = ParseBase64("Terravalcons1wz8amnsjrndd55p09vp99lh38ld2x8jsmswdm6"),
                            PubKey =
                                "Terravalconspub1zcjduepq2nfs6lcwu6ksq54yf0ptgrmjjrnm5p5ywng3x0t0767m777hvctq30rwcs",
                            ProposerPriority = 243175,
                            VotingPower = 243175
                        },
                        new TendermintValidator
                        {
                            Address = ParseBase64("Terravalcons1wrzmfenhn3v6yn8aj9r9s838qgwz4mpx3dsgl3"),
                            PubKey =
                                "Terravalconspub1zcjduepqd85nu5nelvcyyzcsrr0yaglh8rfvn6cv9pp3p0hgmwtk8hf3cazqc7vz5c",
                            ProposerPriority = 1351509,
                            VotingPower = 1351509
                        },
                        new TendermintValidator
                        {
                            Address = ParseBase64("Terravalcons1wvkwaa2vxaxac6k7e07hq7h06pl7ms2rt2x4d9"),
                            PubKey =
                                "Terravalconspub1zcjduepqrc6g9m2eyy4zs7kyeph8vk5ldpgnceveelc39zf7lc32j8k3shqssevdlg",
                            ProposerPriority = 213253,
                            VotingPower = 213253
                        },
                        new TendermintValidator
                        {
                            Address = ParseBase64("Terravalcons1whdtx9h5egfk0afj4dc6szml5edtdype42hm00"),
                            PubKey =
                                "Terravalconspub1zcjduepqjg26g27dtvjqstyqktmp4jsn98473vfz0mek2eyklfp0yqapav5szdrvpd",
                            ProposerPriority = 3835971,
                            VotingPower = 3835971
                        },
                        new TendermintValidator
                        {
                            Address = ParseBase64("Terravalcons1we6v0lnevz6gdwss2tdzyh65zx2cp6m5c80595"),
                            PubKey =
                                "Terravalconspub1zcjduepqjdc9grwq5mxdtg26hv9t75y3ltsau3rtmg6p72p0dh8343nj4s6qr6xymd",
                            ProposerPriority = 500172,
                            VotingPower = 500172
                        },
                        new TendermintValidator
                        {
                            Address = ParseBase64("Terravalcons10fqk678xexhu7y2ef89qjtnphnvahzsc30vjap"),
                            PubKey =
                                "Terravalconspub1zcjduepqv03r9c26w884sqw0zdqg9cdx4xxwgn3dd2s6wa3x346tm83nxudqwhm3jl",
                            ProposerPriority = 147809,
                            VotingPower = 147809
                        },
                        new TendermintValidator
                        {
                            Address = ParseBase64("Terravalcons10vazaljm8lxlsx0u75nqwv2valj82jak592py8"),
                            PubKey =
                                "Terravalconspub1zcjduepq6adydsk7nw3d63qtn30t5rexhfg56pq44sw4l9ld0tcj6jvnx30s5xw9ar",
                            ProposerPriority = 2183351,
                            VotingPower = 2183351
                        },
                        new TendermintValidator
                        {
                            Address = ParseBase64("Terravalcons10v7sra65mluywnksudvgzt75xlsf8zwuzsq8r3"),
                            PubKey =
                                "Terravalconspub1zcjduepq279zs0zgd53ujngs6v2hus2le9rk2a2rs66j4yvv6ewvvxn29yqqk95h8x",
                            ProposerPriority = 670190,
                            VotingPower = 670190
                        },
                        new TendermintValidator
                        {
                            Address = ParseBase64("Terravalcons1szxkkp22pdknla04atc2vh8uvnz587pnwa9sj9"),
                            PubKey =
                                "Terravalconspub1zcjduepqu08f7tuce8k88tgewhwer69kfvk5az3cn5lz3v8phl8gvu9nxu8qhrjxfj",
                            ProposerPriority = 681496,
                            VotingPower = 681496
                        },
                        new TendermintValidator
                        {
                            Address = ParseBase64("Terravalcons1sxykfd8mxmfgzzwrapfh0zenyvdj030ud35k24"),
                            PubKey =
                                "Terravalconspub1zcjduepql9j7qpwvfl0pspymhesj48t3t0aazjx0m2jwjuyxd7zw53hqnkss4hmasl",
                            ProposerPriority = 290625,
                            VotingPower = 290625
                        },
                        new TendermintValidator
                        {
                            Address = ParseBase64("Terravalcons1sxt9l69pt75q0ryjqtejun86wtu9723zyaezq8"),
                            PubKey =
                                "Terravalconspub1zcjduepq8hu49qdl5594rzxmdsww3hleu8phxrajjfsseqjere9mjrrrv9tq35mll4",
                            ProposerPriority = 2143563,
                            VotingPower = 2143563
                        },
                        new TendermintValidator
                        {
                            Address = ParseBase64("Terravalcons1sveqdx72n5f9uu4lsljd59evn6pmjr75pjq2fa"),
                            PubKey =
                                "Terravalconspub1zcjduepq7qnf5r40z7esjc2utrjrvzxg9sfd683hw0805ek85ddchdcptthqjnzxxu",
                            ProposerPriority = 142315,
                            VotingPower = 142315
                        },
                        new TendermintValidator
                        {
                            Address = ParseBase64("Terravalcons1s0686a68krmr8f46ph6fklw0v8us4gdsm7nhz3"),
                            PubKey =
                                "Terravalconspub1zcjduepqtw8862dhw8uty58d6t2szfd6kqram2t234zjteaaeem6l45wclaq8l60gn",
                            ProposerPriority = 5000018,
                            VotingPower = 5000018
                        },
                        new TendermintValidator
                        {
                            Address = ParseBase64("Terravalcons1s347fuu7xy3d9gknle29fcjkzpe7j4fc2dk40r"),
                            PubKey =
                                "Terravalconspub1zcjduepqt0fpxxufuuhavfqh8zg3pjnnwdvvzw9huemzxe59kpjt5e3xprhs7d8khn",
                            ProposerPriority = 411000,
                            VotingPower = 411000
                        },
                        new TendermintValidator
                        {
                            Address = ParseBase64("Terravalcons1saxk42pc8p98ng756p39g8u3halrr0d64grcp3"),
                            PubKey =
                                "Terravalconspub1zcjduepq5l63vgd8m9chc3c32wn5lthzsax6xxdylpzmhqmjwrgfhd3m2swsj2wc2d",
                            ProposerPriority = 110713,
                            VotingPower = 110713
                        },
                        new TendermintValidator
                        {
                            Address = ParseBase64("Terravalcons13c8wx7mmrgpcm529uv83a7ta7dseaapfj2eket"),
                            PubKey =
                                "Terravalconspub1zcjduepqf22yaz9nsxlh043qm0tmupw8pnpver2n8lm3mwz6jzmsql76fkmqa482y8",
                            ProposerPriority = 500021,
                            VotingPower = 500021
                        },
                        new TendermintValidator
                        {
                            Address = ParseBase64("Terravalcons13l3ul7n2q7cf8ezphwzd5xmd406n473d8t9apq"),
                            PubKey =
                                "Terravalconspub1zcjduepqc8slfqdszcd85wzzweuanv0em4h4gdc5wkh3et6e7t8z93z24u0s0rdlx2",
                            ProposerPriority = 1728147,
                            VotingPower = 1728147
                        },
                        new TendermintValidator
                        {
                            Address = ParseBase64("Terravalcons1j8yz8f6ymeg0j8qh534kynkl3ac4pf7a4xhrhr"),
                            PubKey =
                                "Terravalconspub1zcjduepql42t7mstnewp5rgweteuw95hawzystll7mq8dl24n5yh0th7q2jqetcy07",
                            ProposerPriority = 720400,
                            VotingPower = 720400
                        },
                        new TendermintValidator
                        {
                            Address = ParseBase64("Terravalcons1j4dy0j9vscegyhw5wh5sjy75p2cf60a53qkgch"),
                            PubKey =
                                "Terravalconspub1zcjduepqny59kv2elgh89tq9qr4jje2n0my4gyvh2hlnydzljtt542a5plwswtas48",
                            ProposerPriority = 153541,
                            VotingPower = 153541
                        },
                        new TendermintValidator
                        {
                            Address = ParseBase64("Terravalcons1jhsxp5rhzvrsl6vz9ak9p0tkhn9lnut6ehz9ej"),
                            PubKey =
                                "Terravalconspub1zcjduepqdgvppnyr5c9pulsrmzr9e9rp7qpgm9jwp5yu8g3aumekgjugxacq8a9p2c",
                            ProposerPriority = 5694839,
                            VotingPower = 5694839
                        },
                        new TendermintValidator
                        {
                            Address = ParseBase64("Terravalcons1nstujnmnzwa56msxg2rmam096wygazz4y6as4g"),
                            PubKey =
                                "Terravalconspub1zcjduepqxtu8am2qmf0qnglqtvkar9gaclhccfn29tsp7n82vasrtnc8m2fsulp4h2",
                            ProposerPriority = 1591075,
                            VotingPower = 1591075
                        },
                        new TendermintValidator
                        {
                            Address = ParseBase64("Terravalcons1n5rmxqwj8328yek4t5dkckncefrn8qap29nhqw"),
                            PubKey =
                                "Terravalconspub1zcjduepq59t2nm3ph5k6uc804w0n7ey69ul8ntee2dy47d7u53q248ud822sunv93j",
                            ProposerPriority = 1649386,
                            VotingPower = 1649386
                        },
                        new TendermintValidator
                        {
                            Address = ParseBase64("Terravalcons1nhzqzgyehe6rrzg8fwz7fxy34canlm5m6dm4wg"),
                            PubKey =
                                "Terravalconspub1zcjduepqarrl0ppddzyczwvcqwf3jwd9qwkhxfy6lcv8ep4msk293mlxg39qgf77y3",
                            ProposerPriority = 822402,
                            VotingPower = 822402
                        },
                        new TendermintValidator
                        {
                            Address = ParseBase64("Terravalcons1nhuwxwxgt6rehjztp24z3gytgvdatd2g7kndfm"),
                            PubKey =
                                "Terravalconspub1zcjduepqfc7vnpgls3an0w2pv60pu4vr30p2dxqlmhmlrdv0m38y3tg689vs5qg4u5",
                            ProposerPriority = 132111,
                            VotingPower = 132111
                        },
                        new TendermintValidator
                        {
                            Address = ParseBase64("Terravalcons1nc2r2t949y7xqu7kz2q2r9cgt3n53kh6aluuac"),
                            PubKey =
                                "Terravalconspub1zcjduepqlecm0rrfrr0vfgl624s7su9xvd3ycsaetndeuw2c7us0v8vfyfsq7cqz80",
                            ProposerPriority = 104497,
                            VotingPower = 104497
                        },
                        new TendermintValidator
                        {
                            Address = ParseBase64("Terravalcons1nm55mwux7u3nwxft72gmpem8l5njnuq274qrz6"),
                            PubKey =
                                "Terravalconspub1zcjduepqsszd2gzte82dzt0xpa3w0ky8lxhjs6zpd5ft8akmkscwujpftymsnt83qc",
                            ProposerPriority = 1775899,
                            VotingPower = 1775899
                        },
                        new TendermintValidator
                        {
                            Address = ParseBase64("Terravalcons15q7uz2xn3kctchcc4cv89uwt9c0agy2h524xk9"),
                            PubKey =
                                "Terravalconspub1zcjduepqmq2l5ehgl3rxwjgzgr6sgzp69qwjl5ufvtyvacc9ms8p3phazl2qh3ulfw",
                            ProposerPriority = 169980,
                            VotingPower = 169980
                        },
                        new TendermintValidator
                        {
                            Address = ParseBase64("Terravalcons15nca2560875stfx6vphg5yyrf9m9z8lheucgef"),
                            PubKey =
                                "Terravalconspub1zcjduepqqddwwkhkfrsd66u49kg3h6q36t4kv557vlszqaed4c3y936ncq9s0r0tm2",
                            ProposerPriority = 1575138,
                            VotingPower = 1575138
                        },
                        new TendermintValidator
                        {
                            Address = ParseBase64("Terravalcons156f4mpmmjamvgkuka6h9y62e5wu6t2c6ld3frz"),
                            PubKey =
                                "Terravalconspub1zcjduepqteacnywz7urnac46wtrcy34myyj82j250ny7866yffypdgavae5s0lf4a0",
                            ProposerPriority = 4111833,
                            VotingPower = 4111833
                        },
                        new TendermintValidator
                        {
                            Address = ParseBase64("Terravalcons14sk4vptumprktehmuvvf0yynarjy4gv08t64t4"),
                            PubKey =
                                "Terravalconspub1zcjduepq6fpkt3qn9xd7u44478ypkhrvtx45uhfj3uhdny420hzgsssrvh3qnzwdpe",
                            ProposerPriority = -174420902,
                            VotingPower = 11964505
                        },
                        new TendermintValidator
                        {
                            Address = ParseBase64("Terravalcons14jy970hgreldqll8ktsxw3p6s40ej7apnt0rh7"),
                            PubKey =
                                "Terravalconspub1zcjduepqqaffdhuhdtr0d6nl8twpraxps74q3mxn68qknrex465yd9cc9l0qeh6lkk",
                            ProposerPriority = 162252,
                            VotingPower = 162252
                        },
                        new TendermintValidator
                        {
                            Address = ParseBase64("Terravalcons1kq9xxgmn0uepav9c6kwxl4yh599kpyu28e7ee6"),
                            PubKey =
                                "Terravalconspub1zcjduepqwrjpn0slu86e32zfu5xxg8l42uk40guuw6er44vw2yl6s7wc38est6l0ux",
                            ProposerPriority = 7277166,
                            VotingPower = 7277166
                        },
                        new TendermintValidator
                        {
                            Address = ParseBase64("Terravalcons1kq24y5kh8dlwkaxj4rxgzsuhue5hp2petveuva"),
                            PubKey =
                                "Terravalconspub1zcjduepqcdav5ylt2zst90qmuh8e5w07xmxv9y6wufp5k9ngzmx7v9qewqtqkcq4z8",
                            ProposerPriority = 431921,
                            VotingPower = 431921
                        },
                        new TendermintValidator
                        {
                            Address = ParseBase64("Terravalcons1kpm95tm0esga3tzxya06cpkaxh65y97pmqgmng"),
                            PubKey =
                                "Terravalconspub1zcjduepq3f6wnsk6k6qu6g8n5vly4z7ajw7q930wh3qx6zkxhktnh49l40kszf5lry",
                            ProposerPriority = 1126977,
                            VotingPower = 1126977
                        },
                        new TendermintValidator
                        {
                            Address = ParseBase64("Terravalcons1kyt86pphmwwlp4fnac4vmeypqufehhfw8zucrv"),
                            PubKey =
                                "Terravalconspub1zcjduepquhlqdhjw4qp2c2t6qh5z7tfk52qc72623f0etc8f3n7hy8uuh25ql34fvu",
                            ProposerPriority = 11427953,
                            VotingPower = 11427953
                        },
                        new TendermintValidator
                        {
                            Address = ParseBase64("Terravalcons1kdzerkne4tgzzdf5ut53tagduhxmmujs4xx79v"),
                            PubKey =
                                "Terravalconspub1zcjduepqnd9kzfhhvuv5k2cq62yu0e5v73ymsgxa0wlen9c7999ucwg7hg6qdm34pm",
                            ProposerPriority = 580294,
                            VotingPower = 580294
                        },
                        new TendermintValidator
                        {
                            Address = ParseBase64("Terravalcons1kjvee4f4unxn9dvsh668qg98yn6qke09p5ngx5"),
                            PubKey =
                                "Terravalconspub1zcjduepqf8llkc4p43lksktsqzr5nmgmw4ln9pzym2vp4kqfrny8xrgnqrsq76djjc",
                            ProposerPriority = 796717,
                            VotingPower = 796717
                        },
                        new TendermintValidator
                        {
                            Address = ParseBase64("Terravalcons1knssshcun6asa2v5g5ktrwqjfw5fhmg686lfzr"),
                            PubKey =
                                "Terravalconspub1zcjduepqlzmd0spn9m0m3eq9zp93d4w6e5tugamv44yqjzyacelnvra634fqnfec0r",
                            ProposerPriority = 1083482,
                            VotingPower = 1083482
                        },
                        new TendermintValidator
                        {
                            Address = ParseBase64("Terravalcons1k4p60h6g0q9wlm6e8gqre5rqkkfufe44q2mfsa"),
                            PubKey =
                                "Terravalconspub1zcjduepq9ge7uqrfp9qkdapzd29tjtwrqpt2mm9meptx395ygxgm40tdc8ysrzj40a",
                            ProposerPriority = 439025,
                            VotingPower = 439025
                        },
                        new TendermintValidator
                        {
                            Address = ParseBase64("Terravalcons1kmtnvrp878wrdhvmlnerqda73vzy9ysfhmm90x"),
                            PubKey =
                                "Terravalconspub1zcjduepq2hfnf0rvk6nksvtzkqly4vy362sencfkt7tgsrvx30krj5vxw0asa7hmjh",
                            ProposerPriority = 492025,
                            VotingPower = 492025
                        },
                        new TendermintValidator
                        {
                            Address = ParseBase64("Terravalcons1htpn7dq0xjth28cjfp50qj0v96ynptp0s0hclt"),
                            PubKey =
                                "Terravalconspub1zcjduepq7jsrkl9fgqk0wj3ahmfr8pgxj6vakj2wzn656s8pehh0zhv2w5as5gd80a",
                            ProposerPriority = 2453106,
                            VotingPower = 2453106
                        },
                        new TendermintValidator
                        {
                            Address = ParseBase64("Terravalcons1haxtf4var829rn6700zfxjwlf23z94utgygkd7"),
                            PubKey =
                                "Terravalconspub1zcjduepq0zyaquh6c8vmjfzft43uqylf2ejjpjcvup2zrtsk40uyz8xsq29s0k4eaw",
                            ProposerPriority = 351702,
                            VotingPower = 351702
                        },
                        new TendermintValidator
                        {
                            Address = ParseBase64("Terravalcons1cg6kvg45j4e9jcd4kgq68qka2lxnxp0vddkz6t"),
                            PubKey =
                                "Terravalconspub1zcjduepq5kg8xls9l35ftulkm2rt70hexeeyr5cqqkcv4h7936z5uasvvazqla8eck",
                            ProposerPriority = 8441446,
                            VotingPower = 8441446
                        },
                        new TendermintValidator
                        {
                            Address = ParseBase64("Terravalcons1ctwajuqv7h0vq3tacs3c9xe3a28af7w5cpvj7z"),
                            PubKey =
                                "Terravalconspub1zcjduepqz83dmnt4g6w0w6syrf433mwpk86zejxnq6e336xtxd8pg9jtxkgq732tpu",
                            ProposerPriority = 330982,
                            VotingPower = 330982
                        },
                        new TendermintValidator
                        {
                            Address = ParseBase64("Terravalcons1cjgry2deat2pt3u737nf62a6vytkzlzpglpxkc"),
                            PubKey =
                                "Terravalconspub1zcjduepq6740f8r23xr74w94l5ew9fh6n8wquutgm22pw6yyrydq507mgdkqghsjtd",
                            ProposerPriority = 204984,
                            VotingPower = 204984
                        },
                        new TendermintValidator
                        {
                            Address = ParseBase64("Terravalcons1c54vmveq2l6uwvdmm4yyvzuncdgqm5eylrg0af"),
                            PubKey =
                                "Terravalconspub1zcjduepqjcp9ez3dzmvsdfcw2h5kllmqvjgqnhtlvhad4q9wzcqf34gf6ewq6zl5mm",
                            ProposerPriority = 730138,
                            VotingPower = 730138
                        },
                        new TendermintValidator
                        {
                            Address = ParseBase64("Terravalcons1efnfda07v6jgp0epgcp3n05hnycg2twspd2nej"),
                            PubKey =
                                "Terravalconspub1zcjduepqc5y2du793cjut0cn6v7thp3xlvphggk6rt2dhw9ekjla5wtkm7nstmv5vy",
                            ProposerPriority = 607351,
                            VotingPower = 607351
                        },
                        new TendermintValidator
                        {
                            Address = ParseBase64("Terravalcons1eszcs2tcl30a66nhy958u9xq9xdwqp9c65dnm6"),
                            PubKey =
                                "Terravalconspub1zcjduepq04y0dtylyed2f8drc9t78dmptfuta7l6xyujwmsgrqefs0sxpgjsnzpsj6",
                            ProposerPriority = 1563880,
                            VotingPower = 1563880
                        },
                        new TendermintValidator
                        {
                            Address = ParseBase64("Terravalcons16999gt582mp6jskelky88hpwnfme3gtlaaat0s"),
                            PubKey =
                                "Terravalconspub1zcjduepqvmmhug9hcmm26ce7we0n3esavn4c6tfcfd6zgnuj732ls7khjq4srpg0ft",
                            ProposerPriority = 1216829,
                            VotingPower = 1216829
                        },
                        new TendermintValidator
                        {
                            Address = ParseBase64("Terravalcons164q2kq3q3psj436t9p7swmdlh39rw73wpy6qx6"),
                            PubKey =
                                "Terravalconspub1zcjduepqfahazsjeru5wqulfuzklmkh272ggss2ru6fk00zq2fmlfzcq773sqlqe42",
                            ProposerPriority = 1466456,
                            VotingPower = 1466456
                        },
                        new TendermintValidator
                        {
                            Address = ParseBase64("Terravalcons16lmu09y8cy99eudtavwmmq0g6jt403pz97zaxp"),
                            PubKey =
                                "Terravalconspub1zcjduepqd4hvh0rwfkhtwrj4ly3ptyxs8pyfaser57wx2tcnzzp0rlref90sxm5kwr",
                            ProposerPriority = 510513,
                            VotingPower = 510513
                        },
                        new TendermintValidator
                        {
                            Address = ParseBase64("Terravalcons1m8u2gxmc92n2v6kus8u48y3u0h88kcqp69cr3a"),
                            PubKey =
                                "Terravalconspub1zcjduepqnltddase4lqjcfhup8ymg0qex3srakg54ppv06pstvwdjxkm6tmq08znvs",
                            ProposerPriority = 4708118,
                            VotingPower = 4708118
                        },
                        new TendermintValidator
                        {
                            Address = ParseBase64("Terravalcons1mf42422ee8hc3gltx7clzp7tyen7hw4t3vnmw0"),
                            PubKey =
                                "Terravalconspub1zcjduepq9xu9z6ky3nz3k544ar4zhupjehkxdlpmt2l90kekxkrvuu7hxfgslcdqwy",
                            ProposerPriority = 1968448,
                            VotingPower = 1968448
                        },
                        new TendermintValidator
                        {
                            Address = ParseBase64("Terravalcons1aqq8grrgeqdnqdzu8t3t5cu054hlvlh062nhqx"),
                            PubKey =
                                "Terravalconspub1zcjduepqhm6gjjkwecqyfrgey96s5up7drnspnl4t3rdr79grklkg9ff6zaqnfl2dg",
                            ProposerPriority = 2124603,
                            VotingPower = 2124603
                        },
                        new TendermintValidator
                        {
                            Address = ParseBase64("Terravalcons1avwlyfg8k7wwwq8cd3xgky7hmuqalk5ud6acax"),
                            PubKey =
                                "Terravalconspub1zcjduepqft6uxfmfjjce0p7ke4h0zc38x4d9d38wlmrgcc47flru92qq3ydq76mrsf",
                            ProposerPriority = 114928,
                            VotingPower = 114928
                        },
                        new TendermintValidator
                        {
                            Address = ParseBase64("Terravalcons1a0kkjnnvuy3ylv0g5twcae368ptgk83tyalw6t"),
                            PubKey =
                                "Terravalconspub1zcjduepqelcwpat987h9yq0ck6g9fsc8t0mththk547gwvk0w4wnkpl0stnspr3hdc",
                            ProposerPriority = 1557750,
                            VotingPower = 1557750
                        },
                        new TendermintValidator
                        {
                            Address = ParseBase64("Terravalcons1a4gfu7qf0cfsd2glah5wskm46p4amahrjvtw2p"),
                            PubKey =
                                "Terravalconspub1zcjduepq9kun5ty55rl3lnmf46tfxhj06as8h7zpxcdhujm6d708ffn6kgss43q6u9",
                            ProposerPriority = 5810711,
                            VotingPower = 5810711
                        },
                        new TendermintValidator
                        {
                            Address = ParseBase64("Terravalcons1aee6r9636kx9aszycy0rldawdpdpp5kpdm0yux"),
                            PubKey =
                                "Terravalconspub1zcjduepqjnnwe2jsywv0kfc97pz04zkm7tc9k2437cde2my3y5js9t7cw9mstfg3sa",
                            ProposerPriority = 3831965,
                            VotingPower = 3831965
                        },
                        new TendermintValidator
                        {
                            Address = ParseBase64("Terravalcons17n9tgyx724nakgpm64kxjnah34yzg7dp63zp5e"),
                            PubKey =
                                "Terravalconspub1zcjduepqvc5xdrpvduse3fc084s56n4a6dhzudyzjmywjx25fkgw2fhsj70searwgy",
                            ProposerPriority = 1769111,
                            VotingPower = 1769111
                        },
                        new TendermintValidator
                        {
                            Address = ParseBase64("Terravalcons174t3gfpaxtaktdketg5aqdgw5r9th282zhjnqk"),
                            PubKey =
                                "Terravalconspub1zcjduepqmy5ja8dee3sprtmxkekcuvwz20y2x9d6llcsjl6p6553rpqev0eql6qccf",
                            ProposerPriority = 122066,
                            VotingPower = 122066
                        },
                        new TendermintValidator
                        {
                            Address = ParseBase64("Terravalcons1lyveqfcfkayz7qwqxr5t27le8wxcwppmjn39zm"),
                            PubKey =
                                "Terravalconspub1zcjduepqfkkyuexns2l7rw2mx2ms988heah0rjv42e9q88scc3ms5hzg45psycrvr4",
                            ProposerPriority = 873694,
                            VotingPower = 873694
                        },
                        new TendermintValidator
                        {
                            Address = ParseBase64("Terravalcons1lg89m7kvmnm5j4a8gg2yle2mucw5xvmhtyqp6f"),
                            PubKey =
                                "Terravalconspub1zcjduepqfgpyq4xk4s96ksmkfrr7juea9kmdxkl5ht94xgpxe240743u9cvsht489p",
                            ProposerPriority = 958943,
                            VotingPower = 958943
                        },
                        new TendermintValidator
                        {
                            Address = ParseBase64("Terravalcons1l4w4fcxeu3mgl6jvphlaez06j6mx2lej9yhszt"),
                            PubKey =
                                "Terravalconspub1zcjduepqay5ldqdmyzy9qfr93enxmm7cwsd5aafz6huqvczytqahpw4twa8qvtrwhv",
                            ProposerPriority = 636706,
                            VotingPower = 636706
                        }
                    }
                }
            };
        }
    }
}