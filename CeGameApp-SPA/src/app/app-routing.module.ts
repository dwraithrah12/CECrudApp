import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { HomepageComponent } from './homepage/homepage.component';
import { GameinfopageComponent } from './gameinfopage/gameinfopage.component';
import { CompanyinfopageComponent } from './companyinfopage/companyinfopage.component';
import { RegistrationpageComponent } from './registrationpage/registrationpage.component';
import { UsersComponent } from './users/users.component';
import { UsereditComponent } from './users/useredit/useredit.component';
import { CharacterListComponent } from './users/character/character-list/character-list.component';
import { CharacterComponent } from './users/character/character.component';
import { SignInPageComponent } from './sign-in-page/sign-in-page.component';

const appRoutes: Routes = [
    { path: '', redirectTo: '/home', pathMatch: 'full' },
    { path: 'home', component: HomepageComponent },
    { path: 'gameinfo', component: GameinfopageComponent },
    { path: 'companyinfo', component: CompanyinfopageComponent },
    { path: 'registrationpage', component: RegistrationpageComponent },
    { path: 'signinpage', component: SignInPageComponent},
    { path: 'user/:id', component: UsersComponent },
    { path: 'user/:id/edit', component: UsereditComponent },
    { path: 'user/:id/character-list', component: CharacterListComponent },
    { path: 'user/:id/character-list/:cid', component: CharacterComponent },
    { path: '**', redirectTo: '/home' }
];

@NgModule({
    imports: [RouterModule.forRoot(appRoutes)],
    exports: [RouterModule]
})
export class AppRoutingModule{

}