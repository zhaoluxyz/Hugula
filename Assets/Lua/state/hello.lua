local hello = LuaItemManager:getItemObject("hello")

hello.assets=
{
  Asset("Hello.u3d"),
  Asset("BlockRoot.u3d",{"StartPanel","Blocks"})
}

function hello:onAssetsLoad(items)
  print(tojson(items))
  self:hide()
  delay(self.show,2,self)

  print(self.assets[2].items["StartPanel"].name)
  print("....................... hello resource is loaded !")
end

function hello:onClick(...)
  print("hello onclick ")
end
--return ItemObject