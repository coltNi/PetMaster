import { NgModule, ErrorHandler } from '@angular/core';
import { CommonModule } from '@angular/common';

import { routing } from '../../app.routing';
import { HttpModule, JsonpModule } from '@angular/http';
import { FormsModule } from '@angular/forms';

import { PetMasterComponent } from './pet-master.component';
import { PetTypesComponent } from './pet-types/pet-types.component';
import { PetListComponent } from './pet-list/pet-list.component';
import { PetMasterService } from './pet-master.service';

import { GlobalErrorHandler } from '../shared/global-error-handler';

@NgModule({
    declarations: [
        PetMasterComponent, PetTypesComponent, PetListComponent
    ],
    imports: [routing, HttpModule, JsonpModule, CommonModule, FormsModule],
    providers: [PetMasterService, {
        provide: ErrorHandler,
        useClass: GlobalErrorHandler
    }],
    exports: [PetMasterComponent]
})

export class PetMasterModule { }