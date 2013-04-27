#region License
//         DO WHAT THE FUCK YOU WANT TO PUBLIC LICENSE
//                Version 2, December 2004
//  
// Copyright (C) 2013 Phito <phito41@gmail.com>
//  
// Everyone is permitted to copy and distribute verbatim or modified
// copies of this license document, and changing it is allowed as long
// as the name is changed.
//  
//         DO WHAT THE FUCK YOU WANT TO PUBLIC LICENSE
// TERMS AND CONDITIONS FOR COPYING, DISTRIBUTION AND MODIFICATION
//  
// 0. You just DO WHAT THE FUCK YOU WANT TO.
// 
// Created on 24/04/2013 at 20:22
#endregion

using System.IO;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Encodings;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.OpenSsl;

namespace Emulator.Common.Cryptography
{
    public class RSA
    {
        // Yay! Harcoded stuff :D
        public const string PRIVATE_KEY = "-----BEGIN RSA PRIVATE KEY-----\nMIICXgIBAAKBgQDl3CLDlAZLDMoKwh7fNwvzCilu9AnyVvXZrmkZflT9DhrG0kI1LAvKti+yzoENchjONduDGwexQW7mKjcCdPwD1nW9EqdoKjd5jxcHConfRMW3l2uF7i1s5GKTDplCbEyxgP1StOH2OuJ6U+6vF8zpbSPl+zEasJ+eSayQkCF2VQIDAQABAoGAQc0P4p8YYhmqKQRDJDE06YFKNSoFQuuj+4nTKmog2ERWY/5C18fhJEmdQ/mbtgaolTeTvGdbf2G05ozFLJ3imoeqD1Hhh7OUTVT+bfD3T0Cm88Vb5AnPjJPwGDy3D5HrU8W4eL7Hqb3PrnZMWv0olIEUA6+ALbOaCkXNs4YGMI0CQQD7uzKqpmD94nzhER5+0h/TgkUkXpNp04VColZIbqCBC4J/BA6jrw1FnNCVxS1tgJp4gaiXc+G7a2jMPLW+sw/LAkEA6cH9wEOYexRBOtibVcm6uL+gnvdCbZiugX9ybhvyPFKq4RzHP/uuI+f09MXyPu3KtbHFeygJDVUYjOW+9USOXwJBALScOh0AJMTjtG+S5cteHWGWrN8MUD30ej811CxB2zzbMjTJh2tfVGlmuq1KfG59f9cISBrqFMJwrQ8kW83IEYMCQQDpmObPv70dIfydpeB1NobWIQmOUmGbzDx3RLlBt8O27JW/KFclZYl8cEymXznaER/FusUycau6GxPRmbXevIfZAkEAnOgYokEBdkb+sHry4FpNF6+W9N2A81ck2OtH1PI6JfZwRYmkEd299kodViWguaSYHaVkRHLAGKFQxFakEdC/NA==\n-----END RSA PRIVATE KEY-----";
    
        public static byte[] Decrypt(byte[] buffer)
        {
            using (TextReader sr = new StringReader(PRIVATE_KEY))
            {
                PemReader pemReader = new PemReader(sr);
                AsymmetricCipherKeyPair keyPair = (AsymmetricCipherKeyPair)pemReader.ReadObject();
                RsaKeyParameters privateKey = (RsaKeyParameters)keyPair.Private;
                IAsymmetricBlockCipher cipher = new Pkcs1Encoding(new RsaEngine());

                cipher.Init(false, privateKey);
                return cipher.ProcessBlock(buffer, 0, buffer.Length);
            } 
        }
    }
}
