import { Country } from '../constant/enum';

export class UserModel {
    id: string;
    name: string;
    lastName: string;
    email: string;
    active: boolean;
    dateOfBirth: Date;
    Created: Date;
    LastActive: Date;
    country: Country;
}
