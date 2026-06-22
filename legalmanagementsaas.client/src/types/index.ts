export interface PaginationRequest {
    pageNumber: number;
    pageSize: number;
}

export interface LegalCase {
    id: string;
    title: string;
    description: string;
    clientName: string;
    status: string;
}

export interface CreateLegalCaseCommand {
    title: string;
    description: string;
    clientName: string;
}