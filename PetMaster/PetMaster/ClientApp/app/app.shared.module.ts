import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';


import { AppComponent } from './components/app/app.component';
import { routing } from './app.routing';
import { PetMasterModule } from './components/pet-master/pet-master.module';
import { ErrorModule } from './components/error/error.module';

@NgModule({
    declarations: [
        AppComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        routing,
        PetMasterModule,
        ErrorModule
    ]
})
export class AppModuleShared {
}
