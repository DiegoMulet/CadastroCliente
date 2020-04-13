import { Endereco } from './Endereco';
import { Telefone } from './Telefone';

export class Cliente {
    clienteId: string;
    nome: string;
    documento: number;
    dataNascimento: Date;
    genero: string;
    endereco: Endereco;
    telefone: Telefone;
}
