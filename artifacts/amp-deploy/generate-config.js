const fs = require('fs');
const path = require('path');

// Compute XOR'd attestation secret (matches AdminAuthClient.GetAttestationSecret())
const parts = 'f0e1d2c3b4a596871928374655647382aabbccddeeff00119988776655443322';
let secret = '';
for (const c of parts) secret += String.fromCharCode(c.charCodeAt(0) ^ 75);

// Write appsettings.json
fs.writeFileSync(path.join(__dirname, 'appsettings.json'), JSON.stringify({
  Logging: { LogLevel: { Default: 'Warning', 'BapCustomServer': 'Information' } },
  CustomServer: {
    PublicBaseUrl: 'http://ark.atomi23.de:5055',
    Admin: {
      ApiToken: 'bapbap-admin-token-2024',
      AllowLoopbackAdminWithoutToken: false,
      AdminAccountIds: ['custom-1001', 'custom-382jfI238ALO'],
      AdminAccountIdsCsv: 'custom-1001,custom-382jfI238ALO',
      AttestationSecret: secret
    }
  }
}, null, 2));

// Write startup script
const scriptLines = [
  '#!/bin/sh',
  'set -eu',
  'ROOT=$(CDPATH= cd -- "$(dirname -- "$0")" && pwd)',
  'cd "$ROOT"',
  'LISTEN_URL="${1:-${ASPNETCORE_URLS:-http://0.0.0.0:5055}}"',
  'export ASPNETCORE_URLS="${ASPNETCORE_URLS:-$LISTEN_URL}"',
  'export CustomServer__Admin__ApiToken="bapbap-admin-token-2024"',
  'export CustomServer__Admin__AdminAccountIdsCsv="custom-1001,custom-382jfI238ALO"',
  'export CustomServer__Admin__AttestationSecret="$(echo LXsuei95KHgpfyp+cn1zfHpyeXN4fH99fn59f3x4c3kqKikpKCgvLy4uLS17e3p6cnJzc3x8fX1+fn9/eHh5eQ== | base64 -d)"',
  'exec ./BapCustomServer --urls "$LISTEN_URL"',
  ''
];
fs.writeFileSync(path.join(__dirname, 'amp-webpanel-start.sh'), scriptLines.join('\n'));

const s1 = fs.statSync(path.join(__dirname, 'appsettings.json'));
const s2 = fs.statSync(path.join(__dirname, 'amp-webpanel-start.sh'));
console.log('appsettings.json: ' + s1.size + ' bytes');
console.log('amp-webpanel-start.sh: ' + s2.size + ' bytes');
console.log('AttestationSecret length: ' + secret.length);
console.log('Admin IDs: custom-1001, custom-382jfI238ALO');
