import { UserModel } from '../user-model';

export class UserAuthResponse {
    token: string;
    user: UserModel;
}
