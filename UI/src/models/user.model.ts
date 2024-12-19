export interface User {
    id: number;
    name: string;
    surname: string;
    phone: string;
    email: string | null;
    password: string;
    birthDate: Date;
    isAdmin: boolean;
}
