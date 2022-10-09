import { Component, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.service';
@Component({
  selector: 'app-show-dep',
  templateUrl: './show-dep.component.html',
  styleUrls: ['./show-dep.component.css'],
})
export class ShowDepComponent implements OnInit {
  constructor(private service: SharedService) { }

  DepartmentList: any = [];

  ModalTitle: string = "abc";
  ActivateAddEditDepCamp: boolean = false;
  dep: any;

  ngOnInit(): void {
    this.refreshDepList()
  }
  addClick() {
    this.dep = {
      DepartmentId: 0,
      DepartmentName: ""
    }
    this.ModalTitle = "Add Department";
    this.ActivateAddEditDepCamp = true;
  }
  closeClick() {
    this.ActivateAddEditDepCamp = false;
    this.refreshDepList();
  }
  editClick(dataItem: any) {
    this.dep = dataItem;
    this.ModalTitle = "Edit Department";
    this.ActivateAddEditDepCamp = true;
  }
  refreshDepList() {
    this.service.getDepList().subscribe((data) => {
      this.DepartmentList = data
    });
  }
}
