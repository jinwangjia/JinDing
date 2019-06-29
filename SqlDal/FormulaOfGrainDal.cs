using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SqlDal
{
    /// <summary>
    /// 配方之物料表
    /// </summary>
    public class FormulaOfGrainDal:ParentDal<FormulaOfGrainDefinition>
    {
        public class QueryByFormulaIdGrainTypeIdItem
        {
            /// <summary>
            /// 配方标示
            /// </summary>
            public string FormulaId { get; set; }
            /// <summary>
            /// 物料标示
            /// </summary>
            public string GrainId { get; set; }
            /// <summary>
            /// 重量
            /// </summary>
            public decimal Amount { get; set; }
            /// <summary>
            /// 物料名称
            /// </summary>
            public string GrainName { get; set; }
        }

        public IList<QueryByFormulaIdGrainTypeIdItem> QueryByFormulaIdGrainTypeId(string formulaId, int grainTypeId)
        {
            using (var dal = new BaseDal())
            {
                var list = from formulaOfGrain in dal.FormulaOfGrain
                           join grain in dal.Grain on formulaOfGrain.GrainId equals grain.GrainId
                           where (formulaOfGrain.FormulaId == formulaId) && (grain.GrainTypeId == grainTypeId)
                           select new QueryByFormulaIdGrainTypeIdItem()
                           {
                               FormulaId = formulaOfGrain.FormulaId,
                               GrainId = formulaOfGrain.GrainId,
                               Amount = formulaOfGrain.Amount,
                               GrainName = grain.GrainName
                           };

                return list.ToList();
            }
        }
    }
}
