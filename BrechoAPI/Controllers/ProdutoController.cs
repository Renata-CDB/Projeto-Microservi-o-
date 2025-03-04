﻿using BrechoModeloAplication.Dtos;
using BrechoModeloAplication.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace BrechoAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoAplicationService _produtoApplicationService;

        public ProdutosController(IProdutoAplicationService ApplicationServiceProduto)
        {
            _produtoApplicationService = ApplicationServiceProduto;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(_produtoApplicationService.GetAll());
        }

        // GET api/values/5\
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return Ok(_produtoApplicationService.GetById(id));
        }

        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody] ProdutoDTO produtoDTO)
        {
            try
            {
                //ProdutoInputDtoValidator validator = new ProdutoInputDtoValidator();
                //ValidatorResult result = validator.Validate(ProdutoDto);

                //if (result.IsValid == false)
                //return Ok(result.Errors);

                if (produtoDTO == null)
                    return NotFound();


                _produtoApplicationService.Add(produtoDTO);
                return Ok("O produto foi cadastrado com sucesso");
            }
            catch (Exception)
            {

                throw;
            }
        }

        // PUT api/values/5
        [HttpPut]
        public ActionResult Put([FromBody] ProdutoDTO produtoDTO)
        {

            try
            {
                if (produtoDTO == null)
                    return NotFound();

                _produtoApplicationService.Update(produtoDTO);
                return Ok("O produto foi atualizado com sucesso!");

            }
            catch (Exception)
            {

                throw;
            }
        }

        // DELETE api/values/5
        [HttpDelete()]
        public ActionResult Delete([FromBody] ProdutoDTO produtoDTO)
        {
            try
            {
                if (produtoDTO == null)
                    return NotFound();

                _produtoApplicationService.Remove(produtoDTO);
                return Ok("O produto foi removido com sucesso!");

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
