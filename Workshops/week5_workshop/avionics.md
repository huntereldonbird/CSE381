# Avionics Software Schedule

|Lifecycle Phase|Task ID|Task                         |Duration|Predecssors   |Successors        |Critical Path    |
|---------------|-------|-----------------------------|--------|--------------|------------------|-----------------|
|Project Start  |       |                             |        |              |                  |                 |
|               |      0|Project Start                |15      |0             |1, 2, 3, 4, 5, 9  |                 |
|Planning       |       |                             |        |              |                  |                 |     
|Planning       |       |                             |        |              |                  |                 | 
|               |      1|Write PSAC                   |10      |0             |6                 |                 |
|               |      2|Write SDP                    |10      |0             |6, 10             |                 |
|               |      3|Write SVP                    |10      |0             |6                 |                 |
|               |      4|Write SCMP                   |10      |0             |6                 |                 |
|               |      5|Write SQAP                   |10      |0             |6                 |                 |
|               |      6|Review Plans                 |10      |1, 2, 3, 4, 5 |7                 |                 |
|               |      7|Release Plans                |2       |6             |8, 11, 23         |                 |
|               |      8|SOI-1                        |5       |7             |31                |                 |
|Requirements   |       |                             |        |              |                  |                 |
|               |      9|Release Customer Requirements|2       |0             |10                |                 |
|               |     10|Write SRS                    |30      |2, 9          |11                |                 |
|               |     11|Review SRS                   |10      |10, 7         |12, 13            |                 |
|               |     12|Release SRS                  |2       |11            |14                |                 |
|Design         |       |                             |        |              |                  |                 |
|               |     13|Write SDD                    |50      |11            |14                |                 |
|               |     14|Review SDD                   |15      |12, 13        |15, 16            |                 |
|               |     15|Release SDD                  |2       |14            |17                |                 |
|Code           |       |                             |        |              |                  |                 |
|               |     16|Write Code                   |20      |14            |17, 21            |                 |
|               |     17|Review Code                  |5       |15, 16        |18, 22            |                 |
|               |     18|Release Code                 |2       |17            |19                |                 |
|               |     19|SOI-2                        |5       |18            |20, 31            |                 |
|Test           |       |                             |        |              |                  |                 |
|               |     20|Write Test Specifications    |60      |19            |21                |                 |
|               |     21|Write Test Procedures        |90      |20, 16        |22                |                 |
|               |     22|Dry Run Test Procedures      |10      |21, 17        |23, 26            |                 |
|               |     23|Review Tests                 |30      |7, 22         |24                |                 |
|               |     24|Release Tests                |5       |23            |25, 28            |                 |
|               |     25|SOI-3                        |5       |24            |29, 31            |                 |
|Certification  |       |                             |        |              |                  |                 |
|               |     26|Write SAS                    |5       |22            |27                |                 |
|               |     27|Review SAS                   |3       |26            |28                |                 |
|               |     28|Release SAS                  |2       |24, 27        |30                |                 |
|               |     29|Formal Test Execution        |10      |25            |30                |                 |
|               |     30|SOI-4                        |5       |28, 29        |31                |                 |
|               |     31|First Article Inspection     |3       |8, 19, 25, 30 |32                |                 |
|               |     32|Delivery Software            |2       |31            |33                |                 |
|Project End    |       |                             |        |              |                  |                 |
|               |     33|Project End                  |0       |32            |                  |                 |
|               |       |                             |        |              |**Total Duration**|                 |  


**Glossary**

* PSAC - Plan for Software Aspects of Certification
* SCMP - Software Configuratoin Management Plan
* SDD - Software Detailed Design
* SDP - Software Development Plan
* SOI - Stage of Involvement (Audit)
* SQAP - Software Quality Assurance Plan
* SRS - Software Requirements Specification
* SVP - Software Verification Paln


