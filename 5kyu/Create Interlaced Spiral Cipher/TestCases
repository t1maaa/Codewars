namespace Crucible
{
  using NUnit.Framework;
  // https://nunit.org/
  // https://github.com/nunit
  
  using System;
  // using System.Collections.Generic;
  using System.Linq;
  using System.Text;
  // using System.Text.RegularExpressions;
  using ISC = InterlacedSpiralCipher;
  
  public class Full_Test_Suite
  {
    private static string chars_list = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ_!@#$%^&()[]{}+-*/=\"'<>,.?:; ";
    private static void Print(string s) => Console.WriteLine(s);
    private static Random RN = new Random();
    
    private static int RR(params int[] r){
      int x,y;
      switch(r.Length){
        case 0: x = 0; y = 2; break;
        case 1: x = 0; y = r[0] < 2 ? 2 : r[0]; break;
        default: x = r[0]; y = r[1]; break;}
      return RN.Next(x,y);
    }
    
    // REFERENCE SOLUTION (Encode method)
    private static string ref_encode(string s){
      int ln = Convert.ToInt32(Math.Ceiling(Math.Sqrt((double)s.Length)));
      var tome = new char[ln][];
      for (int i = 0; i < ln; i++){
        tome[i] = new string(' ',ln).ToCharArray();}
      int nc = ln -1;
      int lc = 0,
        bc = 0,
        x,y;
      for (int i = 0; i < s.Length; i++){
        int z = i%2;
        int q = i%4;
        if (q == 0 && i != 0){bc++;}
        if (lc+bc == nc){lc++;nc--;bc=0;}
        if (z == 0){
          int c = q/2;
          if (c == 0){x = lc; y = lc+bc;}
          else {x = nc; y = nc-bc;}}
        else {
          int c = (q-1)/2;
          if (c == 0){x = lc+bc; y = nc;}
          else {x = nc-bc; y = lc;}}
        tome[x][y] = s[i];}
      
      return string.Join("",tome.Select(cr => new string(cr)));
    }
    // END REFERENCE SOLUTION
    
    
    // FIXED TESTS
    [TestFixture,Description("20 FIXED TESTS")]
    public class Fixed_Test_Suite
    {
      [Test,Description("10 ENCODE TESTS"),TestCaseSource("FixedTests")]
      public static void FixedEncodeTesting(string s1,string s2){
        Assert.That(ISC.Encode(s1),Is.EqualTo(s2));}
      
      [Test,Description("10 DECODE TESTS"),TestCaseSource("FixedTests")]
      public static void FixedDecodeTesting(string s1,string s2){
        Assert.That(ISC.Decode(s2),Is.EqualTo(s1));}
      
      private static string[][] FixedTests =
      {
        new []{"Romani ite domum","Rntodomiimuea  m"},
        new []{"Sic transit gloria mundi","Stsgiriuar i ninmd l otac"},
        new []{"When the going gets tough, the tough get going","W  nethghho ,t t ngeggh  gugiti ogteteg  onus ohe"},
        new []{"Started from the bottom now we're here","Stf  tt nweroet    eree    tmr   eb   h'wormohoda"},
        new []{"I am so clever that sometimes I don't understand a single word of what I'm saying","I cehsts  dtdt ioselerfa  lesI'amder dhngy aatsosi taovno w wni 'g nrun mImmt eoa"},
        new []{"Even though I walk through the darkest valley, I will fear no evil, for you are with me","E uIlhghavesay laottdvifyawllgtnh   mo, ue     owktl     r raI    eirh e teur, eove fi l rnk  o whhe"},
        new []{"If life seems jolly rotten there's something you've forgotten, and that's to laugh and smile and dance and sing. When you're feeling in the dumps, don't be silly chumps. Just purse your lips and whistle, that's the thing!","Iisslreh'oh 'ffgonnhs gnm  ctf ani nu l tdd,eunpso syu.s,nd gd pu rpnhrnWalte utlt'heyb  ossgswth!ih i'lneaehat   ss fhetuelitg nedmidstoo u   a,i iim 'etes  losthaiot.d Jpcle' udymasmenneryhg ev e anl  att  tolreone r tyjee "},
        new []{"We passed upon the stair; we spoke of was and when. Although I wasn't there, he said I was his friend, which came as some surprise. I spoke into his eyes, \"I thought you died alone, a long long time ago\"","Wadoht; kfsdeAeho ate s airdus wh e ersIoiiI hno  sIotuehcsnnf al,l gmoe  eahpiag   o ,sraow oi     o  h odihn     lupase uhg       eIer,m\"     \"e  s shsee tonandks t'ms dygt yini pwhtes.rsoaac,neh e   ieetn glpt.waw pwi  us "},
        new []{"You like Huey Lewis and the News? Their early work was a little too New Wave for my taste. But when \"Sports\" came out in '83, I think they really came into their own, commercially and artistically.","Yl ywatN?eeyraoa ttNW  teuh\"liwor et ,tkeetlHo lymntrnor co lwralaasa.le ei Bhe      nt anhtncy     rh'fhs  wc     t  me r3ii     l,ha  en        m .i  ui  litdycytae maim oeo cae e \"l tiI8ioasSketpn  syovwoeis   wrrTwedsLuku"},
        new []{"I would be presumptuous, indeed, to present myself against the distinguished gentlemen to whom you have listened if this were but a measuring of ability; but this is not a contest among persons. The humblest citizen in all the land when clad in the armor of a righteous cause is stronger than all the whole hosts of error that they can bring.","Iubrmo e pemlgshin is teoooale t etmhlisug l;tistceagrrged nshueczilhaw . letuead  ofrtsui eanpnrnnstgt   lortmi uas   s erahcoeas mie tlah bg  rrhri ue d tuo     . a esvtstoahet     ttin ir  i  lh     ewel nn,hhionon   iae eoiydyu m  ny trfssnshf,hylent hhlaroshmwautihn ecoga rhic  tumfTled   nttb  s epnnopotnan tbtboies daabeifese  w eeegout  i steodnsts dw"}
      };
    }
    
    
    // RANDOM TESTS
    [TestFixture,Description("100 RANDOM TESTS")]
    public class Random_Test_Suite
    {
      // RANDOM TEST GENERATOR
      private static string test_gen(int n) => String.Join("",Enumerable.Range(0,RR(7*n)+8*n).Select(e => chars_list[RR(81)])).Trim();
      
      // return a copy of array w/ index values shuffled
      private static string[][] newmix(string[][] r){
        int ln = r.Length;
        var nr = new string[ln][];
        r.CopyTo(nr,0);
        for (int i = 0; i < ln; i++){
          int q = RR(ln);
          string[] c = nr[q];
          nr[q] = nr[i];
          nr[i] = c;}
        return nr;
      }
      
      private static string[][] RandomTests = Enumerable.Range(1,50).Select(e => test_gen(e)).Select(e => new string[]{e,ref_encode(e)}).ToArray();
      private static string[][] RandomTests2 = newmix(RandomTests);
      
      [Test,Description("50 ENCODE TESTS"),TestCaseSource("RandomTests")]
      public static void RandomEncodeTesting(string s1,string s2){
        Assert.That(ISC.Encode(s1),Is.EqualTo(s2));}
      
      [Test,Description("50 DECODE TESTS"),TestCaseSource("RandomTests2")]
      public static void RandomDecodeTesting(string s1,string s2){
        Assert.That(ISC.Decode(s2),Is.EqualTo(s1));}
    }
  }
}
