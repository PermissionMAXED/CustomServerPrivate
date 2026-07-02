using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

// Args: <aesKeyBase64> <blobBase64>
// Reads the AES key (32 bytes) and the encrypted blob in Chromium "v20" format,
// decrypts with AES-256-GCM, writes plaintext to stdout.

var aesKey = Convert.FromBase64String(args[0]);
var blob   = Convert.FromBase64String(args[1]);

// Parse Chromium v20 blob:
//   [0..2]   "v20"
//   [3]      nonce length
//   [4..3+nonceLen]  nonce
//   [...blob.Length-17]   ciphertext
//   [blob.Length-16..]    tag (16 bytes)
var version = Encoding.ASCII.GetString(blob, 0, 3);
var nonceLen = (int)blob[3];
var nonce = new byte[nonceLen];
Array.Copy(blob, 4, nonce, 0, nonceLen);
var tag = new byte[16];
Array.Copy(blob, blob.Length - 16, tag, 0, 16);
var ctLen = blob.Length - 4 - nonceLen - 16;
var ct = new byte[ctLen];
Array.Copy(blob, 4 + nonceLen, ct, 0, ctLen);

using var aesGcm = new AesGcm(aesKey);
var plaintext = new byte[ctLen];
aesGcm.Decrypt(nonce, ct, tag, plaintext);
var password = Encoding.UTF8.GetString(plaintext).TrimEnd('\0');
Console.Write(password);
