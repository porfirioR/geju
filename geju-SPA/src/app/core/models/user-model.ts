import { Country } from '../constant/enum';

export class UserModel {
    id: string;
    nombre: string;
    apellido: string;
    correo: string;
    activo: boolean;
    fechaNacimiento: Date;
    fechaCreado: Date;
    LastActive: Date;
    pais: Country;
    deuda: boolean;
}
