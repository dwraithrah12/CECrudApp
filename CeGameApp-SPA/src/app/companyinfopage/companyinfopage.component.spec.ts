import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CompanyinfopageComponent } from './companyinfopage.component';

describe('CompanyinfopageComponent', () => {
  let component: CompanyinfopageComponent;
  let fixture: ComponentFixture<CompanyinfopageComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CompanyinfopageComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CompanyinfopageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
