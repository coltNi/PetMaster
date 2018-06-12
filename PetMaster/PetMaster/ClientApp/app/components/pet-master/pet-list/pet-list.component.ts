import { Component } from '@angular/core';
import { PetByMasterGender } from '../model/pet-by-master-gender';
import { PetMasterService } from '../pet-master.service';

import { componentDestroyed } from 'ng2-rx-componentdestroyed';
import 'rxjs/add/operator/takeUntil';

@Component({
    selector: 'pet-list',
    templateUrl: './pet-list.component.html'
})
export class PetListComponent {
    petLists: PetByMasterGender[] = [];

    constructor(private _petMasterService: PetMasterService) { }

    getPetsGroupByMasterGenderByType(type:string) {
        this._petMasterService.getPetByTypeGroupByMasterGender(type).takeUntil(componentDestroyed(this))
            .subscribe(petByMasterGender => {
                this.petLists = petByMasterGender;
            });
       
    }
    ngOnDestroy() {
        //this is required by ng2-rx-componentdestroyed
    }
}
