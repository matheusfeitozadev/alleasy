import { MatDialog } from '@angular/material/dialog';
import { enumAction } from './../../interfaces/action-model';
import { CategoriaService } from './../../services/categoria-service.service';
import { CategoriaModel } from './../../interfaces/categoria-model';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ConfirmDialogComponent, DialogData } from '../confirm-dialog/confirm-dialog.component';
import { FormBuilder, FormControl, FormControlName, FormGroup, Validators } from '@angular/forms';


@Component({
  selector: 'app-categoria',
  templateUrl: './categoria.component.html',
  styleUrls: ['./categoria.component.css']
})
export class CategoriaComponent implements OnInit {

  categorias : CategoriaModel[] = [];
  registerForm: FormGroup;
  submitted = false;
  actionAtual : enumAction;

  isList : boolean = false;
  isAdd : boolean = false;
  isEdit : boolean = false;
  textHead : string = "";


  categoria : CategoriaModel = {
    IdCategoria : 0,
    Descricao : "",
    Ativo : true
  };

  displayedColumns: string[] = ['id', 'descricao', 'ativo', 'edit', 'delete'];

  constructor(
    private categoriaService : CategoriaService,
    private router : Router, 
    private dialog : MatDialog,
    private formBuilder: FormBuilder
    ) { 
      this.createFormGroup();
    
  }

  ngOnInit(): void {
    this.setActionPage(enumAction.list);
  }

  setTitlePage(action : enumAction){
    if(action == enumAction.list)
    {
        this.textHead = 'Categorias';
    }
    else{
      if(action == enumAction.add)
      {
          this.textHead = 'Adicionar Nova Categoria';
      }
      else{
        if(action == enumAction.edit)
        {
            this.textHead = 'Editar Categoria';
        }
      }
    }
  }

  createFormGroup()
  {
    this.registerForm = this.formBuilder.group({
        descricao: new FormControl(this.categoria.Descricao, [Validators.required])
    });
  }

  get f() { return this.registerForm.controls; }

  listAllProdutos() {
    this.categoriaService.getAll().subscribe(
      data => {
        this.categorias = data;
      },
      error => {
        console.log(error);
      }
    )
  }

  addOrEdit()
  {
    if (this.registerForm.invalid) {
        return;
    }

    this.categoria.Descricao = this.registerForm.get('descricao')?.value;

    if(this.isAdd)
    {
        this.categoriaService.add(this.categoria).subscribe(
          (data)=>{
            this.clearProduto();
            this.goBack();
          },
          error => {
            console.log(error);
          }
        )
    }
    else{
      this.categoriaService.update(this.categoria).subscribe(
        (data)=>{
          this.clearProduto();
          this.goBack();
        },
        error => {
          console.log(error);
        }
      )
    }
  }

  goBack()
  {
    this.setActionPage(enumAction.list);
  }

  //function to show div add product
  goToAddNew() {
    this.clearProduto();
    this.setActionPage(enumAction.add);
  }

  //function to show div edit product and fill the fields
  goToEdit(categoria : CategoriaModel)
  {
    this.categoria = categoria;
    this.createFormGroup();
    this.setActionPage(enumAction.edit);
  }

  askDelete(categoria : CategoriaModel)
  {
    const dialogRef = this.dialog.open(ConfirmDialogComponent, {
      maxWidth: "400px",
      data: {
          title: "Deseja deletar?",
          message: "Você irá deletar essa categoria"}
    });
  
    dialogRef.afterClosed().subscribe(dialogResult => {
      if(dialogResult)
      {
        this.categoriaService.delete(categoria.IdCategoria).subscribe(
          data =>{
            this.clearProduto();
            this.goBack();
          },
          error =>{
            console.log(error);
          }
        )
      }
   });
  }

  setActionPage(action : enumAction)
  {
    this.setTitlePage(action);

    if(action == enumAction.add)
    {
        this.isList = false;
        this.isAdd = true;
        this.isEdit = false;
    }
    else{
      if(action == enumAction.edit)
      {
          this.isList = false;
          this.isAdd = false;
          this.isEdit = true;
      }
      else{
        if(action == enumAction.list)
        {
            this.listAllProdutos();
            this.isList = true;
            this.isAdd = false;
            this.isEdit = false;
        }
      }
    }
  }

  clearProduto()
  {
      this.categoria.IdCategoria = 0;
      this.categoria.Descricao = "";
      this.categoria.Ativo = true;
  }
}
