<Query Kind="SQL">
  <Connection>
    <ID>2816f349-6f74-43e6-8ba9-e9e90a154e7f</ID>
    <Persist>true</Persist>
    <Server>.\SQLEXPRESS</Server>
    <Database>ZooER</Database>
    <ShowServer>true</ShowServer>
  </Connection>
  <Output>DataGrids</Output>
</Query>

select * from Animals;

//Find all parents for a specific child
select child.Name, parent.Name 
from Animals child
inner join ChildrenParents bridge
on bridge.ChildID = child.AnimalId
inner join Animals parent
on bridge.ParentID = parent.AnimalId
where child.Name = 'Cat'
