import { AbstractControl, ValidatorFn, ValidationErrors, FormGroup } from "@angular/forms";

export const samePasswordValidator = (form: FormGroup): ValidatorFn => {
    return (control: AbstractControl) : ValidationErrors | null => {
        if (control.value !== form.controls['password'].value){
            return { differentPassword: true};
        }
        return null;
    }
}