luanet.load_assembly(assemblyname)


local   ActionNodes=toluacs.ActionNodes
--local   ActionNodes1=luanet.ActionNodes
local DeltaActionNode = luanet.DeltaActionNode


 local an =DeltaActionNode(0.6772121212,ActionNodes.MoveToTarget,"地方啦大家")
 an:Visit(nil,nil)


--print(type(ActionNodes.MoveToTarget()))