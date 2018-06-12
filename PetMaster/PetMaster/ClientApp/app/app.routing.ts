import { PetMasterComponent } from './components/pet-master/pet-master.component';
import { ErrorComponent } from './components/error/error.component';
import { Routes, RouterModule } from '@angular/router';
import { ModuleWithProviders } from '@angular/core';

const routes: Routes = [
    { path: '', redirectTo: 'pet-master', pathMatch: 'full' },
    { path: 'error', component: ErrorComponent },
    { path: 'pet-master', component: PetMasterComponent }
];



export const routing: ModuleWithProviders = RouterModule.forRoot(routes);