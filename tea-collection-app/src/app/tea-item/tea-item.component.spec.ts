import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TeaItemComponent } from './tea-item.component';

describe('TeaItemComponent', () => {
  let component: TeaItemComponent;
  let fixture: ComponentFixture<TeaItemComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TeaItemComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TeaItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
