import type { LegalCase, CreateLegalCaseCommand, PaginationRequest } from '../types';

const API_BASE_URL = '/api/LegalCases';

export const apiService = {
    // Note: We pass the PaginationRequest object as a single parameter
    getLegalCases: async (request: PaginationRequest): Promise<LegalCase[]> => {
        const response = await fetch(`${API_BASE_URL}?PageNumber=${request.pageNumber}&PageSize=${request.pageSize}`);
        if (!response.ok) throw new Error('Failed to fetch legal cases');
        return response.json();
    },

    createLegalCase: async (command: CreateLegalCaseCommand): Promise<string> => {
        const response = await fetch(API_BASE_URL, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(command),
        });
        if (!response.ok) throw new Error('Failed to create legal case');
        const data = await response.json();
        return data.id; // Returns the new Guid
    },

    // Manual report triggers preserved for the UI
    downloadExcelReport: (): void => {
        window.open(`${API_BASE_URL}/reports/excel`, '_blank');
    },

    downloadPdfReport: (): void => {
        window.open(`${API_BASE_URL}/reports/pdf`, '_blank');
    }
};