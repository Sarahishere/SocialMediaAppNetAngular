import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanDeactivate, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { MemberEditComponent } from '../members/member-edit/member-edit.component';

@Injectable({
  providedIn: 'root'
})
export class PreventUnsavedChangesGuard {
  canDeactivate(
    component: MemberEditComponent):  boolean  {
    if (component.editForm?.dirty) {
      return confirm('Any unsaved changes will be lost!');
    }
    return true;
  }
  
}
