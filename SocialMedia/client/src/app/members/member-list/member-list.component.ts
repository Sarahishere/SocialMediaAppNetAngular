import { Component, Input, OnInit } from '@angular/core';
import { Observable, of } from 'rxjs';
import { Member } from 'src/app/_models/member';
import { MembersService } from 'src/app/_services/members.service';

@Component({
  selector: 'app-member-list',
  templateUrl: './member-list.component.html',
  styleUrls: ['./member-list.component.css']
})
export class MemberListComponent implements OnInit {
  members$: Observable<Member[]> | undefined;

  constructor(private memberService: MembersService){}
  
  ngOnInit(): void {
    this.members$ = this.memberService.getMembers();
  }

}
