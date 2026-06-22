import { useEffect, useState } from 'react';
import type { LegalCase } from '../types';
import { apiService } from '../services/apiService';

interface Props {
    refreshTrigger: number;
}

export default function LegalCaseList({ refreshTrigger }: Props) {
    const [cases, setCases] = useState<LegalCase[]>([]);
    const [loading, setLoading] = useState<boolean>(true);

    useEffect(() => {
        const fetchCases = async () => {
            setLoading(true);
            try {
                // Fetching page 1, 10 items for the MVP
                const data = await apiService.getLegalCases({ pageNumber: 1, pageSize: 10 });
                setCases(data);
            } catch (error) {
                console.error(error);
            } finally {
                setLoading(false);
            }
        };

        fetchCases();
    }, [refreshTrigger]);

    if (loading) return <p>Loading cases...</p>;

    return (
        <div>
            <div style={{ display: 'flex', justifyContent: 'space-between', alignItems: 'center' }}>
                <h2>Active Legal Cases</h2>
                <div>
                    <button onClick={apiService.downloadExcelReport} style={{ marginRight: '0.5rem' }}>Export Excel</button>
                    <button onClick={apiService.downloadPdfReport}>Export PDF</button>
                </div>
            </div>

            {cases.length === 0 ? (
                <p>No cases found.</p>
            ) : (
                <table style={{ width: '100%', borderCollapse: 'collapse', marginTop: '1rem' }}>
                    <thead>
                        <tr style={{ borderBottom: '2px solid #ccc', textAlign: 'left' }}>
                            <th>Title</th>
                            <th>Client</th>
                            <th>Status</th>
                            <th>Description</th>
                        </tr>
                    </thead>
                    <tbody>
                        {cases.map((c) => (
                            <tr key={c.id} style={{ borderBottom: '1px solid #eee' }}>
                                <td style={{ padding: '0.5rem 0' }}>{c.title}</td>
                                <td>{c.clientName}</td>
                                <td><strong style={{ color: c.status === 'Open' ? 'green' : 'gray' }}>{c.status}</strong></td>
                                <td>{c.description}</td>
                            </tr>
                        ))}
                    </tbody>
                </table>
            )}
        </div>
    );
}