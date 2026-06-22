import { useState, FormEvent } from 'react';
import type { CreateLegalCaseCommand } from '../types';
import { apiService } from '../services/apiService';

interface Props {
    onCaseCreated: () => void;
}

export default function LegalCaseForm({ onCaseCreated }: Props) {
    const [formData, setFormData] = useState<CreateLegalCaseCommand>({
        title: '',
        description: '',
        clientName: ''
    });

    const handleSubmit = async (e: FormEvent) => {
        e.preventDefault();
        try {
            await apiService.createLegalCase(formData);
            setFormData({ title: '', description: '', clientName: '' }); // Reset form
            onCaseCreated(); // Refresh list
        } catch (error) {
            console.error(error);
            alert('Error creating case');
        }
    };

    return (
        <div style={{ marginBottom: '2rem', padding: '1rem', border: '1px solid #ccc', borderRadius: '8px' }}>
            <h2>Create New Legal Case</h2>
            <form onSubmit={handleSubmit} style={{ display: 'flex', flexDirection: 'column', gap: '1rem', maxWidth: '400px' }}>
                <input
                    type="text"
                    placeholder="Case Title"
                    value={formData.title}
                    onChange={(e) => setFormData({ ...formData, title: e.target.value })}
                    required
                />
                <input
                    type="text"
                    placeholder="Client Name"
                    value={formData.clientName}
                    onChange={(e) => setFormData({ ...formData, clientName: e.target.value })}
                    required
                />
                <textarea
                    placeholder="Description"
                    value={formData.description}
                    onChange={(e) => setFormData({ ...formData, description: e.target.value })}
                />
                <button type="submit" style={{ padding: '0.5rem', cursor: 'pointer' }}>Save Case</button>
            </form>
        </div>
    );
}