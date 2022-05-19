import { Component, OnDestroy, OnInit } from '@angular/core';
import {Cidade} from '../models/cidade'
import {CidadeService} from '../services//cidade.service'
import { ActivatedRoute } from '@angular/router'
import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';

@Component({
  selector: 'app-cidade',
  templateUrl: './cidade.component.html',
  styleUrls: ['./cidade.component.css'],
  providers: [CidadeService]
})
export class CidadeComponent implements OnInit {

  public cidadeForm: FormGroup;

  title = 'CIDADES';
  public cidade : Cidade;
  public cidadesList : Cidade [] = []
  public cidadeSelecionada : Cidade;
  public modo = '';

  constructor(private cidadeService : CidadeService, private fb: FormBuilder) 
  { this.criarForm(); }

  ngOnInit(): void {
    this.listCidades();
  }

  criarForm(){
    this.cidadeForm = this.fb.group({
      cidadeId: [''],
      nome: [''],
      uf: ['']
    });

  }
  

  cidadeSelect(cidade : Cidade){
    this.cidadeSelecionada = cidade;
    this.cidadeForm.patchValue(cidade);
  }

  cadastroCidade(){
    this.cidadeSelecionada = new Cidade(); 
    this.cidadeForm.patchValue( this.cidadeSelecionada);
  }

  voltar(){
    this.refreshPage();
    this.cidadeSelecionada = null; 
  }

  listCidades(){
    this.cidadeService.get().subscribe(
      (cidades : Cidade[]) => {
        this.cidadesList = cidades;
      },
      (erro: any) => {
        console.log(erro);
      });
  }


  public async deleteCidade(id : number){
      await this.cidadeService.delete(id).subscribe(
        (int : number)=>{
          this.voltar();
        },
        (erro: any) => {
          console.log(erro);
        });   
  }

  cidadeSubmit(){
    (this.cidadeForm.value.cidadeId === 0) ? this.modo = 'post' : this.modo = 'put';
      this.cidadeService[this.modo](this.cidadeForm.value).subscribe(
        (result : Cidade) =>{
         this.voltar();
        },
        (erro: any) => {
          console.log(erro);
        });
  }

  public refreshPage() {
    location.reload()
  }



}
