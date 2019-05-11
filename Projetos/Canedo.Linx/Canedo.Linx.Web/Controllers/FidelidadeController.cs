using Canedo.Linx.Fidelidade.ApiService.Service;
using Canedo.Linx.Fidelidade.Data.Repository.Dapper;
using Canedo.Linx.Fidelidade.Data.Repository.EntityFramework;
using Canedo.Linx.Fidelidade.Domain.Entity;
using Canedo.Linx.Fidelidade.Domain.Model;
using Canedo.Linx.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Canedo.Linx.Web.Controllers
{
    public class FidelidadeController : Controller
    {
        readonly ConsultarFidelizacaoService consultarFidelizacaoService_;
        readonly IntegracaoDapperRepository integracaoRepository_;
        readonly FidelizacaoDapperRepository fidelizacaoRepository_;
        readonly FidelizacaoEfRepository fidelizacaoEfRepository_;
        readonly IntegracaoEfRepository integracaoEfRepository_;

        public FidelidadeController(
            ConsultarFidelizacaoService consultarFidelizacaoService, 
            IntegracaoDapperRepository integracaoRepository,
            FidelizacaoDapperRepository fidelizacaoRepository,
            FidelizacaoEfRepository fidelizacaoEfRepository,
            IntegracaoEfRepository integracaoEfRepository)
        {
            consultarFidelizacaoService_ = consultarFidelizacaoService;
            integracaoRepository_ = integracaoRepository;
            fidelizacaoRepository_ = fidelizacaoRepository;
            fidelizacaoEfRepository_ = fidelizacaoEfRepository;
            integracaoEfRepository_ = integracaoEfRepository;
        }

        // GET: Fidelidade
        public ActionResult Index()
        {
            var integracao = integracaoRepository_.GetAll().FirstOrDefault();

            

            var model = new IndexViewModel()
            {
                Integracao = integracao
            };

            return View(model);
        }
        [HttpPost]
        public ActionResult Index(IndexViewModel indexViewModel)
        {
            var model = new ConsultaFidelizacaoBody()
            {
                NsuCliente = Guid.NewGuid().ToString(),
                ChaveIntegracao = indexViewModel.Integracao.ChaveIntegracao,
                CodigoLoja = indexViewModel.Integracao.CodigoLoja,
                NumeroCartao = indexViewModel.NumeroCartao,
                CodigoSeguranca = ""
            };

            var result = consultarFidelizacaoService_.GetConsultaFidelizacao(model);

            if (result != null)
            {
                var fidelizacao = new Fidelizacao()
                {
                    NsuCliente = new Guid(result.NsuCliente),
                    Resultado = result.Resultado,
                    SaldoEmPontos = Convert.ToInt64(result.SaldoEmPontos),
                    SaldoEmReais = Convert.ToDecimal(result.SaldoEmReais.Replace(',', '.')),
                    SaldoPontos = Convert.ToInt64(result.SaldoPontos)
                };

                fidelizacaoEfRepository_.Add(fidelizacao);

                indexViewModel.Fidelizacoes = fidelizacaoRepository_.GetAll();
            }

            UpdateIntegracao(indexViewModel);

            

            return View(indexViewModel);
        }

        private void UpdateIntegracao(IndexViewModel indexViewModel)
        {
            var dataBd = integracaoRepository_.GetById(indexViewModel.Integracao.Id);

            if (dataBd.ChaveIntegracao.Equals(indexViewModel.Integracao.ChaveIntegracao) && dataBd.CodigoLoja.Equals(indexViewModel.Integracao.CodigoLoja))
                return;

            integracaoEfRepository_.Update(indexViewModel.Integracao);
        }

        // GET: Fidelidade/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Fidelidade/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Fidelidade/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Fidelidade/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Fidelidade/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Fidelidade/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Fidelidade/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}