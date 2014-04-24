local CUtils=CUtils
--SINGLE=1 MULITPLE=2

Asset = class(function(self,url,names)
    -- self.type = type
    print(url)
    self.url = url --CUtils.GetAssetFullPath(url)
    self.fullUrl=CUtils.GetAssetFullPath(url)
    self.key = CUtils.GetKeyURLFileName(url)
    self.names = names
    if names then 
    	local len =#names local name
    	for i=1,len do name=names[i] names[name]=name   end 
	end
    self.items = {}
    self.root = nil
end)

function Asset:show(...)
	if self.items then
		for k,v in pairs(self.items) do
			v:SetActive(true)	
		end
	end
end

function Asset:hide(...)
	if self.items then
		for k,v in pairs(self.items) do
			v:SetActive(false)	
		end
	end
end

--
function Asset:copyTo(asse)
	--asse.type=self.type
	asse.key = self.key
	asse.url = self.url
	asse.fullUrl = self.fullUrl
	local names=asse.names
	if names then
		asse.items={}
		for k,v in pairs(names) do
			local ref=self.items[v]
			asse.items[v] = ref
		end
	else
		asse.items=self.items
	end
	asse.root = self.root
	return asse
end

function Asset:__tostring()
    return string.format("asset.key = %s ,url =%s ", self.key,self.url)
end