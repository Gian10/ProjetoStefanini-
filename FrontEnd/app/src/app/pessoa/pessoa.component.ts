import { Component, OnInit } from '@angular/core';
import {Pessoa} from '../models/pessoa'
import { ActivatedRoute } from '@angular/router'
import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';
import { PessoaService } from '../services/pessoa.service';
import { CidadeService } from '../services/cidade.service';
import { Cidade } from '../models/cidade';

@Component({
  selector: 'app-pessoa',
  templateUrl: './pessoa.component.html',
  styleUrls: ['./pessoa.component.css'],
  providers: [PessoaService, CidadeService]
})
export class PessoaComponent implements OnInit {

  public pessoaForm: FormGroup;
  title = 'PESSOAS';
  public pessoa : Pessoa;
  public pessoaList : Pessoa [];
  public cidadeList : Cidade [];
  public pessoaSelecionada : Pessoa;
  public modo = '';
  public nomeCidade : string ;
  public selectCidadeId : number;

  constructor(private pessoaService : PessoaService, private cidadeService : CidadeService, 
    private fb: FormBuilder) 
  { this.criarForm(); } 


  ngOnInit(): void {
    this.listPessoas();
    this.listCidades();
  }

  listPessoas(){
    this.pessoaService.get().subscribe(
      (pessoas : Pessoa[]) => {
        this.pessoaList = pessoas;
      },
      (erro: any) => {
        console.log(erro);
      });
  }


  listCidades(){
    this.cidadeService.get().subscribe(
      (cidades : Cidade[]) => {
        this.cidadeList = cidades;
      },
      (erro: any) => {
        console.log(erro);
      });
  }

  voltar(){
    this.refreshPage();
    this.pessoaSelecionada = null; 
  }

  public refreshPage() {
    location.reload()
  }


  criarForm(){
    this.pessoaForm = this.fb.group({
      pessoaId: [''],
      nome: [''],
      cpf: [''],
      idade: [''],
      cidadeId: ['']
    });

  }


  pessoaSubmit(){
    (this.pessoaForm.value.pessoaId === 0) ? this.modo = 'post' : this.modo = 'put';

    this.pessoaForm.controls['cidadeId'].setValue(this.selectCidadeId);
      this.pessoaService[this.modo](this.pessoaForm.value).subscribe(
        (result : Pessoa) =>{
         this.voltar();
        },
        (erro: any) => {
          console.log(erro);
        });
  }


  public async deletePessoa(id : number){
    await this.pessoaService.delete(id).subscribe(
      (int : number)=>{
        this.voltar();
      },
      (erro: any) => {
        console.log(erro);
      });   
  }


  cadastroPessoa(){
    this.pessoaSelecionada = new Pessoa(); 
    this.pessoaForm.patchValue( this.pessoaSelecionada);
  }

  pessoaSelect(pessoa : Pessoa){

    this.cidadeService.getId(pessoa.cidadeId).subscribe(
      (cidade : Cidade) =>{
        this.nomeCidade = cidade.nome;
      }
    )
    this.pessoaSelecionada = pessoa;  
    this.pessoaForm.patchValue(pessoa);
  }

  changeCidade(e){
    this.selectCidadeId = e.target.value
  }

}
