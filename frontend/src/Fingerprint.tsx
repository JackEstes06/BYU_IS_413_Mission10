import { getFingerprint } from '@thumbmarkjs/thumbmarkjs';
import { useEffect, useState } from 'react';

function Fingerprint() {
  const [fingerprint, setFingerprint] = useState<string | null>(null);

  useEffect(() => {
    getFingerprint().then((fingerprint) => setFingerprint(fingerprint));
  });

  return <>Fingerprint Hash (414 Lab Req): {fingerprint}</>;
}

export default Fingerprint;
