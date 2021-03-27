import { Country } from '../enums/country.enum';

export class UserModel {
    id: string;
    name: string;
    lastName: string;
    email: string;
    document: string;
    country: Country;
    birthdate: Date;
    creationDate: Date;
    lastActive: Date;
    active: boolean;
}
