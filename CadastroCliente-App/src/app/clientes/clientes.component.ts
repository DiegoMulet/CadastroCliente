import { Component, OnInit } from '@angular/core';
import { Cliente } from '../_models/Cliente';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { ClienteService } from '../_services/cliente.service';


@Component({
  selector: 'app-clientes',
  templateUrl: './clientes.component.html',
  styleUrls: ['./clientes.component.css']
})
export class ClientesComponent implements OnInit {

  clientes: Cliente[];
  cliente: Cliente;
  modoSalvar = 'post';
  bodyDeletarCliente: string;
  registerForm: FormGroup;
  FiltroLista: string;
  titulo = 'Clientes';
  constructor(
    private clienteService: ClienteService
  , private fb: FormBuilder
  , private toastr: ToastrService
  ) { }

  ngOnInit() {
    this.validation();
    this.getClientes();
  }

  validation() {
    this.registerForm = this.fb.group({
      clienteId: [''],
      nome: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(50)]],
      documento: ['', [Validators.required, Validators.minLength(5), Validators.maxLength(11)]],
      genero: ['', [Validators.required]],
      dataNascimento: ['', [Validators.required]]
    });
  }

  novoCliente(template: any) {
    this.modoSalvar = 'post';
    this.openModal(template);
  }

  editarCliente(cliente: Cliente, template: any) {
    this.modoSalvar = 'put';
    this.openModal(template);
    this.cliente = Object.assign({}, cliente);
    this.registerForm.patchValue(this.cliente);
  }

  excluirCliente(cliente: Cliente, template: any) {
    this.openModal(template);
    this.cliente = cliente;
    this.bodyDeletarCliente = `Tem certeza que deseja excluir o Cliente: ${cliente.nome}?`;
  }

  confirmeDelete(template: any) {
    this.clienteService.deleteCliente(this.cliente.clienteId).subscribe(
      () => {
          template.hide();
          this.getClientes();
          this.toastr.success('Cliente deletado com sucesso.');
        }, error => {
          this.toastr.error(error, 'Falha ao deletar cliente');
        }
    );
  }

  openModal(template: any) {
    this.registerForm.reset();
    template.show();
  }

  salvarAlteracao(template: any) {
    if (this.registerForm.valid) {
      if (this.modoSalvar === 'post') {
        this.cliente = Object.assign({}, this.registerForm.value);

        this.clienteService.postCliente(this.cliente).subscribe(
          (novoCliente: Cliente) => {
            template.hide();
            this.getClientes();
            this.toastr.success('Cliente criado com sucesso.');
          }, error => {
            this.toastr.error(error, 'Falha ao criar cliente');
          }
        );
      } else {
        this.cliente = Object.assign({Id: this.cliente.clienteId}, this.registerForm.value);

        this.clienteService.putCliente(this.cliente).subscribe(
          (novoCliente: Cliente) => {
            template.hide();
            this.getClientes();
            this.toastr.success('Cliente editado com sucesso.');
          }, error => {
            this.toastr.error(error, 'Falha ao editar cliente');
          }
        );
      }
    }
  }

  getClientes() {
    this.clienteService.getAllCliente().subscribe(
      (clientes: Cliente[]) => {
        this.clientes = clientes;
      },
      error => { console.log(error); }
      );
    }
}


