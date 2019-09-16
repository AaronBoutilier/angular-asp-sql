import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TeaListComponent } from './tea-list.component';

describe('TeaListComponent', () => {
  let component: TeaListComponent;
  let fixture: ComponentFixture<TeaListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TeaListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TeaListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
