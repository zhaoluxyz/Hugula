---------------------------------------------------------------------------------------------------
--===============================================================================================--
--filename: mailData.lua
--data:2014.10.28
--author:yue an bang
--desc:邮件数据模块,新邮件数量需要保存，文件名字关联用户名
--===============================================================================================--
---------------------------------------------------------------------------------------------------
MailData={}
local MailData = MailData

--mail data
MailData.mailData = {}
MailData.newMail = 0
function MailData.getMailData()
  return MailData.mailData
end

function MailData.getMailCount()
  return #MailData.mailData
end


function MailData.getMailFromID(id)
  for k,v in pairs(MailData.mailData) do
    if v.mail_id == id then
      return v
    end
  end
  return nil
end

function MailData.getNewMailCount()
  return MailData.newMail
end

function MailData.setNewMailCount(count)
  MailData.newMail = count
end

function MailData.SetMailRead(id)
  for i=1,#MailData.mailData do
    if MailData.mailData[i].mail_id == id then
      MailData.mailData[i].mail_status = 1
      return
    end
  end
end

function MailData.insertMail(item)
  print("insertMail")
  print(#item)
  for i=1,#item do
    if item[i].mail_id and MailData.getMailFromID(item[i].mail_id) == nil then
      table.insert(MailData.mailData,item[i])
    else
      print("MailData.insertMail error :" .. item[i].mail_id )
    end
  end
end

function MailData.deleteMail(id)
  for i=1,#MailData.mailData do
    if MailData.mailData[i].mail_id == id then
      table.remove(MailData.mailData,i)
      return
    end
  end
end



