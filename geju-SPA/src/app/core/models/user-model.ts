import { Country } from '../constant/enum';

export class UserModel {
    id: string;
    name: string;
    lastName: string;
    email: string;
    active: boolean;
    birthdate: Date;
    creationDate: Date;
    lastActive: Date;
    country: Country;
}
