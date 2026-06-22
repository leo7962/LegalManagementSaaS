import { useState } from 'react';
import LegalCaseForm from './components/LegalCaseForm';
import LegalCaseList from './components/LegalCaseList';

function App() {
    const [refreshTrigger, setRefreshTrigger] = useState(0);

    const handleCaseCreated = () => {
        setRefreshTrigger(prev => prev + 1);
    };

    return (
        <div style={{ padding: '2rem', fontFamily: 'system-ui, sans-serif', maxWidth: '1000px', margin: '0 auto' }}>
            <h1>Legal Management SaaS (MVP)</h1>
            <hr style={{ marginBottom: '2rem' }} />

            <LegalCaseForm onCaseCreated={handleCaseCreated} />
            <LegalCaseList refreshTrigger={refreshTrigger} />
        </div>
    );
}

export default App;