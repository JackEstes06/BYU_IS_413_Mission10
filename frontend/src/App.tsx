import './App.css';
import BowlerHeader from './BowlerHeader';
import BowlerList from './BowlerList';
import CookieConsent from 'react-cookie-consent';
import Fingerprint from './Fingerprint';

function App() {
  return (
    <>
      <BowlerHeader />
      <BowlerList />
      <CookieConsent>
        This website uses cookies to enhance the user experience.
      </CookieConsent>
      <Fingerprint />
    </>
  );
}

export default App;
