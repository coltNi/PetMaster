import { Component, Output, EventEmitter } from '@angular/core';

@Component({
    selector: 'pet-types',
    templateUrl: './pet-types.component.html'
})
export class PetTypesComponent {
    petTypes: string[] = [];
    selectedPetType: string = "";

    @Output() petTypeSelected = new EventEmitter<string>();

    ngOnInit() {
        this.selectedPetType = "Cat";
        this.petTypeSelected.emit(this.selectedPetType);
    }

}
