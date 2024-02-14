using System.Collections;
using System.Collections.Generic;
using TowerDefense;
using UnityEngine;

namespace TowerDefense
{
   public static class CalculationElementalDamage
   {
      public static float CalculationDamage(ElementType minionType, ElementType projectileType)
      {
       float defaultMultiplierDamage = 1f;
       
         if (minionType == ElementType.None)
         {
            switch (projectileType)
            {
               case ElementType.None:
               {
                  return 1f;
               }

               case ElementType.Fire:
               {
                  return 2f;
               }

               case ElementType.Ice:
               {
                  return 1.5f;
               }

               case ElementType.Poison:
               {
                  return 1.25f;
               }
            }
         }

         if (minionType == ElementType.Fire)
         {
            switch (projectileType)
            {
               case ElementType.None:
               {
                  return 1f;
               }

               case ElementType.Fire:
               {
                  return .5f;
               }

               case ElementType.Ice:
               {
                  return 2f;
               }

               case ElementType.Poison:
               {
                  return .25f;
               }
            }

         }

         if (minionType == ElementType.Ice)
         {
            switch (projectileType)
            {
               case ElementType.None:
               {
                  return 1.25f;
               }

               case ElementType.Fire:
               {
                  return 2f;
               }

               case ElementType.Ice:
               {
                  return .5f;
               }

               case ElementType.Poison:
               {
                  return .25f;
               }
            }
         }

         if (minionType == ElementType.Poison)
         {
            switch (projectileType)
            {
               case ElementType.None:
               {
                  return 2f;
               }

               case ElementType.Fire:
               {
                  return 2f;
               }

               case ElementType.Ice:
               {
                  return 1f;
               }

               case ElementType.Poison:
               {
                  return .5f;
               }
            }
         }

         return defaultMultiplierDamage;
      }

   }
}
         
      