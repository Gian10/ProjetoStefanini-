import {NgModule} from '@angular/core';
import {Routes, RouterModule} from '@angular/router';
import { CidadeComponent } from './cidade/cidade.component';
import { InicioComponent } from './inicio/inicio.component';
import { PessoaComponent } from './pessoa/pessoa.component';

export const routes : Routes = [
    {path: '', component: InicioComponent},
    {path: 'cidade', component: CidadeComponent},
    {path: 'pessoa', component: PessoaComponent}
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})

export class AppRoutingModule{}